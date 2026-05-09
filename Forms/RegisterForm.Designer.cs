using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlNav;
        private Button btnBack;
        private Panel pnlPersonalCard;
        private Panel pnlCompanyCard;
        private Panel pnlFormCard;
        private Panel pnlCompany;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblPersonalTitle;
        private Label lblPersonalDesc;
        private Label lblCompanyTitle;
        private Label lblCompanyDesc;
        private Label lblFormTitle;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConfirm;
        private TextBox txtConfirm;
        private Label lblCompanyNameLbl;
        private TextBox txtCompanyName;
        private Label lblError;
        private Button btnRegister;
        private Label lblHaveAccount;
        private LinkLabel lnkLogin;

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
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlPersonalCard = new System.Windows.Forms.Panel();
            this.lblPersonalTitle = new System.Windows.Forms.Label();
            this.lblPersonalDesc = new System.Windows.Forms.Label();
            this.pnlCompanyCard = new System.Windows.Forms.Panel();
            this.lblCompanyTitle = new System.Windows.Forms.Label();
            this.lblCompanyDesc = new System.Windows.Forms.Label();
            this.pnlFormCard = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.pnlCompany = new System.Windows.Forms.Panel();
            this.lblCompanyNameLbl = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblHaveAccount = new System.Windows.Forms.Label();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.navText = new System.Windows.Forms.Label();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnlContent.SuspendLayout();
            this.pnlPersonalCard.SuspendLayout();
            this.pnlCompanyCard.SuspendLayout();
            this.pnlFormCard.SuspendLayout();
            this.pnlCompany.SuspendLayout();
            this.pnlNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.AutoScroll = true;
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnlContent.Controls.Add(this.btnBack);
            this.pnlContent.Controls.Add(this.lblTitle);
            this.pnlContent.Controls.Add(this.lblSubtitle);
            this.pnlContent.Controls.Add(this.pnlPersonalCard);
            this.pnlContent.Controls.Add(this.pnlCompanyCard);
            this.pnlContent.Controls.Add(this.pnlFormCard);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 81);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Padding = new System.Windows.Forms.Padding(50, 25, 50, 25);
            this.pnlContent.Size = new System.Drawing.Size(1414, 919);
            this.pnlContent.TabIndex = 0;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(484, 25);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(311, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create an Account";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSubtitle.Location = new System.Drawing.Point(526, 82);
            this.lblSubtitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(242, 21);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Choose how you\'d like to register";
            // 
            // pnlPersonalCard
            // 
            this.pnlPersonalCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlPersonalCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPersonalCard.Controls.Add(this.lblPersonalTitle);
            this.pnlPersonalCard.Controls.Add(this.lblPersonalDesc);
            this.pnlPersonalCard.Location = new System.Drawing.Point(325, 125);
            this.pnlPersonalCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPersonalCard.Name = "pnlPersonalCard";
            this.pnlPersonalCard.Size = new System.Drawing.Size(324, 200);
            this.pnlPersonalCard.TabIndex = 2;
            this.pnlPersonalCard.Click += new System.EventHandler(this.btnPersonal_Click);
            this.pnlPersonalCard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPersonalCard_Paint);
            // 
            // lblPersonalTitle
            // 
            this.lblPersonalTitle.AutoSize = true;
            this.lblPersonalTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPersonalTitle.ForeColor = System.Drawing.Color.White;
            this.lblPersonalTitle.Location = new System.Drawing.Point(25, 25);
            this.lblPersonalTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonalTitle.Name = "lblPersonalTitle";
            this.lblPersonalTitle.Size = new System.Drawing.Size(214, 32);
            this.lblPersonalTitle.TabIndex = 0;
            this.lblPersonalTitle.Text = "Personal Account";
            this.lblPersonalTitle.Click += new System.EventHandler(this.lblPersonalTitle_Click);
            // 
            // lblPersonalDesc
            // 
            this.lblPersonalDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPersonalDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblPersonalDesc.Location = new System.Drawing.Point(25, 75);
            this.lblPersonalDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonalDesc.Name = "lblPersonalDesc";
            this.lblPersonalDesc.Size = new System.Drawing.Size(275, 112);
            this.lblPersonalDesc.TabIndex = 1;
            this.lblPersonalDesc.Text = "For individuals looking to rent vehicles\r\n\r\nBrowse and book vehicles";
            this.lblPersonalDesc.Click += new System.EventHandler(this.lblPersonalDesc_Click);
            // 
            // pnlCompanyCard
            // 
            this.pnlCompanyCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlCompanyCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCompanyCard.Controls.Add(this.lblCompanyTitle);
            this.pnlCompanyCard.Controls.Add(this.lblCompanyDesc);
            this.pnlCompanyCard.Location = new System.Drawing.Point(675, 125);
            this.pnlCompanyCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCompanyCard.Name = "pnlCompanyCard";
            this.pnlCompanyCard.Size = new System.Drawing.Size(324, 200);
            this.pnlCompanyCard.TabIndex = 3;
            this.pnlCompanyCard.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // lblCompanyTitle
            // 
            this.lblCompanyTitle.AutoSize = true;
            this.lblCompanyTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCompanyTitle.ForeColor = System.Drawing.Color.White;
            this.lblCompanyTitle.Location = new System.Drawing.Point(25, 25);
            this.lblCompanyTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompanyTitle.Name = "lblCompanyTitle";
            this.lblCompanyTitle.Size = new System.Drawing.Size(224, 32);
            this.lblCompanyTitle.TabIndex = 0;
            this.lblCompanyTitle.Text = "Company Account";
            this.lblCompanyTitle.Click += new System.EventHandler(this.lblCompanyTitle_Click);
            // 
            // lblCompanyDesc
            // 
            this.lblCompanyDesc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCompanyDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCompanyDesc.Location = new System.Drawing.Point(25, 75);
            this.lblCompanyDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompanyDesc.Name = "lblCompanyDesc";
            this.lblCompanyDesc.Size = new System.Drawing.Size(275, 112);
            this.lblCompanyDesc.TabIndex = 1;
            this.lblCompanyDesc.Text = "For businesses offering vehicle rentals\r\n\r\nList your vehicles";
            this.lblCompanyDesc.Click += new System.EventHandler(this.lblCompanyDesc_Click);
            // 
            // pnlFormCard
            // 
            this.pnlFormCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlFormCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormCard.Controls.Add(this.lblFormTitle);
            this.pnlFormCard.Controls.Add(this.lblFirstName);
            this.pnlFormCard.Controls.Add(this.txtFirstName);
            this.pnlFormCard.Controls.Add(this.lblLastName);
            this.pnlFormCard.Controls.Add(this.txtLastName);
            this.pnlFormCard.Controls.Add(this.lblEmail);
            this.pnlFormCard.Controls.Add(this.txtEmail);
            this.pnlFormCard.Controls.Add(this.lblPhone);
            this.pnlFormCard.Controls.Add(this.txtPhone);
            this.pnlFormCard.Controls.Add(this.lblPassword);
            this.pnlFormCard.Controls.Add(this.txtPassword);
            this.pnlFormCard.Controls.Add(this.lblConfirm);
            this.pnlFormCard.Controls.Add(this.txtConfirm);
            this.pnlFormCard.Controls.Add(this.pnlCompany);
            this.pnlFormCard.Controls.Add(this.lblError);
            this.pnlFormCard.Controls.Add(this.btnRegister);
            this.pnlFormCard.Controls.Add(this.lblHaveAccount);
            this.pnlFormCard.Controls.Add(this.lnkLogin);
            this.pnlFormCard.Location = new System.Drawing.Point(312, 362);
            this.pnlFormCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFormCard.Name = "pnlFormCard";
            this.pnlFormCard.Size = new System.Drawing.Size(750, 537);
            this.pnlFormCard.TabIndex = 4;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(269, 31);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(258, 32);
            this.lblFormTitle.TabIndex = 0;
            this.lblFormTitle.Text = "Personal Registration";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFirstName.ForeColor = System.Drawing.Color.White;
            this.lblFirstName.Location = new System.Drawing.Point(25, 88);
            this.lblFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(86, 21);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtFirstName.ForeColor = System.Drawing.Color.White;
            this.txtFirstName.Location = new System.Drawing.Point(25, 115);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(324, 29);
            this.txtFirstName.TabIndex = 2;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLastName.ForeColor = System.Drawing.Color.White;
            this.lblLastName.Location = new System.Drawing.Point(388, 88);
            this.lblLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(84, 21);
            this.lblLastName.TabIndex = 3;
            this.lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtLastName.ForeColor = System.Drawing.Color.White;
            this.txtLastName.Location = new System.Drawing.Point(388, 115);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(324, 29);
            this.txtLastName.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(25, 169);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 21);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(25, 196);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(324, 29);
            this.txtEmail.TabIndex = 6;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPhone.ForeColor = System.Drawing.Color.White;
            this.lblPhone.Location = new System.Drawing.Point(388, 169);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(54, 21);
            this.lblPhone.TabIndex = 7;
            this.lblPhone.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPhone.ForeColor = System.Drawing.Color.White;
            this.txtPhone.Location = new System.Drawing.Point(388, 196);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(324, 29);
            this.txtPhone.TabIndex = 8;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(25, 250);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(76, 21);
            this.lblPassword.TabIndex = 9;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(25, 278);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(324, 29);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblConfirm.ForeColor = System.Drawing.Color.White;
            this.lblConfirm.Location = new System.Drawing.Point(388, 250);
            this.lblConfirm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(137, 21);
            this.lblConfirm.TabIndex = 11;
            this.lblConfirm.Text = "Confirm Password";
            // 
            // txtConfirm
            // 
            this.txtConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirm.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtConfirm.ForeColor = System.Drawing.Color.White;
            this.txtConfirm.Location = new System.Drawing.Point(388, 278);
            this.txtConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(324, 29);
            this.txtConfirm.TabIndex = 12;
            this.txtConfirm.UseSystemPasswordChar = true;
            // 
            // pnlCompany
            // 
            this.pnlCompany.BackColor = System.Drawing.Color.Transparent;
            this.pnlCompany.Controls.Add(this.lblCompanyNameLbl);
            this.pnlCompany.Controls.Add(this.txtCompanyName);
            this.pnlCompany.Location = new System.Drawing.Point(25, 331);
            this.pnlCompany.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCompany.Name = "pnlCompany";
            this.pnlCompany.Size = new System.Drawing.Size(700, 75);
            this.pnlCompany.TabIndex = 13;
            this.pnlCompany.Visible = false;
            // 
            // lblCompanyNameLbl
            // 
            this.lblCompanyNameLbl.AutoSize = true;
            this.lblCompanyNameLbl.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCompanyNameLbl.ForeColor = System.Drawing.Color.White;
            this.lblCompanyNameLbl.Location = new System.Drawing.Point(0, 0);
            this.lblCompanyNameLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompanyNameLbl.Name = "lblCompanyNameLbl";
            this.lblCompanyNameLbl.Size = new System.Drawing.Size(123, 21);
            this.lblCompanyNameLbl.TabIndex = 0;
            this.lblCompanyNameLbl.Text = "Company Name";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCompanyName.ForeColor = System.Drawing.Color.White;
            this.txtCompanyName.Location = new System.Drawing.Point(0, 28);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(687, 29);
            this.txtCompanyName.TabIndex = 1;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblError.Location = new System.Drawing.Point(25, 409);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(688, 25);
            this.lblError.TabIndex = 14;
            this.lblError.Visible = false;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(25, 438);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(688, 52);
            this.btnRegister.TabIndex = 15;
            this.btnRegister.Text = "Create Account";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblHaveAccount
            // 
            this.lblHaveAccount.AutoSize = true;
            this.lblHaveAccount.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblHaveAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHaveAccount.Location = new System.Drawing.Point(212, 500);
            this.lblHaveAccount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHaveAccount.Name = "lblHaveAccount";
            this.lblHaveAccount.Size = new System.Drawing.Size(186, 21);
            this.lblHaveAccount.TabIndex = 16;
            this.lblHaveAccount.Text = "Already have an account?";
            // 
            // lnkLogin
            // 
            this.lnkLogin.AutoSize = true;
            this.lnkLogin.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lnkLogin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.lnkLogin.Location = new System.Drawing.Point(450, 500);
            this.lnkLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(49, 21);
            this.lnkLogin.TabIndex = 17;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Login";
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            // 
            // navText
            // 
            this.navText.AutoSize = true;
            this.navText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.navText.ForeColor = System.Drawing.Color.White;
            this.navText.Location = new System.Drawing.Point(23, 28);
            this.navText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.navText.Name = "navText";
            this.navText.Size = new System.Drawing.Size(142, 32);
            this.navText.TabIndex = 1;
            this.navText.Text = "RentXpress";
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlNav.Controls.Add(this.navText);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(1414, 81);
            this.pnlNav.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnBack.Location = new System.Drawing.Point(29, 8);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 32);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(1414, 1000);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlNav);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RentXpress - Register";
            this.Resize += new System.EventHandler(this.RegisterForm_Resize);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.pnlPersonalCard.ResumeLayout(false);
            this.pnlPersonalCard.PerformLayout();
            this.pnlCompanyCard.ResumeLayout(false);
            this.pnlCompanyCard.PerformLayout();
            this.pnlFormCard.ResumeLayout(false);
            this.pnlFormCard.PerformLayout();
            this.pnlCompany.ResumeLayout(false);
            this.pnlCompany.PerformLayout();
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel pnlContent;
        private Label navText;
    }
}

