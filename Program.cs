using System;
using System.Windows.Forms;
using RentXpress.Forms;
using RentXpress.Services;

namespace RentXpress
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Test DB connection on startup
            if (!DBConnection.TestConnection())
            {
                var diagnostic = string.IsNullOrWhiteSpace(DBConnection.LastDiagnostic)
                    ? "Unexpected database connection error."
                    : DBConnection.LastDiagnostic;
                var details = string.IsNullOrWhiteSpace(DBConnection.LastError)
                    ? ""
                    : "\n\nDetails: " + DBConnection.LastError;

                var result = MessageBox.Show(
                    "Could not connect to the database.\n\n" +
                    diagnostic + "\n\n" +
                    "Please ensure:\n" +
                    "- XAMPP MySQL is running\n" +
                    "- The 'rentxpress' database exists\n" +
                    "- The connection uses localhost:3306, root, and an empty password\n" +
                    "- MySql.Data and its dependencies are available" +
                    details + "\n\n" +
                    "Continue anyway (UI only)?",
                    "Database Connection Failed",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No) return;
            }

            Application.Run(new MainForm());
        }
    }
}

