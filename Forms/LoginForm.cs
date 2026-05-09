using System;
using System.Windows.Forms;
using RentXpress.Services;

namespace RentXpress.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService = new UserService();
        private string _selectedAccountType = "personal";

        public bool OpenRegisterRequested { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            HighlightAccountType();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ShowError("Please enter both email and password.");
                return;
            }

            btnSignIn.Enabled = false;
            btnSignIn.Text = $"Signing in as {SelectedAccountLabel}...";

            try
            {
                var user = _userService.Login(email, password, _selectedAccountType);
                if (user != null)
                {
                    Session.Login(user);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    ShowError($"Invalid {SelectedAccountLabel.ToLower()} email or password. Please try again.");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
            finally
            {
                btnSignIn.Enabled = true;
                UpdateSignInText();
            }
        }

        private string SelectedAccountLabel => _selectedAccountType == "company" ? "Company" : "Customer";

        private void btnCustomerLogin_Click(object sender, EventArgs e)
        {
            _selectedAccountType = "personal";
            HighlightAccountType();
        }

        private void btnCompanyLogin_Click(object sender, EventArgs e)
        {
            _selectedAccountType = "company";
            HighlightAccountType();
        }

        private void HighlightAccountType()
        {
            if (btnCustomerLogin == null || btnCompanyLogin == null) return;

            bool personal = _selectedAccountType == "personal";
            btnCustomerLogin.BackColor = personal ? AppTheme.Accent : AppTheme.BgInput;
            btnCustomerLogin.ForeColor = AppTheme.TextPrimary;
            btnCompanyLogin.BackColor = personal ? AppTheme.BgInput : AppTheme.Accent;
            btnCompanyLogin.ForeColor = AppTheme.TextPrimary;
            UpdateSignInText();
        }

        private void UpdateSignInText()
        {
            if (btnSignIn != null) btnSignIn.Text = $"Sign In as {SelectedAccountLabel}";
        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenRegisterRequested = true;
            DialogResult = DialogResult.Retry;
            Close();
        }

        private void lnkForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Password reset is not implemented in this demo.\nPlease contact support.",
                "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSignIn_Click(sender, e);
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            CenterCard();
        }

        private void LoginForm_Resize(object sender, EventArgs e)
        {
            CenterCard();
        }

        private void CenterCard()
        {
            if (pnlCard == null || pnlNav == null) return;
            int navH = pnlNav.Height;
            pnlCard.Location = new System.Drawing.Point(
                (this.ClientSize.Width - pnlCard.Width) / 2,
                navH + (this.ClientSize.Height - navH - pnlCard.Height) / 2);
        }

        private void btnBack_Click(object sender, EventArgs e) => Close();


        // MODIFIED CODE
        // This used to be an unused Remember Me handler. It now toggles password masking
        // in real time so users can check their password while typing.
        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}


