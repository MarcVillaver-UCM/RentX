using System;
using System.Collections.Generic;
using System.IO;
using MySql.Data.MySqlClient;
using RentXpress.Models;

namespace RentXpress.Services
{
    public class VehicleService
    {
        // MODIFIED CODE
        // Owner payment details are selected with the vehicle so the renter can pay from chat.
        private const string BaseSelect = @"
            SELECT v.*, u.first_name, u.last_name, u.email AS owner_email, u.phone AS owner_phone,
                   u.gcash_number, u.gcash_name, u.bank_name, u.bank_account_number, u.bank_account_name
            FROM vehicles v
            JOIN users u ON v.owner_id = u.id";

        private Vehicle MapVehicle(MySqlDataReader r)
        {
            return new Vehicle
            {
                Id = r.GetInt32("id"),
                OwnerId = r.GetInt32("owner_id"),
                OwnerName = r.GetString("first_name") + " " + r.GetString("last_name"),
                OwnerEmail = r.IsDBNull(r.GetOrdinal("owner_email")) ? "" : r.GetString("owner_email"),
                OwnerPhone = r.IsDBNull(r.GetOrdinal("owner_phone")) ? "" : r.GetString("owner_phone"),
                // NEW CODE
                OwnerGCashNumber = r.IsDBNull(r.GetOrdinal("gcash_number")) ? "" : r.GetString("gcash_number"),
                OwnerGCashName = r.IsDBNull(r.GetOrdinal("gcash_name")) ? "" : r.GetString("gcash_name"),
                OwnerBankName = r.IsDBNull(r.GetOrdinal("bank_name")) ? "" : r.GetString("bank_name"),
                OwnerBankAccountNumber = r.IsDBNull(r.GetOrdinal("bank_account_number")) ? "" : r.GetString("bank_account_number"),
                OwnerBankAccountName = r.IsDBNull(r.GetOrdinal("bank_account_name")) ? "" : r.GetString("bank_account_name"),
                Name = r.GetString("name"),
                Type = r.GetString("type"),
                FuelType = r.IsDBNull(r.GetOrdinal("fuel_type")) ? "" : r.GetString("fuel_type"),
                Transmission = r.IsDBNull(r.GetOrdinal("transmission")) ? "" : r.GetString("transmission"),
                Seats = r.GetInt32("seats"),
                PricePerDay = r.GetDecimal("price_per_day"),
                Rating = r.IsDBNull(r.GetOrdinal("rating")) ? 0 : r.GetDecimal("rating"),
                ReviewCount = r.IsDBNull(r.GetOrdinal("review_count")) ? 0 : r.GetInt32("review_count"),
                Status = r.GetString("status"),
                Tags = r.IsDBNull(r.GetOrdinal("tags")) ? "" : r.GetString("tags"),
                Description = r.IsDBNull(r.GetOrdinal("description")) ? "" : r.GetString("description"),
                // NEW CODE
                CurrentLocation = HasColumn(r, "current_location") && !r.IsDBNull(r.GetOrdinal("current_location")) ? r.GetString("current_location") : "",
                ImagePath = HasColumn(r, "image_path") && !r.IsDBNull(r.GetOrdinal("image_path")) ? r.GetString("image_path") : "",
                ImageData = ReadImageData(r),
                CreatedAt = r.GetDateTime("created_at")
            };
        }

        // NEW CODE
        // Older vehicle tables do not have location yet. Add it before loading/saving vehicles.
        private void EnsureVehicleLocationColumn(MySqlConnection conn)
        {
            TryAddColumn(conn, "ALTER TABLE vehicles ADD COLUMN current_location VARCHAR(255) DEFAULT ''");
        }

        // NEW CODE
        // Vehicles depend on company payment details, so the vehicle service also protects
        // older databases before SELECT statements reference the new user columns.
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
                if (ex.Number != 1060) throw;
            }
        }


        private static bool HasColumn(MySqlDataReader r, string columnName)
        {
            for (int i = 0; i < r.FieldCount; i++)
                if (string.Equals(r.GetName(i), columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        private static byte[] ReadImageData(MySqlDataReader r)
        {
            if (!HasColumn(r, "image_data")) return null;
            int ordinal = r.GetOrdinal("image_data");
            return r.IsDBNull(ordinal) ? null : (byte[])r[ordinal];
        }
        public List<Vehicle> GetAll(string search = "", string typeFilter = "")
        {
            var list = new List<Vehicle>();
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureCompanyPaymentColumns(conn);
                    EnsureVehicleLocationColumn(conn);
                    var sql = BaseSelect + " WHERE 1=1";
                    if (!string.IsNullOrWhiteSpace(search))
                        sql += " AND (v.name LIKE @search OR v.type LIKE @search OR v.tags LIKE @search)";
                    if (!string.IsNullOrWhiteSpace(typeFilter) && typeFilter != "All Types")
                        sql += " AND v.type = @type";
                    sql += " ORDER BY v.rating DESC";

                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(search))
                            cmd.Parameters.AddWithValue("@search", $"%{search}%");
                        if (!string.IsNullOrWhiteSpace(typeFilter) && typeFilter != "All Types")
                            cmd.Parameters.AddWithValue("@type", typeFilter);

                        using (var r = cmd.ExecuteReader())
                            while (r.Read()) list.Add(MapVehicle(r));
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to load vehicles: " + ex.Message); }
            return list;
        }

        public Vehicle GetById(int id)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureCompanyPaymentColumns(conn);
                    EnsureVehicleLocationColumn(conn);
                    var sql = BaseSelect + " WHERE v.id=@id LIMIT 1";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (var r = cmd.ExecuteReader())
                            if (r.Read()) return MapVehicle(r);
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to load vehicle: " + ex.Message); }
            return null;
        }

        public List<Vehicle> GetByOwner(int ownerId)
        {
            var list = new List<Vehicle>();
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureCompanyPaymentColumns(conn);
                    EnsureVehicleLocationColumn(conn);
                    var sql = BaseSelect + " WHERE v.owner_id=@oid ORDER BY v.created_at DESC";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@oid", ownerId);
                        using (var r = cmd.ExecuteReader())
                            while (r.Read()) list.Add(MapVehicle(r));
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to load vehicles: " + ex.Message); }
            return list;
        }

        public bool Add(Vehicle v)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureVehicleLocationColumn(conn);
                    const string sql = @"INSERT INTO vehicles 
                        (owner_id, name, type, fuel_type, transmission, seats, price_per_day, status, tags, description, current_location, image_data)
                        VALUES (@oid, @name, @type, @fuel, @trans, @seats, @price, @status, @tags, @desc, @location, @image)";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@oid", v.OwnerId);
                        cmd.Parameters.AddWithValue("@name", v.Name);
                        cmd.Parameters.AddWithValue("@type", v.Type);
                        cmd.Parameters.AddWithValue("@fuel", v.FuelType);
                        cmd.Parameters.AddWithValue("@trans", v.Transmission);
                        cmd.Parameters.AddWithValue("@seats", v.Seats);
                        cmd.Parameters.AddWithValue("@price", v.PricePerDay);
                        cmd.Parameters.AddWithValue("@status", v.Status ?? "available");
                        cmd.Parameters.AddWithValue("@tags", v.Tags ?? "");
                        cmd.Parameters.AddWithValue("@desc", v.Description ?? "");
                        cmd.Parameters.AddWithValue("@location", v.CurrentLocation ?? "");
                        cmd.Parameters.AddWithValue("@image", v.ImageData == null ? (object)DBNull.Value : v.ImageData);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to add vehicle: " + ex.Message); }
        }

        public bool Update(Vehicle v)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureVehicleLocationColumn(conn);
                    const string sql = @"UPDATE vehicles SET name=@name, type=@type, fuel_type=@fuel, 
                        transmission=@trans, seats=@seats, price_per_day=@price, status=@status,
                        tags=@tags, description=@desc, current_location=@location, image_data=@image WHERE id=@id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", v.Name);
                        cmd.Parameters.AddWithValue("@type", v.Type);
                        cmd.Parameters.AddWithValue("@fuel", v.FuelType);
                        cmd.Parameters.AddWithValue("@trans", v.Transmission);
                        cmd.Parameters.AddWithValue("@seats", v.Seats);
                        cmd.Parameters.AddWithValue("@price", v.PricePerDay);
                        cmd.Parameters.AddWithValue("@status", v.Status);
                        cmd.Parameters.AddWithValue("@tags", v.Tags ?? "");
                        cmd.Parameters.AddWithValue("@desc", v.Description ?? "");
                        cmd.Parameters.AddWithValue("@location", v.CurrentLocation ?? "");
                        cmd.Parameters.AddWithValue("@image", v.ImageData == null ? (object)DBNull.Value : v.ImageData);
                        cmd.Parameters.AddWithValue("@id", v.Id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to update vehicle: " + ex.Message); }
        }


        public bool UpdateImage(int vehicleId, byte[] imageData)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "UPDATE vehicles SET image_data=@image WHERE id=@id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@image", imageData == null ? (object)DBNull.Value : imageData);
                        cmd.Parameters.AddWithValue("@id", vehicleId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to update vehicle image: " + ex.Message); }
        }

        public bool UpdateImageFromFile(int vehicleId, string imagePath)
        {
            return UpdateImage(vehicleId, string.IsNullOrWhiteSpace(imagePath) ? null : File.ReadAllBytes(imagePath));
        }
        public bool Delete(int id)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "DELETE FROM vehicles WHERE id=@id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex) { throw new Exception("Failed to delete vehicle: " + ex.Message); }
        }

        public List<string> GetTypes()
        {
            var list = new List<string> { "All Types" };
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "SELECT DISTINCT type FROM vehicles ORDER BY type";
                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var r = cmd.ExecuteReader())
                        while (r.Read()) list.Add(r.GetString(0));
                }
            }
            catch { }
            return list;
        }
    }
}





