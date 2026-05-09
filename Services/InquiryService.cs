using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using RentXpress.Models;

namespace RentXpress.Services
{
    public class InquiryService
    {
        // NEW CODE
        // Some users already have a database created before payment/price fields existed.
        // These helpers let the app read old rows safely and add missing columns at runtime.
        private static bool HasColumn(MySqlDataReader r, string columnName)
        {
            for (int i = 0; i < r.FieldCount; i++)
                if (string.Equals(r.GetName(i), columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        private static decimal GetDecimalOrZero(MySqlDataReader r, string columnName)
        {
            if (!HasColumn(r, columnName) || r.IsDBNull(r.GetOrdinal(columnName))) return 0m;
            return r.GetDecimal(columnName);
        }

        // NEW CODE
        // Older inquiry rows may not have number_of_days yet, so default to one day.
        private static int GetIntOrDefault(MySqlDataReader r, string columnName, int fallback)
        {
            if (!HasColumn(r, columnName) || r.IsDBNull(r.GetOrdinal(columnName))) return fallback;
            return r.GetInt32(columnName);
        }

        private static string GetStringOrDefault(MySqlDataReader r, string columnName, string fallback)
        {
            if (!HasColumn(r, columnName) || r.IsDBNull(r.GetOrdinal(columnName))) return fallback;
            return r.GetString(columnName);
        }

        // Converts one inquiry row from MySQL into the C# model used by the forms.
        private Inquiry MapInquiry(MySqlDataReader r)
        {
            return new Inquiry
            {
                Id = r.GetInt32("id"),
                SenderId = r.GetInt32("sender_id"),
                SenderName = r.IsDBNull(r.GetOrdinal("sender_name")) ? "" : r.GetString("sender_name"),
                VehicleId = r.GetInt32("vehicle_id"),
                VehicleName = r.IsDBNull(r.GetOrdinal("vehicle_name")) ? "" : r.GetString("vehicle_name"),
                OwnerId = r.GetInt32("owner_id"),
                OwnerName = r.IsDBNull(r.GetOrdinal("owner_name")) ? "" : r.GetString("owner_name"),
                Subject = r.GetString("subject"),
                Message = r.GetString("message"),
                Status = r.GetString("status"),
                IsEmergency = r.GetInt32("is_emergency") == 1,
                PriorityLevel = r.GetString("priority_level"),
                // NEW CODE
                // Old inquiry rows will not have these values, so default values keep the list usable.
                BasePrice = GetDecimalOrZero(r, "base_price"),
                SurchargeAmount = GetDecimalOrZero(r, "surcharge_amount"),
                TotalPrice = GetDecimalOrZero(r, "total_price"),
                // NEW CODE
                NumberOfDays = GetIntOrDefault(r, "number_of_days", 1),
                TotalAmount = GetDecimalOrZero(r, "total_amount") > 0m
                    ? GetDecimalOrZero(r, "total_amount")
                    : GetDecimalOrZero(r, "total_price"),
                // NEW CODE
                PlatformFee = GetDecimalOrZero(r, "platform_fee"),
                OwnerAmount = GetDecimalOrZero(r, "owner_amount"),
                PaymentMethod = GetStringOrDefault(r, "payment_method", "Cash"),
                PaymentStatus = GetStringOrDefault(r, "payment_status", "Pending"),
                // NEW CODE
                PaymentReference = GetStringOrDefault(r, "payment_reference", ""),
                PaymentConfirmedBy = HasColumn(r, "payment_confirmed_by") && !r.IsDBNull(r.GetOrdinal("payment_confirmed_by")) ? r.GetInt32("payment_confirmed_by") : 0,
                PaymentConfirmedAt = HasColumn(r, "payment_confirmed_at") && !r.IsDBNull(r.GetOrdinal("payment_confirmed_at")) ? (DateTime?)r.GetDateTime("payment_confirmed_at") : null,
                OwnerGCashNumber = GetStringOrDefault(r, "gcash_number", ""),
                OwnerGCashName = GetStringOrDefault(r, "gcash_name", ""),
                OwnerBankName = GetStringOrDefault(r, "bank_name", ""),
                OwnerBankAccountNumber = GetStringOrDefault(r, "bank_account_number", ""),
                OwnerBankAccountName = GetStringOrDefault(r, "bank_account_name", ""),
                CreatedAt = r.GetDateTime("created_at")
            };
        }

        // Converts one reply row into a chat-message object for the conversation panel.
        private InquiryReply MapReply(MySqlDataReader r)
        {
            return new InquiryReply
            {
                Id = r.GetInt32("id"),
                InquiryId = r.GetInt32("inquiry_id"),
                SenderId = r.GetInt32("sender_id"),
                SenderName = r.IsDBNull(r.GetOrdinal("sender_name")) ? "" : r.GetString("sender_name"),
                Message = r.GetString("message"),
                CreatedAt = r.GetDateTime("created_at")
            };
        }

        private const string BaseSelect = @"
            SELECT i.*, 
                CONCAT(s.first_name,' ',s.last_name) AS sender_name,
                v.name AS vehicle_name,
                CONCAT(o.first_name,' ',o.last_name) AS owner_name,
                o.gcash_number, o.gcash_name, o.bank_name, o.bank_account_number, o.bank_account_name
            FROM inquiries i
            JOIN users s ON i.sender_id = s.id
            JOIN vehicles v ON i.vehicle_id = v.id
            JOIN users o ON i.owner_id = o.id";

        // NEW CODE
        // Adds payment and booking-total fields without requiring the user to recreate the database.
        // Each ALTER is isolated because existing databases may already have only some of these columns.
        private void EnsureInquiryBookingColumns(MySqlConnection conn)
        {
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN base_price DECIMAL(10,2) DEFAULT 0");
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN surcharge_amount DECIMAL(10,2) DEFAULT 0");
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN total_price DECIMAL(10,2) DEFAULT 0");
            // NEW CODE
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN number_of_days INT DEFAULT 1");
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN total_amount DECIMAL(10,2) DEFAULT 0");
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN platform_fee DECIMAL(10,2) DEFAULT 0");
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN owner_amount DECIMAL(10,2) DEFAULT 0");
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN payment_method VARCHAR(50) DEFAULT 'Cash'");
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN payment_status VARCHAR(50) DEFAULT 'Pending'");
            // NEW CODE
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN payment_reference VARCHAR(255) DEFAULT ''");
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN payment_confirmed_by INT NULL");
            TryAddColumn(conn, "ALTER TABLE inquiries ADD COLUMN payment_confirmed_at DATETIME NULL");
        }

        // NEW CODE
        // Inquiry SELECTs include owner payout fields, so make sure older users tables have them.
        private void EnsureCompanyPaymentColumns(MySqlConnection conn)
        {
            TryAddColumn(conn, "ALTER TABLE users ADD COLUMN gcash_number VARCHAR(50) DEFAULT ''");
            TryAddColumn(conn, "ALTER TABLE users ADD COLUMN gcash_name VARCHAR(150) DEFAULT ''");
            TryAddColumn(conn, "ALTER TABLE users ADD COLUMN bank_name VARCHAR(150) DEFAULT ''");
            TryAddColumn(conn, "ALTER TABLE users ADD COLUMN bank_account_number VARCHAR(80) DEFAULT ''");
            TryAddColumn(conn, "ALTER TABLE users ADD COLUMN bank_account_name VARCHAR(150) DEFAULT ''");
        }

        private void TryAddColumn(MySqlConnection conn, string sql)
        {
            try
            {
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                // Duplicate column means the user's database is already upgraded, so continue normally.
                if (ex.Number != 1060) throw;
            }
        }

        private void EnsureReplyTable(MySqlConnection conn)
        {
            // Older local databases may not have this table yet, so create it before chat reads/writes.
            const string sql = @"
                CREATE TABLE IF NOT EXISTS inquiry_replies (
                    id INT AUTO_INCREMENT PRIMARY KEY,
                    inquiry_id INT NOT NULL,
                    sender_id INT NOT NULL,
                    message TEXT NOT NULL,
                    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
                    FOREIGN KEY (inquiry_id) REFERENCES inquiries(id) ON DELETE CASCADE,
                    FOREIGN KEY (sender_id) REFERENCES users(id) ON DELETE CASCADE
                )";

            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public List<Inquiry> GetBySender(int senderId)
        {
            var list = new List<Inquiry>();
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureCompanyPaymentColumns(conn);
                    EnsureInquiryBookingColumns(conn);
                    var sql = BaseSelect + " WHERE i.sender_id=@sid ORDER BY i.created_at DESC";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", senderId);
                        using (var r = cmd.ExecuteReader())
                            while (r.Read()) list.Add(MapInquiry(r));
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to load inquiries: " + ex.Message); }
            return list;
        }

        public List<Inquiry> GetByOwner(int ownerId)
        {
            var list = new List<Inquiry>();
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureCompanyPaymentColumns(conn);
                    EnsureInquiryBookingColumns(conn);
                    var sql = BaseSelect + " WHERE i.owner_id=@oid ORDER BY i.is_emergency DESC, i.created_at DESC";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@oid", ownerId);
                        using (var r = cmd.ExecuteReader())
                            while (r.Read()) list.Add(MapInquiry(r));
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to load inquiries: " + ex.Message); }
            return list;
        }


        public int CountPendingByOwner(int ownerId)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "SELECT COUNT(*) FROM inquiries WHERE owner_id=@oid AND status='pending'";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@oid", ownerId);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch { return 0; }
        }
        public List<Inquiry> GetAll()
        {
            var list = new List<Inquiry>();
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureCompanyPaymentColumns(conn);
                    EnsureInquiryBookingColumns(conn);
                    var sql = BaseSelect + " ORDER BY i.is_emergency DESC, i.created_at DESC";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(MapInquiry(r));
                }
            }
            catch (Exception ex) { throw new Exception("Failed to load inquiries: " + ex.Message); }
            return list;
        }

        public bool Send(Inquiry inq)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureCompanyPaymentColumns(conn);
                    EnsureInquiryBookingColumns(conn);

                    // MODIFIED CODE
                    // Payment and price fields are stored with the booking request so both renter
                    // and company owner see the same amount and payment mode later.
                    const string sql = @"INSERT INTO inquiries 
                        (sender_id, vehicle_id, owner_id, subject, message, is_emergency, priority_level,
                         base_price, surcharge_amount, total_price, number_of_days, total_amount,
                         platform_fee, owner_amount, payment_method, payment_status)
                        VALUES (@sid, @vid, @oid, @subj, @msg, @emerg, @prio,
                                @basePrice, @surcharge, @totalPrice, @numberOfDays, @totalAmount,
                                @platformFee, @ownerAmount, @paymentMethod, @paymentStatus)";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@sid", inq.SenderId);
                        cmd.Parameters.AddWithValue("@vid", inq.VehicleId);
                        cmd.Parameters.AddWithValue("@oid", inq.OwnerId);
                        cmd.Parameters.AddWithValue("@subj", inq.Subject);
                        cmd.Parameters.AddWithValue("@msg", inq.Message);
                        cmd.Parameters.AddWithValue("@emerg", inq.IsEmergency ? 1 : 0);
                        cmd.Parameters.AddWithValue("@prio", inq.PriorityLevel ?? "normal");
                        cmd.Parameters.AddWithValue("@basePrice", inq.BasePrice);
                        cmd.Parameters.AddWithValue("@surcharge", inq.SurchargeAmount);
                        cmd.Parameters.AddWithValue("@totalPrice", inq.TotalPrice);
                        cmd.Parameters.AddWithValue("@numberOfDays", Math.Max(1, inq.NumberOfDays));
                        cmd.Parameters.AddWithValue("@totalAmount", inq.TotalAmount);
                        cmd.Parameters.AddWithValue("@platformFee", inq.PlatformFee);
                        cmd.Parameters.AddWithValue("@ownerAmount", inq.OwnerAmount);
                        cmd.Parameters.AddWithValue("@paymentMethod", inq.PaymentMethod ?? "Cash");
                        cmd.Parameters.AddWithValue("@paymentStatus", inq.PaymentStatus ?? "Pending");
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to send inquiry: " + ex.Message); }
        }

        public List<InquiryReply> GetReplies(int inquiryId)
        {
            var replies = new List<InquiryReply>();
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    EnsureReplyTable(conn);

                    // Replies are ordered oldest-first so the chat reads naturally from top to bottom.
                    const string sql = @"
                        SELECT r.*, CONCAT(u.first_name,' ',u.last_name) AS sender_name
                        FROM inquiry_replies r
                        JOIN users u ON r.sender_id = u.id
                        WHERE r.inquiry_id=@inqId
                        ORDER BY r.created_at ASC";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@inqId", inquiryId);
                        using (var r = cmd.ExecuteReader())
                            while (r.Read()) replies.Add(MapReply(r));
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to load conversation replies: " + ex.Message); }
            return replies;
        }

        public bool SendReply(int inquiryId, int senderId, string message)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    EnsureReplyTable(conn);

                    // The transaction keeps the chat reply and the inquiry status in sync.
                    using (var tx = conn.BeginTransaction())
                    {
                        const string insertSql = @"
                            INSERT INTO inquiry_replies (inquiry_id, sender_id, message)
                            VALUES (@inqId, @senderId, @message)";

                        using (var cmd = new MySqlCommand(insertSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@inqId", inquiryId);
                            cmd.Parameters.AddWithValue("@senderId", senderId);
                            cmd.Parameters.AddWithValue("@message", message);
                            cmd.ExecuteNonQuery();
                        }

                        // If the owner replies, the inquiry is now confirmed/replied.
                        // If the renter follows up, it becomes pending again for the owner.
                        const string statusSql = @"
                            UPDATE inquiries
                            SET status = CASE WHEN owner_id=@senderId THEN 'replied' ELSE 'pending' END
                            WHERE id=@inqId";

                        using (var cmd = new MySqlCommand(statusSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@senderId", senderId);
                            cmd.Parameters.AddWithValue("@inqId", inquiryId);
                            cmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }

                    return true;
                }
            }
            catch (Exception ex) { throw new Exception("Failed to send reply: " + ex.Message); }
        }

        public bool UpdateStatus(int id, string status)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "UPDATE inquiries SET status=@status WHERE id=@id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to update status: " + ex.Message); }
        }

        public bool CancelBooking(int inquiryId, int senderId)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    EnsureInquiryBookingColumns(conn);

                    const string sql = @"
                        UPDATE inquiries
                        SET status='closed'
                        WHERE id=@id
                          AND sender_id=@senderId
                          AND status <> 'closed'
                          AND LOWER(COALESCE(payment_status, 'pending')) <> 'paid'";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", inquiryId);
                        cmd.Parameters.AddWithValue("@senderId", senderId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to cancel booking: " + ex.Message); }
        }

        // NEW CODE
        // MODIFIED CODE
        // Renters no longer mark themselves as paid. They submit a method and proof/reference,
        // then the company owner confirms it from their chat view.
        public bool SubmitPaymentProof(int inquiryId, string paymentMethod, string paymentReference)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    EnsureInquiryBookingColumns(conn);
                    const string sql = @"UPDATE inquiries 
                        SET payment_method=@method, payment_status='pending',
                            payment_reference=@reference,
                            payment_confirmed_by=NULL, payment_confirmed_at=NULL
                        WHERE id=@id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@method", paymentMethod);
                        cmd.Parameters.AddWithValue("@reference", paymentReference ?? "");
                        cmd.Parameters.AddWithValue("@id", inquiryId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to update payment: " + ex.Message); }
        }

        // NEW CODE
        // Only company owners should call this. It turns a submitted proof into a confirmed paid status.
        public bool ConfirmPayment(int inquiryId, int ownerId)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    EnsureInquiryBookingColumns(conn);
                    const string sql = @"UPDATE inquiries 
                        SET payment_status='paid', payment_confirmed_by=@ownerId, payment_confirmed_at=NOW()
                        WHERE id=@id AND owner_id=@ownerId";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@ownerId", ownerId);
                        cmd.Parameters.AddWithValue("@id", inquiryId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to confirm payment: " + ex.Message); }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "DELETE FROM inquiries WHERE id=@id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to delete inquiry: " + ex.Message); }
        }
    }
}


