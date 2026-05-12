using System;
using System.Drawing;
using System.Windows.Forms;
using RentXpress.Models;
using RentXpress.Services;

namespace RentXpress.Forms
{
    public partial class VehicleDetailForm : Form
    {
        private readonly Vehicle _vehicle;
        private readonly MainForm _mainForm;

        public VehicleDetailForm()
        {
            InitializeComponent();
        }

        public VehicleDetailForm(Vehicle vehicle, MainForm mainForm)
        {
            _vehicle = vehicle;
            _mainForm = mainForm;
            InitializeComponent();
            PopulateData();
        }

        private void PopulateData()
        {
            this.Text = $"RentXpress - {_vehicle.Name}";
            lblName.Text = _vehicle.Name;
            lblType.Text = _vehicle.Type;
            lblPrice.Text = _vehicle.PriceDisplay;
            lblRating.Text = $" {_vehicle.Rating:F1} ({_vehicle.ReviewCount:N0} reviews)";
            lblSeats.Text = $" {_vehicle.Seats} Seats";
            lblFuel.Text = $" {_vehicle.FuelType}";
            lblTrans.Text = $" {_vehicle.Transmission}";
            lblStatus.Text = $" {_vehicle.Status}";
            lblStatus.ForeColor = _vehicle.Status == "available" ? AppTheme.Accent : AppTheme.DangerColor;
            
            // Show the vehicle's current/base location so renters know where pickup starts.
            lblStatus.Text += string.IsNullOrWhiteSpace(_vehicle.CurrentLocation) ? "" : $" | Location: {_vehicle.CurrentLocation}";
            lblDescription.Text = string.IsNullOrEmpty(_vehicle.Description) ? "No description available." : _vehicle.Description;

            picVehicle.Image = VehicleImageHelper.ImageFromBytes(_vehicle.ImageData);
            picVehicle.Visible = picVehicle.Image != null;
            // Owner info
            lblOwnerName.Text = _vehicle.OwnerName;
            lblOwnerEmail.Text = _vehicle.OwnerEmail;
            lblOwnerPhone.Text = _vehicle.OwnerPhone;

            // Tags
            foreach (var tag in (_vehicle.Tags ?? "").Split(','))
            {
                if (string.IsNullOrWhiteSpace(tag)) continue;
                var lbl = new Label
                {
                    Text = tag.Trim(),
                    Font = AppTheme.FontSmall,
                    ForeColor = AppTheme.TextPrimary,
                    BackColor = AppTheme.Accent,
                    AutoSize = true,
                    Padding = new Padding(8, 3, 8, 3),
                    Margin = new Padding(3)
                };
                flpTags.Controls.Add(lbl);
            }
        }

        private void btnInquiry_Click(object sender, EventArgs e)
        {
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("Please log in to send an inquiry.", "Login Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var dlg = new InquiryForm(_vehicle);
            dlg.ShowDialog(this);
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}





