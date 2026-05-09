using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlNav;
        private Label lblLogoText;
        private Button btnBack;
        private Panel pnlCard;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlAccountType;
        private Button btnCustomerLogin;
        private Button btnCompanyLogin;
        private Label lblEmailLbl;
        private TextBox txtEmail;
        private Label lblPasswordLbl;
        private TextBox txtPassword;
        // MODIFIED CODE
        // This checkbox is now only for showing/hiding the typed password.
        private CheckBox chkShowPassword;
        private LinkLabel lnkForgot;
        private Button btnSignIn;
        private Label lblError;
        private Label lblNoAccount;
        private LinkLabel lnkSignUp;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblLogoText = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlAccountType = new System.Windows.Forms.Panel();
            this.btnCustomerLogin = new System.Windows.Forms.Button();
            this.btnCompanyLogin = new System.Windows.Forms.Button();
            this.lblEmailLbl = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPasswordLbl = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.lnkForgot = new System.Windows.Forms.LinkLabel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lblNoAccount = new System.Windows.Forms.Label();
            this.lnkSignUp = new System.Windows.Forms.LinkLabel();
            this.pnlNav.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.pnlAccountType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlNav.Controls.Add(this.lblLogoText);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(1375, 81);
            this.pnlNav.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnBack.Location = new System.Drawing.Point(33, 89);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 32);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblLogoText
            // 
            this.lblLogoText.AutoSize = true;
            this.lblLogoText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogoText.ForeColor = System.Drawing.Color.White;
            this.lblLogoText.Location = new System.Drawing.Point(27, 26);
            this.lblLogoText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogoText.Name = "lblLogoText";
            this.lblLogoText.Size = new System.Drawing.Size(142, 32);
            this.lblLogoText.TabIndex = 1;
            this.lblLogoText.Text = "RentXpress";
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblSubtitle);
            this.pnlCard.Controls.Add(this.pnlAccountType);
            this.pnlCard.Controls.Add(this.lblEmailLbl);
            this.pnlCard.Controls.Add(this.txtEmail);
            this.pnlCard.Controls.Add(this.lblPasswordLbl);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.chkShowPassword);
            this.pnlCard.Controls.Add(this.lnkForgot);
            this.pnlCard.Controls.Add(this.lblError);
            this.pnlCard.Controls.Add(this.btnSignIn);
            this.pnlCard.Controls.Add(this.lblNoAccount);
            this.pnlCard.Controls.Add(this.lnkSignUp);
            this.pnlCard.Location = new System.Drawing.Point(412, 162);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(550, 650);
            this.pnlCard.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(138, 62);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(251, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Welcome Back";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSubtitle.Location = new System.Drawing.Point(119, 119);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(252, 21);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Sign in to your account to continue";
            // 
            // pnlAccountType
            // 
            this.pnlAccountType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.pnlAccountType.Controls.Add(this.btnCustomerLogin);
            this.pnlAccountType.Controls.Add(this.btnCompanyLogin);
            this.pnlAccountType.Location = new System.Drawing.Point(50, 165);
            this.pnlAccountType.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAccountType.Name = "pnlAccountType";
            this.pnlAccountType.Size = new System.Drawing.Size(450, 46);
            this.pnlAccountType.TabIndex = 2;
            // 
            // btnCustomerLogin
            // 
            this.btnCustomerLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnCustomerLogin.FlatAppearance.BorderSize = 0;
            this.btnCustomerLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerLogin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCustomerLogin.ForeColor = System.Drawing.Color.White;
            this.btnCustomerLogin.Location = new System.Drawing.Point(4, 4);
            this.btnCustomerLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnCustomerLogin.Name = "btnCustomerLogin";
            this.btnCustomerLogin.Size = new System.Drawing.Size(220, 38);
            this.btnCustomerLogin.TabIndex = 0;
            this.btnCustomerLogin.Text = "Customer / Personal";
            this.btnCustomerLogin.UseVisualStyleBackColor = false;
            this.btnCustomerLogin.Click += new System.EventHandler(this.btnCustomerLogin_Click);
            // 
            // btnCompanyLogin
            // 
            this.btnCompanyLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnCompanyLogin.FlatAppearance.BorderSize = 0;
            this.btnCompanyLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompanyLogin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCompanyLogin.ForeColor = System.Drawing.Color.White;
            this.btnCompanyLogin.Location = new System.Drawing.Point(226, 4);
            this.btnCompanyLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnCompanyLogin.Name = "btnCompanyLogin";
            this.btnCompanyLogin.Size = new System.Drawing.Size(220, 38);
            this.btnCompanyLogin.TabIndex = 1;
            this.btnCompanyLogin.Text = "Company / Owner";
            this.btnCompanyLogin.UseVisualStyleBackColor = false;
            this.btnCompanyLogin.Click += new System.EventHandler(this.btnCompanyLogin_Click);
            // 
            // lblEmailLbl
            // 
            this.lblEmailLbl.AutoSize = true;
            this.lblEmailLbl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmailLbl.ForeColor = System.Drawing.Color.White;
            this.lblEmailLbl.Location = new System.Drawing.Point(50, 238);
            this.lblEmailLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailLbl.Name = "lblEmailLbl";
            this.lblEmailLbl.Size = new System.Drawing.Size(48, 21);
            this.lblEmailLbl.TabIndex = 3;
            this.lblEmailLbl.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(50, 269);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(450, 29);
            this.txtEmail.TabIndex = 4;
            // 
            // lblPasswordLbl
            // 
            this.lblPasswordLbl.AutoSize = true;
            this.lblPasswordLbl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPasswordLbl.ForeColor = System.Drawing.Color.White;
            this.lblPasswordLbl.Location = new System.Drawing.Point(50, 332);
            this.lblPasswordLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasswordLbl.Name = "lblPasswordLbl";
            this.lblPasswordLbl.Size = new System.Drawing.Size(76, 21);
            this.lblPasswordLbl.TabIndex = 5;
            this.lblPasswordLbl.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(50, 363);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(450, 29);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.chkShowPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.chkShowPassword.Location = new System.Drawing.Point(50, 432);
            this.chkShowPassword.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(141, 25);
            this.chkShowPassword.TabIndex = 7;
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.UseVisualStyleBackColor = false;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // lnkForgot
            // 
            this.lnkForgot.AutoSize = true;
            this.lnkForgot.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lnkForgot.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.lnkForgot.Location = new System.Drawing.Point(356, 432);
            this.lnkForgot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkForgot.Name = "lnkForgot";
            this.lnkForgot.Size = new System.Drawing.Size(134, 21);
            this.lnkForgot.TabIndex = 8;
            this.lnkForgot.TabStop = true;
            this.lnkForgot.Text = "Forgot password?";
            this.lnkForgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgot_LinkClicked);
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblError.Location = new System.Drawing.Point(50, 482);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(450, 25);
            this.lblError.TabIndex = 9;
            this.lblError.Visible = false;
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnSignIn.FlatAppearance.BorderSize = 0;
            this.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignIn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSignIn.ForeColor = System.Drawing.Color.White;
            this.btnSignIn.Location = new System.Drawing.Point(50, 519);
            this.btnSignIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(450, 52);
            this.btnSignIn.TabIndex = 10;
            this.btnSignIn.Text = "Sign In as Customer";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // lblNoAccount
            // 
            this.lblNoAccount.AutoSize = true;
            this.lblNoAccount.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNoAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblNoAccount.Location = new System.Drawing.Point(125, 588);
            this.lblNoAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNoAccount.Name = "lblNoAccount";
            this.lblNoAccount.Size = new System.Drawing.Size(171, 21);
            this.lblNoAccount.TabIndex = 11;
            this.lblNoAccount.Text = "Don\'t have an account?";
            // 
            // lnkSignUp
            // 
            this.lnkSignUp.AutoSize = true;
            this.lnkSignUp.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lnkSignUp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.lnkSignUp.Location = new System.Drawing.Point(338, 588);
            this.lnkSignUp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkSignUp.Name = "lnkSignUp";
            this.lnkSignUp.Size = new System.Drawing.Size(63, 21);
            this.lnkSignUp.TabIndex = 12;
            this.lnkSignUp.TabStop = true;
            this.lnkSignUp.Text = "Sign up";
            this.lnkSignUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSignUp_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(1375, 875);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlNav);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(996, 738);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RentXpress - Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Resize += new System.EventHandler(this.LoginForm_Resize);
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlAccountType.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}

