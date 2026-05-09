using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlAvatar;
        private Label lblInitials;
        private Label lblAccountType;
        private Label lblMemberSince;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private Panel pnlCompanyPayment;
        private Label lblPaymentTitle;
        private Label lblPaymentHint;
        private Label lblGCashNumber;
        private TextBox txtGCashNumber;
        private Label lblGCashName;
        private TextBox txtGCashName;
        private Label lblBankName;
        private TextBox txtBankName;
        private Label lblBankAccountNumber;
        private TextBox txtBankAccountNumber;
        private Label lblBankAccountName;
        private TextBox txtBankAccountName;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private Label lblError;
        private Label lblSuccess;
        private Button btnSave;
        private Button btnChangePassword;
        private Button btnClose;

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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCo = new System.Windows.Forms.Label();
            this.pnlCompanyPayment = new System.Windows.Forms.Panel();
            this.lblPaymentTitle = new System.Windows.Forms.Label();
            this.lblPaymentHint = new System.Windows.Forms.Label();
            this.lblGCashNumber = new System.Windows.Forms.Label();
            this.txtGCashNumber = new System.Windows.Forms.TextBox();
            this.lblGCashName = new System.Windows.Forms.Label();
            this.txtGCashName = new System.Windows.Forms.TextBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblBankAccountNumber = new System.Windows.Forms.Label();
            this.txtBankAccountNumber = new System.Windows.Forms.TextBox();
            this.lblBankAccountName = new System.Windows.Forms.Label();
            this.txtBankAccountName = new System.Windows.Forms.TextBox();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.lblInitials = new System.Windows.Forms.Label();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.lblMemberSince = new System.Windows.Forms.Label();
            this.lblPersonal = new System.Windows.Forms.Label();
            this.lblFN = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblLN = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblE = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPh = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.lblSuccess = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.sep = new System.Windows.Forms.Panel();
            this.lblPasswordSection = new System.Windows.Forms.Label();
            this.lblNP = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblCP = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlCompanyPayment.SuspendLayout();
            this.pnlAvatar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnlMain.Controls.Add(this.txtCompany);
            this.pnlMain.Controls.Add(this.lblCo);
            this.pnlMain.Controls.Add(this.pnlCompanyPayment);
            this.pnlMain.Controls.Add(this.pnlAvatar);
            this.pnlMain.Controls.Add(this.lblAccountType);
            this.pnlMain.Controls.Add(this.lblMemberSince);
            this.pnlMain.Controls.Add(this.lblPersonal);
            this.pnlMain.Controls.Add(this.lblFN);
            this.pnlMain.Controls.Add(this.txtFirstName);
            this.pnlMain.Controls.Add(this.lblLN);
            this.pnlMain.Controls.Add(this.txtLastName);
            this.pnlMain.Controls.Add(this.lblE);
            this.pnlMain.Controls.Add(this.txtEmail);
            this.pnlMain.Controls.Add(this.lblPh);
            this.pnlMain.Controls.Add(this.txtPhone);
            this.pnlMain.Controls.Add(this.lblError);
            this.pnlMain.Controls.Add(this.lblSuccess);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.sep);
            this.pnlMain.Controls.Add(this.lblPasswordSection);
            this.pnlMain.Controls.Add(this.lblNP);
            this.pnlMain.Controls.Add(this.txtNewPassword);
            this.pnlMain.Controls.Add(this.lblCP);
            this.pnlMain.Controls.Add(this.txtConfirmPassword);
            this.pnlMain.Controls.Add(this.btnChangePassword);
            this.pnlMain.Controls.Add(this.btnClose);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(38);
            this.pnlMain.Size = new System.Drawing.Size(875, 880);
            this.pnlMain.TabIndex = 0;
            // 
            // txtCompany
            // 
            this.txtCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompany.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCompany.ForeColor = System.Drawing.Color.White;
            this.txtCompany.Location = new System.Drawing.Point(38, 460);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(4);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(768, 29);
            this.txtCompany.TabIndex = 24;
            // 
            // lblCo
            // 
            this.lblCo.AutoSize = true;
            this.lblCo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCo.ForeColor = System.Drawing.Color.White;
            this.lblCo.Location = new System.Drawing.Point(34, 435);
            this.lblCo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCo.Name = "lblCo";
            this.lblCo.Size = new System.Drawing.Size(123, 21);
            this.lblCo.TabIndex = 0;
            this.lblCo.Text = "Company Name";
            this.lblCo.Click += new System.EventHandler(this.lblCo_Click);
            // 
            // pnlCompanyPayment
            // 
            this.pnlCompanyPayment.BackColor = System.Drawing.Color.Transparent;
            this.pnlCompanyPayment.Controls.Add(this.lblPaymentTitle);
            this.pnlCompanyPayment.Controls.Add(this.lblPaymentHint);
            this.pnlCompanyPayment.Controls.Add(this.lblGCashNumber);
            this.pnlCompanyPayment.Controls.Add(this.txtGCashNumber);
            this.pnlCompanyPayment.Controls.Add(this.lblGCashName);
            this.pnlCompanyPayment.Controls.Add(this.txtGCashName);
            this.pnlCompanyPayment.Controls.Add(this.lblBankName);
            this.pnlCompanyPayment.Controls.Add(this.txtBankName);
            this.pnlCompanyPayment.Controls.Add(this.lblBankAccountNumber);
            this.pnlCompanyPayment.Controls.Add(this.txtBankAccountNumber);
            this.pnlCompanyPayment.Controls.Add(this.lblBankAccountName);
            this.pnlCompanyPayment.Controls.Add(this.txtBankAccountName);
            this.pnlCompanyPayment.Location = new System.Drawing.Point(38, 517);
            this.pnlCompanyPayment.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCompanyPayment.Name = "pnlCompanyPayment";
            this.pnlCompanyPayment.Size = new System.Drawing.Size(740, 263);
            this.pnlCompanyPayment.TabIndex = 25;
            // 
            // lblPaymentTitle
            // 
            this.lblPaymentTitle.AutoSize = true;
            this.lblPaymentTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPaymentTitle.ForeColor = System.Drawing.Color.White;
            this.lblPaymentTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPaymentTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentTitle.Name = "lblPaymentTitle";
            this.lblPaymentTitle.Size = new System.Drawing.Size(313, 32);
            this.lblPaymentTitle.TabIndex = 0;
            this.lblPaymentTitle.Text = "Company Payment Details";
            // 
            // lblPaymentHint
            // 
            this.lblPaymentHint.AutoSize = true;
            this.lblPaymentHint.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPaymentHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblPaymentHint.Location = new System.Drawing.Point(0, 28);
            this.lblPaymentHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPaymentHint.Name = "lblPaymentHint";
            this.lblPaymentHint.Size = new System.Drawing.Size(459, 20);
            this.lblPaymentHint.TabIndex = 1;
            this.lblPaymentHint.Text = "Renters will see these details when they proceed to payment in chat.";
            // 
            // lblGCashNumber
            // 
            this.lblGCashNumber.AutoSize = true;
            this.lblGCashNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblGCashNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGCashNumber.ForeColor = System.Drawing.Color.White;
            this.lblGCashNumber.Location = new System.Drawing.Point(-1, 56);
            this.lblGCashNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGCashNumber.Name = "lblGCashNumber";
            this.lblGCashNumber.Size = new System.Drawing.Size(117, 21);
            this.lblGCashNumber.TabIndex = 2;
            this.lblGCashNumber.Text = "GCash Number";
            // 
            // txtGCashNumber
            // 
            this.txtGCashNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtGCashNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGCashNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGCashNumber.ForeColor = System.Drawing.Color.White;
            this.txtGCashNumber.Location = new System.Drawing.Point(0, 81);
            this.txtGCashNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtGCashNumber.Name = "txtGCashNumber";
            this.txtGCashNumber.Size = new System.Drawing.Size(295, 29);
            this.txtGCashNumber.TabIndex = 3;
            // 
            // lblGCashName
            // 
            this.lblGCashName.AutoSize = true;
            this.lblGCashName.BackColor = System.Drawing.Color.Transparent;
            this.lblGCashName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblGCashName.ForeColor = System.Drawing.Color.White;
            this.lblGCashName.Location = new System.Drawing.Point(346, 56);
            this.lblGCashName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGCashName.Name = "lblGCashName";
            this.lblGCashName.Size = new System.Drawing.Size(161, 21);
            this.lblGCashName.TabIndex = 4;
            this.lblGCashName.Text = "GCash Account Name";
            // 
            // txtGCashName
            // 
            this.txtGCashName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtGCashName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGCashName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtGCashName.ForeColor = System.Drawing.Color.White;
            this.txtGCashName.Location = new System.Drawing.Point(350, 81);
            this.txtGCashName.Margin = new System.Windows.Forms.Padding(4);
            this.txtGCashName.Name = "txtGCashName";
            this.txtGCashName.Size = new System.Drawing.Size(295, 29);
            this.txtGCashName.TabIndex = 5;
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.BackColor = System.Drawing.Color.Transparent;
            this.lblBankName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBankName.ForeColor = System.Drawing.Color.White;
            this.lblBankName.Location = new System.Drawing.Point(-1, 130);
            this.lblBankName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(90, 21);
            this.lblBankName.TabIndex = 6;
            this.lblBankName.Text = "Bank Name";
            // 
            // txtBankName
            // 
            this.txtBankName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtBankName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBankName.ForeColor = System.Drawing.Color.White;
            this.txtBankName.Location = new System.Drawing.Point(0, 155);
            this.txtBankName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(190, 29);
            this.txtBankName.TabIndex = 7;
            // 
            // lblBankAccountNumber
            // 
            this.lblBankAccountNumber.AutoSize = true;
            this.lblBankAccountNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblBankAccountNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBankAccountNumber.ForeColor = System.Drawing.Color.White;
            this.lblBankAccountNumber.Location = new System.Drawing.Point(218, 130);
            this.lblBankAccountNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBankAccountNumber.Name = "lblBankAccountNumber";
            this.lblBankAccountNumber.Size = new System.Drawing.Size(117, 21);
            this.lblBankAccountNumber.TabIndex = 8;
            this.lblBankAccountNumber.Text = "Bank Account #";
            // 
            // txtBankAccountNumber
            // 
            this.txtBankAccountNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtBankAccountNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankAccountNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBankAccountNumber.ForeColor = System.Drawing.Color.White;
            this.txtBankAccountNumber.Location = new System.Drawing.Point(222, 155);
            this.txtBankAccountNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtBankAccountNumber.Name = "txtBankAccountNumber";
            this.txtBankAccountNumber.Size = new System.Drawing.Size(190, 29);
            this.txtBankAccountNumber.TabIndex = 9;
            // 
            // lblBankAccountName
            // 
            this.lblBankAccountName.AutoSize = true;
            this.lblBankAccountName.BackColor = System.Drawing.Color.Transparent;
            this.lblBankAccountName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBankAccountName.ForeColor = System.Drawing.Color.White;
            this.lblBankAccountName.Location = new System.Drawing.Point(430, 130);
            this.lblBankAccountName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBankAccountName.Name = "lblBankAccountName";
            this.lblBankAccountName.Size = new System.Drawing.Size(150, 21);
            this.lblBankAccountName.TabIndex = 10;
            this.lblBankAccountName.Text = "Bank Account Name";
            // 
            // txtBankAccountName
            // 
            this.txtBankAccountName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtBankAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankAccountName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBankAccountName.ForeColor = System.Drawing.Color.White;
            this.txtBankAccountName.Location = new System.Drawing.Point(434, 155);
            this.txtBankAccountName.Margin = new System.Windows.Forms.Padding(4);
            this.txtBankAccountName.Name = "txtBankAccountName";
            this.txtBankAccountName.Size = new System.Drawing.Size(195, 29);
            this.txtBankAccountName.TabIndex = 11;
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.pnlAvatar.Controls.Add(this.lblInitials);
            this.pnlAvatar.Location = new System.Drawing.Point(38, 25);
            this.pnlAvatar.Margin = new System.Windows.Forms.Padding(4);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(100, 100);
            this.pnlAvatar.TabIndex = 0;
            // 
            // lblInitials
            // 
            this.lblInitials.AutoSize = true;
            this.lblInitials.BackColor = System.Drawing.Color.Transparent;
            this.lblInitials.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblInitials.ForeColor = System.Drawing.Color.White;
            this.lblInitials.Location = new System.Drawing.Point(16, 24);
            this.lblInitials.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInitials.Name = "lblInitials";
            this.lblInitials.Size = new System.Drawing.Size(73, 50);
            this.lblInitials.TabIndex = 0;
            this.lblInitials.Text = "UX";
            this.lblInitials.Click += new System.EventHandler(this.lblInitials_Click);
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAccountType.ForeColor = System.Drawing.Color.White;
            this.lblAccountType.Location = new System.Drawing.Point(156, 35);
            this.lblAccountType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(170, 32);
            this.lblAccountType.TabIndex = 1;
            this.lblAccountType.Text = "Account Type";
            // 
            // lblMemberSince
            // 
            this.lblMemberSince.AutoSize = true;
            this.lblMemberSince.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMemberSince.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblMemberSince.Location = new System.Drawing.Point(156, 72);
            this.lblMemberSince.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMemberSince.Name = "lblMemberSince";
            this.lblMemberSince.Size = new System.Drawing.Size(108, 21);
            this.lblMemberSince.TabIndex = 2;
            this.lblMemberSince.Text = "Member since";
            // 
            // lblPersonal
            // 
            this.lblPersonal.AutoSize = true;
            this.lblPersonal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPersonal.ForeColor = System.Drawing.Color.White;
            this.lblPersonal.Location = new System.Drawing.Point(38, 144);
            this.lblPersonal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPersonal.Name = "lblPersonal";
            this.lblPersonal.Size = new System.Drawing.Size(257, 32);
            this.lblPersonal.TabIndex = 3;
            this.lblPersonal.Text = "Personal Information";
            // 
            // lblFN
            // 
            this.lblFN.AutoSize = true;
            this.lblFN.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFN.ForeColor = System.Drawing.Color.White;
            this.lblFN.Location = new System.Drawing.Point(38, 184);
            this.lblFN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFN.Name = "lblFN";
            this.lblFN.Size = new System.Drawing.Size(86, 21);
            this.lblFN.TabIndex = 4;
            this.lblFN.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtFirstName.ForeColor = System.Drawing.Color.White;
            this.txtFirstName.Location = new System.Drawing.Point(38, 211);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(368, 29);
            this.txtFirstName.TabIndex = 5;
            // 
            // lblLN
            // 
            this.lblLN.AutoSize = true;
            this.lblLN.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLN.ForeColor = System.Drawing.Color.White;
            this.lblLN.Location = new System.Drawing.Point(438, 184);
            this.lblLN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLN.Name = "lblLN";
            this.lblLN.Size = new System.Drawing.Size(84, 21);
            this.lblLN.TabIndex = 6;
            this.lblLN.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtLastName.ForeColor = System.Drawing.Color.White;
            this.txtLastName.Location = new System.Drawing.Point(438, 211);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(368, 29);
            this.txtLastName.TabIndex = 7;
            // 
            // lblE
            // 
            this.lblE.AutoSize = true;
            this.lblE.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblE.ForeColor = System.Drawing.Color.White;
            this.lblE.Location = new System.Drawing.Point(38, 271);
            this.lblE.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblE.Name = "lblE";
            this.lblE.Size = new System.Drawing.Size(129, 21);
            this.lblE.TabIndex = 8;
            this.lblE.Text = "Email (read-only)";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.ForeColor = System.Drawing.Color.White;
            this.txtEmail.Location = new System.Drawing.Point(38, 299);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(768, 29);
            this.txtEmail.TabIndex = 9;
            // 
            // lblPh
            // 
            this.lblPh.AutoSize = true;
            this.lblPh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPh.ForeColor = System.Drawing.Color.White;
            this.lblPh.Location = new System.Drawing.Point(38, 359);
            this.lblPh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPh.Name = "lblPh";
            this.lblPh.Size = new System.Drawing.Size(116, 21);
            this.lblPh.TabIndex = 10;
            this.lblPh.Text = "Phone Number";
            // 
            // txtPhone
            // 
            this.txtPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPhone.ForeColor = System.Drawing.Color.White;
            this.txtPhone.Location = new System.Drawing.Point(38, 386);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(768, 29);
            this.txtPhone.TabIndex = 11;
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblError.Location = new System.Drawing.Point(30, 620);
            this.lblError.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(769, 25);
            this.lblError.TabIndex = 13;
            this.lblError.Visible = false;
            // 
            // lblSuccess
            // 
            this.lblSuccess.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSuccess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.lblSuccess.Location = new System.Drawing.Point(30, 620);
            this.lblSuccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(769, 25);
            this.lblSuccess.TabIndex = 14;
            this.lblSuccess.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(13, 788);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(250, 50);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // sep
            // 
            this.sep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.sep.Location = new System.Drawing.Point(38, 859);
            this.sep.Margin = new System.Windows.Forms.Padding(4);
            this.sep.Name = "sep";
            this.sep.Size = new System.Drawing.Size(769, 1);
            this.sep.TabIndex = 16;
            // 
            // lblPasswordSection
            // 
            this.lblPasswordSection.AutoSize = true;
            this.lblPasswordSection.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPasswordSection.ForeColor = System.Drawing.Color.White;
            this.lblPasswordSection.Location = new System.Drawing.Point(38, 879);
            this.lblPasswordSection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasswordSection.Name = "lblPasswordSection";
            this.lblPasswordSection.Size = new System.Drawing.Size(214, 32);
            this.lblPasswordSection.TabIndex = 17;
            this.lblPasswordSection.Text = "Change Password";
            // 
            // lblNP
            // 
            this.lblNP.AutoSize = true;
            this.lblNP.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNP.ForeColor = System.Drawing.Color.White;
            this.lblNP.Location = new System.Drawing.Point(38, 919);
            this.lblNP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNP.Name = "lblNP";
            this.lblNP.Size = new System.Drawing.Size(112, 21);
            this.lblNP.TabIndex = 18;
            this.lblNP.Text = "New Password";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNewPassword.ForeColor = System.Drawing.Color.White;
            this.txtNewPassword.Location = new System.Drawing.Point(38, 946);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(368, 29);
            this.txtNewPassword.TabIndex = 19;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCP.ForeColor = System.Drawing.Color.White;
            this.lblCP.Location = new System.Drawing.Point(438, 919);
            this.lblCP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(137, 21);
            this.lblCP.TabIndex = 20;
            this.lblCP.Text = "Confirm Password";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.txtConfirmPassword.Location = new System.Drawing.Point(438, 946);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(368, 29);
            this.txtConfirmPassword.TabIndex = 21;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnChangePassword.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(38, 990);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(250, 50);
            this.btnChangePassword.TabIndex = 22;
            this.btnChangePassword.Text = "Change Password";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(675, 990);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 50);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(875, 880);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RentXpress - My Profile";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlCompanyPayment.ResumeLayout(false);
            this.pnlCompanyPayment.PerformLayout();
            this.pnlAvatar.ResumeLayout(false);
            this.pnlAvatar.PerformLayout();
            this.ResumeLayout(false);

        }

        private Panel pnlMain;
        private Label lblPersonal;
        private Label lblFN;
        private Label lblLN;
        private Label lblE;
        private Label lblPh;
        private Panel sep;
        private Label lblPasswordSection;
        private Label lblNP;
        private Label lblCP;
        private Label lblCo;
        private TextBox txtCompany;
    }
}

