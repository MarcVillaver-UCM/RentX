using System;
using MySql.Data.MySqlClient;

namespace RentXpress.Services
{
    public static class DBConnection
    {
        private const string Server = "localhost";
        private const string Database = "rentxpress";
        private const string User = "root";
        private const string Password = "";
        private const uint Port = 3306;

        public static string LastError { get; private set; }
        public static string LastDiagnostic { get; private set; }

        public static string ConnectionString
        {
            get
            {
                var builder = new MySqlConnectionStringBuilder
                {
                    Server = Server,
                    Port = Port,
                    Database = Database,
                    UserID = User,
                    Password = Password,
                    CharacterSet = "utf8mb4",
                    SslMode = MySqlSslMode.Disabled
                };

                return builder.ConnectionString;
            }
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                LastError = null;
                LastDiagnostic = null;

                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                LastDiagnostic = ClassifyFailure(ex);
                return false;
            }
        }

        private static string ClassifyFailure(Exception ex)
        {
            var message = ex.ToString();

            if (ex is MySqlException mysqlEx)
            {
                if (mysqlEx.Number == 0 || message.IndexOf("Unable to connect", StringComparison.OrdinalIgnoreCase) >= 0)
                    return "MySQL is not running or localhost:3306 is unreachable.";
                if (mysqlEx.Number == 1045)
                    return "Authentication failed for user root with an empty password.";
                if (mysqlEx.Number == 1049)
                    return "The database 'rentxpress' does not exist.";
            }

            if (message.IndexOf("ConnectionString", StringComparison.OrdinalIgnoreCase) >= 0 ||
                message.IndexOf("Keyword not supported", StringComparison.OrdinalIgnoreCase) >= 0)
                return "The MySQL connection string is invalid.";

            if (message.IndexOf("Could not load file or assembly", StringComparison.OrdinalIgnoreCase) >= 0 ||
                message.IndexOf("type initializer", StringComparison.OrdinalIgnoreCase) >= 0)
                return "A database connector or .NET runtime dependency failed to load.";

            return "Unexpected database connection error.";
        }
    }
}
