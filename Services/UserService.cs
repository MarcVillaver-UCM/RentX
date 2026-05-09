using System;
using System.Security.Cryptography;
using System.Text;
using MySql.Data.MySqlClient;
using RentXpress.Models;

namespace RentXpress.Services
{
    public class UserService
    {
        // NEW CODE
        // Older databases do not have company payment columns. We add them lazily so the
        // feature works without asking the user to rebuild or manually migrate the database.
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
                // MySQL error 1060 means duplicate column, which is fine for upgraded databases.
                if (ex.Number != 1060) throw;
            }
        }

        // NEW CODE
        // Keeps user mapping in one place so Login and future lookups fill payment fields consistently.
        private User MapUser(MySqlDataReader r)
        {
            return new User
            {
                Id = r.GetInt32("id"),
                FirstName = r.GetString("first_name"),
                LastName = r.GetString("last_name"),
                Email = r.GetString("email"),
                Phone = r.IsDBNull(r.GetOrdinal("phone")) ? "" : r.GetString("phone"),
                AccountType = r.GetString("account_type"),
                CompanyName = r.IsDBNull(r.GetOrdinal("company_name")) ? "" : r.GetString("company_name"),
                GCashNumber = r.IsDBNull(r.GetOrdinal("gcash_number")) ? "" : r.GetString("gcash_number"),
                GCashName = r.IsDBNull(r.GetOrdinal("gcash_name")) ? "" : r.GetString("gcash_name"),
                BankName = r.IsDBNull(r.GetOrdinal("bank_name")) ? "" : r.GetString("bank_name"),
                BankAccountNumber = r.IsDBNull(r.GetOrdinal("bank_account_number")) ? "" : r.GetString("bank_account_number"),
                BankAccountName = r.IsDBNull(r.GetOrdinal("bank_account_name")) ? "" : r.GetString("bank_account_name"),
                CreatedAt = r.GetDateTime("created_at")
            };
        }

        // Hash password using MD5 (matches sample data; use BCrypt in production)
        private static string HashPassword(string password)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                var sb = new StringBuilder();
                foreach (var b in bytes) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        public User Login(string email, string password)
        {
            return Login(email, password, null);
        }

        public User Login(string email, string password, string accountType)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureCompanyPaymentColumns(conn);
                    const string sql = @"SELECT id, first_name, last_name, email, phone, 
                                         account_type, company_name, gcash_number, gcash_name,
                                         bank_name, bank_account_number, bank_account_name, created_at 
                                         FROM users 
                                         WHERE email=@email 
                                           AND password_hash=@pwd
                                           AND (@accountType IS NULL OR account_type=@accountType)
                                         LIMIT 1";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@pwd", HashPassword(password));
                        cmd.Parameters.AddWithValue("@accountType", string.IsNullOrWhiteSpace(accountType) ? (object)DBNull.Value : accountType);
                        using (var r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                // MODIFIED CODE
                                return MapUser(r);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Login failed: " + ex.Message);
            }
            return null;
        }

        public bool Register(User user, string password, string accountType)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureCompanyPaymentColumns(conn);
                    const string sql = @"INSERT INTO users 
                        (first_name, last_name, email, phone, password_hash, account_type, company_name,
                         gcash_number, gcash_name, bank_name, bank_account_number, bank_account_name) 
                        VALUES (@fn, @ln, @email, @phone, @pwd, @atype, @cname,
                                @gcashNumber, @gcashName, @bankName, @bankNumber, @bankAccountName)";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@fn", user.FirstName);
                        cmd.Parameters.AddWithValue("@ln", user.LastName);
                        cmd.Parameters.AddWithValue("@email", user.Email);
                        cmd.Parameters.AddWithValue("@phone", user.Phone ?? "");
                        cmd.Parameters.AddWithValue("@pwd", HashPassword(password));
                        cmd.Parameters.AddWithValue("@atype", accountType);
                        cmd.Parameters.AddWithValue("@cname", user.CompanyName ?? "");
                        cmd.Parameters.AddWithValue("@gcashNumber", user.GCashNumber ?? "");
                        cmd.Parameters.AddWithValue("@gcashName", user.GCashName ?? "");
                        cmd.Parameters.AddWithValue("@bankName", user.BankName ?? "");
                        cmd.Parameters.AddWithValue("@bankNumber", user.BankAccountNumber ?? "");
                        cmd.Parameters.AddWithValue("@bankAccountName", user.BankAccountName ?? "");
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                throw new Exception("Email already registered.");
            }
            catch (Exception ex)
            {
                throw new Exception("Registration failed: " + ex.Message);
            }
        }

        public bool UpdateProfile(User user)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    // NEW CODE
                    EnsureCompanyPaymentColumns(conn);
                    // MODIFIED CODE
                    // Profile updates now include company payment details. Personal accounts simply
                    // save empty strings because their payment fields are hidden.
                    const string sql = @"UPDATE users SET first_name=@fn, last_name=@ln, 
                        phone=@phone, company_name=@cname,
                        gcash_number=@gcashNumber, gcash_name=@gcashName,
                        bank_name=@bankName, bank_account_number=@bankNumber,
                        bank_account_name=@bankAccountName WHERE id=@id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@fn", user.FirstName);
                        cmd.Parameters.AddWithValue("@ln", user.LastName);
                        cmd.Parameters.AddWithValue("@phone", user.Phone ?? "");
                        cmd.Parameters.AddWithValue("@cname", user.CompanyName ?? "");
                        cmd.Parameters.AddWithValue("@gcashNumber", user.GCashNumber ?? "");
                        cmd.Parameters.AddWithValue("@gcashName", user.GCashName ?? "");
                        cmd.Parameters.AddWithValue("@bankName", user.BankName ?? "");
                        cmd.Parameters.AddWithValue("@bankNumber", user.BankAccountNumber ?? "");
                        cmd.Parameters.AddWithValue("@bankAccountName", user.BankAccountName ?? "");
                        cmd.Parameters.AddWithValue("@id", user.Id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Profile update failed: " + ex.Message);
            }
        }

        public bool UpdatePassword(int userId, string newPassword)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "UPDATE users SET password_hash=@pwd WHERE id=@id";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@pwd", HashPassword(newPassword));
                        cmd.Parameters.AddWithValue("@id", userId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Password update failed: " + ex.Message);
            }
        }

        public bool EmailExists(string email)
        {
            try
            {
                using (var conn = DBConnection.GetConnection())
                {
                    conn.Open();
                    const string sql = "SELECT COUNT(*) FROM users WHERE email=@email";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    }
                }
            }
            catch { return false; }
        }
    }
}

