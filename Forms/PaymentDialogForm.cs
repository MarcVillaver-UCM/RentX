using System;
using System.Drawing;
using System.Windows.Forms;
using RentXpress.Models;
using RentXpress.Services;

namespace RentXpress.Forms
{
    public partial class PaymentDialogForm : Form
    {
        private readonly Inquiry _inquiry;
        private readonly InquiryService _inquiryService;

        public PaymentDialogForm()
        {
            InitializeComponent();
        }

        public PaymentDialogForm(Inquiry inquiry, InquiryService inquiryService)
        {
            _inquiry = inquiry;
            _inquiryService = inquiryService;
            InitializeComponent();
            BindInquiry();
        }

        private void BindInquiry()
        {
            lblSummary.Text =
                $"Rental days: {Math.Max(1, _inquiry.NumberOfDays)}\r\n" +
                $"Owner amount: PHP {_inquiry.OwnerAmount:F2}\r\n" +
                $"Platform fee: PHP {_inquiry.PlatformFee:F2}\r\n" +
                $"Total: PHP {_inquiry.TotalAmount:F2}";

            txtReference.Text = _inquiry.PaymentReference ?? "";
            cmbMethod.SelectedIndex = 0;
            RefreshPaymentUi();
        }

        private void RefreshPaymentUi()
        {
            if (_inquiry == null || cmbMethod.SelectedItem == null) return;

            string method = cmbMethod.SelectedItem.ToString();

            if (method == "GCash")
            {
                string payload = $"GCASH|NUMBER={_inquiry.OwnerGCashNumber}|NAME={_inquiry.OwnerGCashName}|AMOUNT={_inquiry.OwnerAmount:F2}";
                picQr.Image?.Dispose();
                picQr.Image = QrCodeLibrary.Generate(payload);
                picQr.Visible = true;
                lblDetails.Text =
                    $"Pay company via GCash:\r\n" +
                    $"Number: {_inquiry.OwnerGCashNumber}\r\n" +
                    $"Name: {_inquiry.OwnerGCashName}\r\n" +
                    $"Amount to company: PHP {_inquiry.OwnerAmount:F2}\r\n\r\n" +
                    $"Platform fee: PHP {_inquiry.PlatformFee:F2}";
            }
            else if (method == "Bank Transfer")
            {
                picQr.Image?.Dispose();
                picQr.Image = null;
                picQr.Visible = false;
                lblDetails.Text =
                    $"Bank transfer details:\r\n" +
                    $"Bank: {_inquiry.OwnerBankName}\r\n" +
                    $"Account #: {_inquiry.OwnerBankAccountNumber}\r\n" +
                    $"Account Name: {_inquiry.OwnerBankAccountName}\r\n" +
                    $"Amount to company: PHP {_inquiry.OwnerAmount:F2}\r\n\r\n" +
                    $"Platform fee: PHP {_inquiry.PlatformFee:F2}";
            }
            else
            {
                string payload = $"RENTXPRESS_PLATFORM_FEE|INQUIRY={_inquiry.Id}|AMOUNT={_inquiry.PlatformFee:F2}";
                picQr.Image?.Dispose();
                picQr.Image = QrCodeLibrary.Generate(payload);
                picQr.Visible = true;
                lblDetails.Text =
                    $"COD selected.\r\n" +
                    $"Pay the company PHP {_inquiry.OwnerAmount:F2} on delivery.\r\n\r\n" +
                    $"Required online platform fee: PHP {_inquiry.PlatformFee:F2}\r\n" +
                    "Scan the QR to pay RentXpress.";
            }
        }

        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPaymentUi();
        }

        private void btnSubmitProof_Click(object sender, EventArgs e)
        {
            string method = cmbMethod.SelectedItem?.ToString() ?? "GCash";
            string storedMethod = method == "Cash on Delivery (COD)" ? "cod" : method == "GCash" ? "gcash" : "bank";

            if (string.IsNullOrWhiteSpace(txtReference.Text))
            {
                MessageBox.Show(this, "Please enter a reference number or proof note.", "Proof Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _inquiryService.SubmitPaymentProof(_inquiry.Id, storedMethod, txtReference.Text.Trim());
            MessageBox.Show(this, "Payment proof submitted. The owner must confirm it before status becomes paid.",
                "Proof Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
