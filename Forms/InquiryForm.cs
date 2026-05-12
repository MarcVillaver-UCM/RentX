using System;
using System.Drawing;
using System.Windows.Forms;
using RentXpress.Models;
using RentXpress.Services;

namespace RentXpress.Forms
{
    public partial class InquiryForm : Form
    {
        private readonly Vehicle _vehicle;
        private readonly InquiryService _inquiryService = new InquiryService();
        // NEW CODE
        // MODIFIED CODE
        // RentXpress earns 5% per booking. This platform fee is separate from the company
        // owner's amount, so COD cannot bypass the platform's earnings.
        private const decimal PlatformFeeRate = 0.05m;

        public InquiryForm()
        {
            InitializeComponent();
        }

        public InquiryForm(Vehicle vehicle)
        {
            _vehicle = vehicle;
            InitializeComponent();
            lblVehicleName.Text = _vehicle.Name;
            lblOwner.Text = $"Owner: {_vehicle.OwnerName}";
            // NEW CODE
            UpdatePriceSummary();
        }

        private void chkEmergency_CheckedChanged(object sender, EventArgs e)
        {
            // MODIFIED CODE
            // This used to be "Catastrophe Mode." It is now "Urgent Booking" because the feature
            // means the renter wants faster owner attention, not an unrelated disaster workflow.
            pnlEmergency.Visible = chkEmergency.Checked;
            if (chkEmergency.Checked)
            {
                //this.BackColor = Color.FromArgb(35, 20, 20); mopa red sha sa background para sa calamity mode unta ni
                lblEmergencyWarning.Visible = true;
                //btnSend.BackColor = AppTheme.DangerColor; red sa button para sa calamity mode unta ni
                btnSend.Text = "Send Urgent Booking";
            }
            else
            {
                this.BackColor = AppTheme.BgDark;
                lblEmergencyWarning.Visible = false;
                btnSend.BackColor = AppTheme.Accent;
                btnSend.Text = "Send Booking Request";
            }

            UpdatePriceSummary();
        }

        // NEW CODE
        // MODIFIED CODE
        // Calculates the renter-facing booking total. The rental amount is price-per-day
        // multiplied by Number of Days. Platform fee stays separate as RentXpress earnings.
        private void CalculateBookingPrice(out decimal basePrice, out decimal surcharge, out decimal total)
        {
            int numberOfDays = GetNumberOfDays();
            basePrice = (_vehicle?.PricePerDay ?? 0m) * numberOfDays;
            surcharge = decimal.Round(basePrice * PlatformFeeRate, 2);
            total = basePrice + surcharge;
        }

        private void UpdatePriceSummary()
        {
            CalculateBookingPrice(out decimal basePrice, out decimal surcharge, out decimal total);
            int numberOfDays = GetNumberOfDays();
            decimal pricePerDay = _vehicle?.PricePerDay ?? 0m;
            lblBasePrice.Text = $"Rental: PHP {pricePerDay:F2} x {numberOfDays} day(s) = PHP {basePrice:F2}";
            // MODIFIED CODE
            lblSurcharge.Text = $"Platform fee: PHP {surcharge:F2}";
            lblTotalPrice.Text = $"Total: PHP {total:F2}";
        }

        // NEW CODE
        // NumericUpDown already prevents values below 1, but this helper keeps the
        // calculation safe if the control is ever changed or loaded with bad data.
        private int GetNumberOfDays()
        {
            return Math.Max(1, Convert.ToInt32(nudNumberOfDays.Value));
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            string subject = txtSubject.Text.Trim();
            string message = txtMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(subject))
            { ShowError("Please enter a subject."); return; }
            if (message.Length < 10)
            { ShowError("Please enter a message (at least 10 characters)."); return; }
            if (GetNumberOfDays() < 1)
            { ShowError("Number of days must be at least 1."); return; }

            // NEW CODE
            // Renters cannot book a company vehicle until the owner has payment details.
            // This prevents creating a booking that cannot be paid through chat.
            if (!OwnerPaymentDetailsAreComplete())
            {
                ShowError("This company has not completed payment details yet. Please choose another vehicle or try again later.");
                return;
            }

            if (chkEmergency.Checked)
            {
                var confirm = MessageBox.Show(
                    // MODIFIED CODE
                    "Urgent Booking adds a 5% surcharge and flags this request for faster owner review.\n\nContinue?",
                    "Confirm Urgent Booking",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes) return;
            }

            btnSend.Enabled = false;
            try
            {
                // NEW CODE
                // Calculate once immediately before saving so the stored record matches the visible summary.
                CalculateBookingPrice(out decimal basePrice, out decimal surcharge, out decimal total);
                int numberOfDays = GetNumberOfDays();

                var inq = new Inquiry
                {
                    SenderId = Session.CurrentUser.Id,
                    VehicleId = _vehicle.Id,
                    OwnerId = _vehicle.OwnerId,
                    Subject = subject,
                    Message = message,
                    IsEmergency = chkEmergency.Checked,
                    PriorityLevel = chkEmergency.Checked
                        ? (cmbPriority.SelectedItem?.ToString() ?? "high")
                        : "normal",
                    // MODIFIED CODE
                    BasePrice = basePrice,
                    SurchargeAmount = 0m,
                    TotalPrice = total,
                    NumberOfDays = numberOfDays,
                    TotalAmount = total,
                    PlatformFee = surcharge,
                    OwnerAmount = basePrice,
                    PaymentMethod = cmbPaymentMethod.SelectedItem?.ToString() ?? "Cash",
                    PaymentStatus = "Pending"
                };

                _inquiryService.Send(inq);
                MessageBox.Show(
                    chkEmergency.Checked
                        ? $"Urgent booking sent successfully!\nDays: {numberOfDays}\nTotal: PHP {total:F2}\nPayment: {inq.PaymentMethod} ({inq.PaymentStatus})"
                        : $"Booking request sent successfully!\nDays: {numberOfDays}\nTotal: PHP {total:F2}\nPayment: {inq.PaymentMethod} ({inq.PaymentStatus})",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
                btnSend.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        // NEW CODE
        private bool OwnerPaymentDetailsAreComplete()
        {
            return !string.IsNullOrWhiteSpace(_vehicle?.OwnerGCashNumber) &&
                   !string.IsNullOrWhiteSpace(_vehicle?.OwnerGCashName) &&
                   !string.IsNullOrWhiteSpace(_vehicle?.OwnerBankName) &&
                   !string.IsNullOrWhiteSpace(_vehicle?.OwnerBankAccountNumber) &&
                   !string.IsNullOrWhiteSpace(_vehicle?.OwnerBankAccountName);
        }

        private void ShowError(string msg)
        {
            lblError.Text = msg;
            lblError.Visible = true;
        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // NEW CODE
        // Recalculates the UI total as soon as the renter changes the rental duration.
        private void nudNumberOfDays_ValueChanged(object sender, EventArgs e)
        {
            UpdatePriceSummary();
        }
    }
}



