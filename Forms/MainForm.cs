using System;
using System.Drawing;
using System.Windows.Forms;
using RentXpress.Services;

namespace RentXpress.Forms
{
    public partial class MainForm : Form
    {
        private Panel _currentPanel;
        private readonly InquiryService _inquiryService = new InquiryService();

        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            LoadHome();
        }

        private void LoadHome()
        {
            SetActiveNav("home");
            ShowPanel(new VehicleListPanel(this));
        }

        public void ShowPanel(Control panel)
        {
            pnlContent.Controls.Clear();
            _currentPanel = null;
            panel.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(panel);
            _currentPanel = panel as Panel;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SetActiveNav("home");
            ShowPanel(new VehicleListPanel(this));
        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn) { ShowLoginRequired(); return; }

            // MODIFIED CODE
            // Bookings are renter-facing records, so company accounts should not open this page.
            // Company users handle requests through Messages and vehicle management instead.
            if (Session.CurrentUser.AccountType == "company")
            {
                MessageBox.Show("Bookings are available for personal renter accounts only.", "Personal Account Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SetActiveNav("bookings");
            // MODIFIED CODE
            // Bookings now use their own panel instead of InquiryListPanel. This keeps booking
            // tables separate from the chat/message layout.
            ShowPanel(new BookingListPanel(this));
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            SetActiveNav("about");
            ShowPanel(new AboutPanel());
        }


        private void btnMyVehicles_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn) { ShowLoginRequired(); return; }
            if (Session.CurrentUser.AccountType != "company")
            {
                MessageBox.Show("Only company accounts can manage vehicles.", "Company Account Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // NEW CODE
            // Company owners must provide payout details before listing vehicles. Otherwise a
            // renter could book a car without knowing where to send GCash/bank payment.
            if (!Session.CurrentUser.HasCompanyPaymentDetails)
            {
                MessageBox.Show("Please complete your company payment details in your profile before managing vehicles.",
                    "Payment Details Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                using (var profile = new ProfileForm())
                {
                    profile.ShowDialog(this);
                }
                UpdateUserDisplay();
                if (!Session.CurrentUser.HasCompanyPaymentDetails) return;
            }
            SetActiveNav("vehicles");
            ShowPanel(new VehicleManagePanel(this));
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn) { ShowLoginRequired(); return; }

            // Company accounts read renter messages as owners; personal accounts read their sent conversations.
            bool ownerMode = Session.CurrentUser.AccountType == "company";
            SetActiveNav("messages");
            ShowPanel(new InquiryListPanel(this, ownerMode));
            UpdateMessageBadge();

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Session.IsLoggedIn)
            {
                using (var profile = new ProfileForm())
                {
                    profile.ShowDialog(this);
                }

                UpdateUserDisplay();
                PositionNavRight();
            }
            else
            {
                ShowLoginFlow();

                UpdateUserDisplay();
                PositionNavRight();
            }
        }


        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                ShowRegisterFlow();

                UpdateUserDisplay();
                PositionNavRight();
            }
        }


        private void btnSignOut_Click(object sender, EventArgs e)
        {
            if (Session.IsLoggedIn)
            {
                Session.Logout();
                UpdateUserDisplay();
                ShowPanel(new VehicleListPanel(this));
            }
        }

        public void UpdateUserDisplay()
        {
            if (Session.IsLoggedIn)
            {
                btnLogin.Text = Session.CurrentUser.FirstName;
                btnRegister.Visible = false;
                btnSignOut.Visible = true;
                // MODIFIED CODE
                // AccountType comes from the logged-in user record loaded by UserService.
                // Company users manage vehicles and messages, while personal users view bookings
                // and messages. PositionNavLeft() then lays out only visible buttons.
                bool isCompany = Session.CurrentUser.AccountType == "company";
                btnBookings.Visible = !isCompany;
                btnMyVehicles.Visible = isCompany;
                btnMessages.Visible = true;
                UpdateMessageBadge();
                lblWelcome.Text = $"Welcome, {Session.CurrentUser.FirstName}!";
                lblWelcome.Visible = true;
            }
            else
            {
                btnLogin.Text = "Login";
                btnRegister.Visible = true;
                btnSignOut.Visible = false;
                btnBookings.Visible = true;
                btnMyVehicles.Visible = false;
                btnMessages.Visible = false;
                btnMessages.Text = "Messages";
                lblWelcome.Visible = false;
            }

            // NEW CODE
            PositionNavLeft();
        }


        public void UpdateMessageBadge()
        {
            // At the moment only company owners get a pending-count badge.
            // Personal users still see Messages, but without a count because there is no read/unread table yet.
            if (!Session.IsLoggedIn || Session.CurrentUser.AccountType != "company")
            {
                btnMessages.Text = "Messages";
                return;
            }

            int pending = _inquiryService.CountPendingByOwner(Session.CurrentUser.Id);
            btnMessages.Text = pending > 0 ? $"Messages ({pending})" : "Messages";
            // NEW CODE
            PositionNavLeft();
        }
        private void SetActiveNav(string page)
        {
            btnHome.ForeColor = page == "home" ? AppTheme.Accent : AppTheme.TextSecondary;
            btnBookings.ForeColor = page == "bookings" ? AppTheme.Accent : AppTheme.TextSecondary;
            btnAbout.ForeColor = page == "about" ? AppTheme.Accent : AppTheme.TextSecondary;
            btnMyVehicles.ForeColor = page == "vehicles" ? AppTheme.Accent : AppTheme.TextSecondary;
            btnMessages.ForeColor = page == "messages" ? AppTheme.Accent : AppTheme.TextSecondary;
        }

        private void ShowLoginRequired()
        {
            MessageBox.Show("Please log in to access this feature.", "Login Required",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowLoginFlow()
        {
            while (!Session.IsLoggedIn)
            {
                using (var login = new LoginForm())
                {
                    var result = login.ShowDialog(this);
                    if (result == DialogResult.Retry && login.OpenRegisterRequested)
                    {
                        if (!ShowRegisterFlow()) continue;
                    }
                    break;
                }
            }
        }

        private bool ShowRegisterFlow()
        {
            using (var reg = new RegisterForm())
            {
                reg.ShowDialog(this);
                if (reg.OpenLoginRequested && !Session.IsLoggedIn)
                {
                    ShowLoginFlow();
                    return true;
                }
            }

            return false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateUserDisplay();
            // NEW CODE
            PositionNavLeft();
            PositionNavRight();
        }


        private void pnlNav_Resize(object sender, EventArgs e)
        {
            // NEW CODE
            PositionNavLeft();
            PositionNavRight();
        }

        // NEW CODE
        // Left navigation uses a small flow-style layout. We keep the existing buttons and styling,
        // but calculate their X positions from the previous visible button instead of relying on
        // fixed design-time coordinates. That makes both roles balanced:
        // - Company: Home, About, My Vehicles, Messages
        // - Personal: Home, Bookings, About, Messages
        private void PositionNavLeft()
        {
            if (pnlNav == null) return;

            int x = 190;
            int gap = 18;
            Button[] navButtons = { btnHome, btnBookings, btnAbout, btnMyVehicles, btnMessages };

            foreach (var button in navButtons)
            {
                if (!button.Visible) continue;

                button.Location = new Point(x, 18);
                x += button.Width + gap;
            }
        }

        private void PositionNavRight()
        {
            if (pnlNav == null) return;
            int right = pnlNav.Width - 20;
            btnRegister.Location = new System.Drawing.Point(right - btnRegister.Width, 15);
            btnSignOut.Location = new System.Drawing.Point(right - btnSignOut.Width, 16);
            right -= btnRegister.Width + 10;
            btnLogin.Location = new System.Drawing.Point(right - btnLogin.Width, 18);
            right -= btnLogin.Width + 20;
            if (lblWelcome.Visible)
            {
                lblWelcome.Location = new System.Drawing.Point(right - lblWelcome.Width, 24);
            }
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}






