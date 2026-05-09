using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RentXpress.Models;
using RentXpress.Services;

namespace RentXpress.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly UserService _userService = new UserService();
        private string _selectedAccountType = "personal";

        public bool OpenLoginRequested { get; private set; }

        public RegisterForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            CenterContent();
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            _selectedAccountType = "personal";
            HighlightAccountType("personal");
            pnlCompany.Visible = false;
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            _selectedAccountType = "company";
            HighlightAccountType("company");
            pnlCompany.Visible = true;
        }

        private void HighlightAccountType(string type)
        {
            pnlPersonalCard.BackColor = type == "personal" ? System.Drawing.Color.FromArgb(30, 32, 201, 151) : AppTheme.BgCard;
            pnlPersonalCard.Invalidate();
            pnlCompanyCard.BackColor = type == "company" ? System.Drawing.Color.FromArgb(30, 32, 201, 151) : AppTheme.BgCard;
            pnlCompanyCard.Invalidate();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;

            // Validation
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            { ShowError("Please enter your full name."); return; }

            if (!IsValidEmail(email))
            { ShowError("Please enter a valid email address."); return; }

            if (password.Length < 6)
            { ShowError("Password must be at least 6 characters."); return; }

            if (password != confirm)
            { ShowError("Passwords do not match."); return; }

            if (_selectedAccountType == "company" && string.IsNullOrWhiteSpace(txtCompanyName.Text.Trim()))
            { ShowError("Please enter your company name."); return; }

            btnRegister.Enabled = false;
            btnRegister.Text = "Creating account...";

            try
            {
                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    Phone = phone,
                    CompanyName = _selectedAccountType == "company" ? txtCompanyName.Text.Trim() : ""
                };

                bool ok = _userService.Register(user, password, _selectedAccountType);
                if (ok)
                {
                    MessageBox.Show("Account created successfully! Please log in.",
                        "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OpenLoginRequested = true;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                btnRegister.Enabled = true;
                btnRegister.Text = "Create Account";
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenLoginRequested = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }

        private static bool IsValidEmail(string email) =>
            Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlPersonalCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblPersonalDesc_Click(object sender, EventArgs e)
        {
            _selectedAccountType = "personal";
            HighlightAccountType("personal");
            pnlCompany.Visible = false;
        }

        private void lblPersonalTitle_Click(object sender, EventArgs e)
        {
            _selectedAccountType = "personal";
            HighlightAccountType("personal");
            pnlCompany.Visible = false;
        }

        private void lblCompanyTitle_Click(object sender, EventArgs e)
        {
            _selectedAccountType = "company";
            HighlightAccountType("company");
            pnlCompany.Visible = true;
        }

        private void lblCompanyDesc_Click(object sender, EventArgs e)
        {
            _selectedAccountType = "company";
            HighlightAccountType("company");
            pnlCompany.Visible = true;
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void RegisterForm_Resize(object sender, EventArgs e)
        {
            CenterContent();
        }

        private void btnBack_Click(object sender, EventArgs e) => Close();


        private void CenterContent()
        {
            if (pnlContent == null || pnlFormCard == null) return;

            int contentWidth = pnlContent.ClientSize.Width;
            int left = Math.Max(40, (contentWidth - pnlFormCard.Width) / 2);

            lblTitle.Left = Math.Max(40, (contentWidth - lblTitle.Width) / 2);
            lblSubtitle.Left = Math.Max(40, (contentWidth - lblSubtitle.Width) / 2);

            int cardsWidth = pnlPersonalCard.Width + 20 + pnlCompanyCard.Width;
            int cardsLeft = Math.Max(40, (contentWidth - cardsWidth) / 2);
            pnlPersonalCard.Left = cardsLeft;
            pnlCompanyCard.Left = cardsLeft + pnlPersonalCard.Width + 20;
            pnlFormCard.Left = left;
        }
    }
}

