using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RentXpress.Models;
using RentXpress.Services;

namespace RentXpress.Forms
{
    // NEW CODE
    // BookingListPanel separates renter booking records from the Messages chat UI.
    // The app currently stores booking requests in the inquiries table, so this panel
    // reads those same records but displays only reservation-related information.
    public partial class BookingListPanel : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly InquiryService _inquiryService = new InquiryService();
        private readonly List<Inquiry> _bookings = new List<Inquiry>();

        public BookingListPanel()
        {
            InitializeComponent();
        }

        public BookingListPanel(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            LoadBookings();
        }

        private void LoadBookings()
        {
            try
            {
                _bookings.Clear();

                // NEW CODE
                // Personal bookings are the inquiry rows created by this renter. Chat replies live
                // in inquiry_replies and are intentionally not rendered here.
                foreach (var inquiry in _inquiryService.GetBySender(Session.CurrentUser.Id))
                {
                    _bookings.Add(inquiry);
                }

                dgvBookings.Rows.Clear();
                foreach (var booking in _bookings)
                {
                    dgvBookings.Rows.Add(
                        booking.Id,
                        booking.VehicleName,
                        booking.OwnerName,
                        Math.Max(1, booking.NumberOfDays),
                        $"PHP {booking.TotalAmount:F2}",
                        GetBookingStatus(booking),
                        $"{NormalizePaymentMethod(booking.PaymentMethod)} ({NormalizePaymentStatus(booking.PaymentStatus)})",
                        booking.CreatedAt.ToString("MMM dd, yyyy h:mm tt")
                    );
                }

                btnViewDetails.Enabled = dgvBookings.Rows.Count > 0;
                UpdateActionButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(_mainForm, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Inquiry GetSelectedBooking()
        {
            if (dgvBookings.SelectedRows.Count == 0) return null;

            int id = Convert.ToInt32(dgvBookings.SelectedRows[0].Cells["colId"].Value);
            return _bookings.Find(booking => booking.Id == id);
        }

        private string GetBookingStatus(Inquiry booking)
        {
            // NEW CODE
            // Existing inquiry status values are mapped into renter-friendly booking labels.
            // This avoids a risky table rebuild while still separating booking UX from chat UX.
            if (booking.Status == "closed") return "Cancelled";
            if (NormalizePaymentStatus(booking.PaymentStatus) == "Paid") return "Completed";
            if (booking.Status == "replied") return "Approved";
            return "Pending";
        }

        private bool CanCancelBooking(Inquiry booking)
        {
            if (booking == null) return false;
            string bookingStatus = GetBookingStatus(booking);
            return bookingStatus != "Cancelled" && bookingStatus != "Completed";
        }

        private void UpdateActionButtons()
        {
            var booking = GetSelectedBooking();
            btnViewDetails.Enabled = booking != null;
            btnCancelBooking.Enabled = CanCancelBooking(booking);
        }

        private string NormalizePaymentMethod(string method)
        {
            if (string.IsNullOrWhiteSpace(method)) return "Not selected";
            if (method == "gcash") return "GCash";
            if (method == "bank") return "Bank Transfer";
            if (method == "cod") return "COD";
            return method;
        }

        private string NormalizePaymentStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status)) return "Pending";
            return status.Equals("paid", StringComparison.OrdinalIgnoreCase) ? "Paid" : "Pending";
        }

        private void ShowSelectedBookingDetails()
        {
            var booking = GetSelectedBooking();
            if (booking == null) return;

            MessageBox.Show(_mainForm,
                "Vehicle: " + booking.VehicleName + Environment.NewLine +
                "Owner: " + booking.OwnerName + Environment.NewLine +
                "Number of Days: " + Math.Max(1, booking.NumberOfDays) + Environment.NewLine +
                "Owner Amount: PHP " + booking.OwnerAmount.ToString("F2") + Environment.NewLine +
                "Platform Fee: PHP " + booking.PlatformFee.ToString("F2") + Environment.NewLine +
                "Total Amount: PHP " + booking.TotalAmount.ToString("F2") + Environment.NewLine +
                "Booking Status: " + GetBookingStatus(booking) + Environment.NewLine +
                "Payment: " + NormalizePaymentMethod(booking.PaymentMethod) + " (" + NormalizePaymentStatus(booking.PaymentStatus) + ")",
                "Booking Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            ShowSelectedBookingDetails();
        }

        private void dgvBookings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) ShowSelectedBookingDetails();
        }

        private void dgvBookings_SelectionChanged(object sender, EventArgs e)
        {
            UpdateActionButtons();
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            var booking = GetSelectedBooking();
            if (booking == null)
            {
                MessageBox.Show(_mainForm, "Select a booking first.", "No Booking Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (GetBookingStatus(booking) == "Cancelled")
            {
                MessageBox.Show(_mainForm, "This booking is already cancelled.", "Already Cancelled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateActionButtons();
                return;
            }

            if (GetBookingStatus(booking) == "Completed")
            {
                MessageBox.Show(_mainForm, "Completed bookings can no longer be cancelled.", "Cannot Cancel",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show(_mainForm,
                "Cancel this booking request?",
                "Cancel Booking", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                bool cancelled = _inquiryService.CancelBooking(booking.Id, Session.CurrentUser.Id);
                LoadBookings();

                if (cancelled)
                {
                    MessageBox.Show(_mainForm, "Booking cancelled successfully.", "Booking Cancelled",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(_mainForm,
                        "The booking could not be cancelled. It may already be cancelled, completed, paid, or no longer belong to the current account.",
                        "Cancellation Not Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                LoadBookings();
                MessageBox.Show(_mainForm, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
