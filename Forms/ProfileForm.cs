using System;
using System.Drawing;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RentXpress.Models;
using RentXpress.Services;

namespace RentXpress.Forms
{
    public partial class ProfileForm : Form
    {
        private readonly UserService _userService = new UserService();
        public ProfileForm()
        {
            InitializeComponent();

            if (IsDesignerHosted)
            {
                return;
            }

            LoadProfile();
        }

        private static bool IsDesignerHosted =>
            LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        private void LoadProfile()
        {
            var u = Session.CurrentUser;
            if (u == null)
            {
                return;
            }

            txtFirstName.Text = u.FirstName;
            txtLastName.Text = u.LastName;
            txtEmail.Text = u.Email;
            txtEmail.ReadOnly = true;
            txtPhone.Text = u.Phone;
            txtCompany.Text = u.CompanyName;
            lblAccountType.Text = u.AccountType == "company" ? "Company Account" : "Personal Account";
            lblMemberSince.Text = $"Member since: {u.CreatedAt:MMMM yyyy}";
            lblInitials.Text = $"{u.FirstName[0]}{u.LastName[0]}".ToUpper();
            lblCo.Visible = u.AccountType == "company";
            txtCompany.Visible = u.AccountType == "company";
            // NEW CODE
            // Company accounts must provide payment destinations before listing vehicles.
            // Personal accounts do not receive payments, so the panel stays hidden.
            pnlCompanyPayment.Visible = u.AccountType == "company";
            txtGCashNumber.Text = u.GCashNumber;
            txtGCashName.Text = u.GCashName;
            txtBankName.Text = u.BankName;
            txtBankAccountNumber.Text = u.BankAccountNumber;
            txtBankAccountName.Text = u.BankAccountName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblSuccess.Visible = false;

            string fn = txtFirstName.Text.Trim();
            string ln = txtLastName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            if (string.IsNullOrWhiteSpace(fn) || string.IsNullOrWhiteSpace(ln))
            { ShowError("First and last name are required."); return; }

            // NEW CODE
            // Payment details are required because renters need a real destination for
            // GCash and bank transfer payments before the company can list vehicles.
            if (Session.CurrentUser.AccountType == "company" && !CompanyPaymentDetailsAreComplete())
            {
                ShowError("Company accounts must complete all GCash and bank payment details.");
                return;
            }

            try
            {
                var u = Session.CurrentUser;
                u.FirstName = fn;
                u.LastName = ln;
                u.Phone = phone;
                u.CompanyName = txtCompany.Text.Trim();
                // NEW CODE
                u.GCashNumber = txtGCashNumber.Text.Trim();
                u.GCashName = txtGCashName.Text.Trim();
                u.BankName = txtBankName.Text.Trim();
                u.BankAccountNumber = txtBankAccountNumber.Text.Trim();
                u.BankAccountName = txtBankAccountName.Text.Trim();

                _userService.UpdateProfile(u);
                lblInitials.Text = $"{fn[0]}{ln[0]}".ToUpper();
                MessageBox.Show(
                    "Profile updated successfully!",
                    "Profile Update",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );

            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblSuccess.Visible = false;

            string np = txtNewPassword.Text;
            string cp = txtConfirmPassword.Text;

            if (np.Length < 6) { ShowError("New password must be at least 6 characters."); return; }
            if (np != cp) { ShowError("Passwords do not match."); return; }

            try
            {
                _userService.UpdatePassword(Session.CurrentUser.Id, np);
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
                ShowSuccess("Password changed successfully!");
            }
            catch (Exception ex) { ShowError(ex.Message); }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        // NEW CODE
        private bool CompanyPaymentDetailsAreComplete()
        {
            return !string.IsNullOrWhiteSpace(txtGCashNumber.Text) &&
                   !string.IsNullOrWhiteSpace(txtGCashName.Text) &&
                   !string.IsNullOrWhiteSpace(txtBankName.Text) &&
                   !string.IsNullOrWhiteSpace(txtBankAccountNumber.Text) &&
                   !string.IsNullOrWhiteSpace(txtBankAccountName.Text);
        }

        private void ShowError(string msg) { lblError.Text = msg; lblError.Visible = true; }
        private void ShowSuccess(string msg) { lblSuccess.Text = msg; lblSuccess.Visible = true; }

        private void lblCo_Click(object sender, EventArgs e)
        {

        }

        private void lblInitials_Click(object sender, EventArgs e)
        {

        }
    }
}


