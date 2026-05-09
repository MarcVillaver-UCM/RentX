using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlNav;
        private Panel pnlContent;
        private Label lblNavBrand;
        private Button btnHome;
        private Button btnBookings;
        private Button btnAbout;
        private Button btnMyVehicles;
        private Button btnMessages;
        private Button btnLogin;
        private Button btnRegister;
        private Button btnSignOut;
        private Label lblWelcome;

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
            this.lblNavBrand = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnBookings = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnMyVehicles = new System.Windows.Forms.Button();
            this.btnMessages = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlNav.Controls.Add(this.lblNavBrand);
            this.pnlNav.Controls.Add(this.btnHome);
            this.pnlNav.Controls.Add(this.btnBookings);
            this.pnlNav.Controls.Add(this.btnAbout);
            this.pnlNav.Controls.Add(this.btnMyVehicles);
            this.pnlNav.Controls.Add(this.btnMessages);
            this.pnlNav.Controls.Add(this.lblWelcome);
            this.pnlNav.Controls.Add(this.btnLogin);
            this.pnlNav.Controls.Add(this.btnRegister);
            this.pnlNav.Controls.Add(this.btnSignOut);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Margin = new System.Windows.Forms.Padding(4);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(1500, 81);
            this.pnlNav.TabIndex = 1;
            this.pnlNav.Resize += new System.EventHandler(this.pnlNav_Resize);
            // 
            // lblNavBrand
            // 
            this.lblNavBrand.AutoSize = true;
            this.lblNavBrand.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNavBrand.ForeColor = System.Drawing.Color.White;
            this.lblNavBrand.Location = new System.Drawing.Point(34, 26);
            this.lblNavBrand.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNavBrand.Name = "lblNavBrand";
            this.lblNavBrand.Size = new System.Drawing.Size(142, 32);
            this.lblNavBrand.TabIndex = 1;
            this.lblNavBrand.Text = "RentXpress";
            // 
            // btnHome
            // 
            this.btnHome.AutoSize = true;
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnHome.Location = new System.Drawing.Point(257, 22);
            this.btnHome.Margin = new System.Windows.Forms.Padding(4);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(94, 41);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnBookings
            // 
            this.btnBookings.AutoSize = true;
            this.btnBookings.BackColor = System.Drawing.Color.Transparent;
            this.btnBookings.FlatAppearance.BorderSize = 0;
            this.btnBookings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookings.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBookings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnBookings.Location = new System.Drawing.Point(348, 22);
            this.btnBookings.Margin = new System.Windows.Forms.Padding(4);
            this.btnBookings.Name = "btnBookings";
            this.btnBookings.Size = new System.Drawing.Size(111, 41);
            this.btnBookings.TabIndex = 3;
            this.btnBookings.Text = "Bookings";
            this.btnBookings.UseVisualStyleBackColor = false;
            this.btnBookings.Click += new System.EventHandler(this.btnBookings_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.AutoSize = true;
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnAbout.Location = new System.Drawing.Point(710, 22);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(94, 41);
            this.btnAbout.TabIndex = 4;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnMyVehicles
            // 
            this.btnMyVehicles.AutoSize = true;
            this.btnMyVehicles.BackColor = System.Drawing.Color.Transparent;
            this.btnMyVehicles.FlatAppearance.BorderSize = 0;
            this.btnMyVehicles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyVehicles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMyVehicles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnMyVehicles.Location = new System.Drawing.Point(454, 22);
            this.btnMyVehicles.Margin = new System.Windows.Forms.Padding(4);
            this.btnMyVehicles.Name = "btnMyVehicles";
            this.btnMyVehicles.Size = new System.Drawing.Size(136, 41);
            this.btnMyVehicles.TabIndex = 5;
            this.btnMyVehicles.Text = "My Vehicles";
            this.btnMyVehicles.UseVisualStyleBackColor = false;
            this.btnMyVehicles.Visible = false;
            this.btnMyVehicles.Click += new System.EventHandler(this.btnMyVehicles_Click);
            // 
            // btnMessages
            // 
            this.btnMessages.AutoSize = true;
            this.btnMessages.BackColor = System.Drawing.Color.Transparent;
            this.btnMessages.FlatAppearance.BorderSize = 0;
            this.btnMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMessages.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnMessages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.btnMessages.Location = new System.Drawing.Point(598, 22);
            this.btnMessages.Margin = new System.Windows.Forms.Padding(4);
            this.btnMessages.Name = "btnMessages";
            this.btnMessages.Size = new System.Drawing.Size(119, 41);
            this.btnMessages.TabIndex = 6;
            this.btnMessages.Text = "Messages";
            this.btnMessages.UseVisualStyleBackColor = false;
            this.btnMessages.Visible = false;
            this.btnMessages.Click += new System.EventHandler(this.btnMessages_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.lblWelcome.Location = new System.Drawing.Point(996, 30);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(74, 21);
            this.lblWelcome.TabIndex = 5;
            this.lblWelcome.Text = "Welcome";
            this.lblWelcome.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(1245, 22);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(94, 41);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(1362, 19);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(112, 42);
            this.btnRegister.TabIndex = 7;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnSignOut
            // 
            this.btnSignOut.AutoSize = true;
            this.btnSignOut.BackColor = System.Drawing.Color.Transparent;
            this.btnSignOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSignOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnSignOut.Location = new System.Drawing.Point(1362, 22);
            this.btnSignOut.Margin = new System.Windows.Forms.Padding(4);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(116, 44);
            this.btnSignOut.TabIndex = 8;
            this.btnSignOut.Text = "Sign Out";
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Visible = false;
            this.btnSignOut.Click += new System.EventHandler(this.btnSignOut_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 81);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1500, 919);
            this.pnlContent.TabIndex = 0;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(1500, 1000);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlNav);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1120, 738);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RentXpress - Find Your Perfect Ride";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}




