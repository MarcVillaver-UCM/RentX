using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RentXpress.Models;
using RentXpress.Services;

namespace RentXpress.Forms
{
    public partial class InquiryListPanel : UserControl
    {
        private readonly InquiryService _inquiryService = new InquiryService();
        private readonly MainForm _mainForm;
        private readonly bool _ownerMode;
        private List<Inquiry> _inquiries = new List<Inquiry>();
        private Inquiry _selectedInquiry;

        public InquiryListPanel()
        {
            InitializeComponent();
        }

        public InquiryListPanel(MainForm mainForm) : this(mainForm, false)
        {
        }

        public InquiryListPanel(MainForm mainForm, bool ownerMode)
        {
            _mainForm = mainForm;
            _ownerMode = ownerMode;
            this.BackColor = AppTheme.BgDark;
            this.Padding = new Padding(40, 30, 40, 30);
            InitializeComponent();
            ConfigureMode();
            LoadInquiries();
        }

        private void ConfigureMode()
        {
            // MODIFIED CODE
            // This panel is now chat-only. Booking summaries were moved to BookingListPanel,
            // so both account roles see the same clear page label: Messages.
            lblTitle.Text = "Messages";
            colOwner.HeaderText = _ownerMode ? "Sender" : "Owner";
            dgv.SelectionChanged += dgv_SelectionChanged;
            dgv.CellDoubleClick += dgv_CellDoubleClick;

            btnCloseInquiry.Visible = _ownerMode;
            if (rowActions != null)
            {
                rowActions.Height = _ownerMode ? 48F : 0F;
            }
        }

        private void LoadInquiries(int preserveInquiryId = -1)
        {
            try
            {
                _inquiries = _ownerMode
                    ? _inquiryService.GetByOwner(Session.CurrentUser.Id)
                    : _inquiryService.GetBySender(Session.CurrentUser.Id);

                dgv.Rows.Clear();
                foreach (var inq in _inquiries)
                {
                    dgv.Rows.Add(
                        inq.Id,
                        inq.VehicleName,
                        _ownerMode ? inq.SenderName : inq.OwnerName,
                        inq.Subject,
                        inq.Status.ToUpper(),
                        inq.PriorityDisplay,
                        inq.CreatedAt.ToString("MMM dd, yyyy h:mm tt")
                    );
                }

                _mainForm.UpdateMessageBadge();
                if (dgv.Rows.Count > 0)
                {
                    int rowIndex = 0;

                    if (preserveInquiryId != -1)
                    {
                        for (int i = 0; i < _inquiries.Count; i++)
                        {
                            if (_inquiries[i].Id == preserveInquiryId)
                            {
                                rowIndex = i;
                                break;
                            }
                        }
                    }

                    dgv.ClearSelection();
                    dgv.Rows[rowIndex].Selected = true;
                    dgv.CurrentCell = dgv.Rows[rowIndex].Cells[1];

                    ShowConversation(_inquiries[rowIndex]);
                }
                else
                {
                    ShowEmptyConversation();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Inquiry GetSelectedInquiry()
        {
            if (dgv.SelectedRows.Count == 0) return null;
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells["colId"].Value);
            return _inquiries.Find(inq => inq.Id == id);
        }

        private void ViewSelectedInquiry()
        {
            var inq = GetSelectedInquiry();
            if (inq == null) return;
            ShowConversation(inq);
        }

        private void UpdateSelectedStatus(string status)
        {
            var inq = GetSelectedInquiry();
            if (inq == null) return;

            try
            {
                _inquiryService.UpdateStatus(inq.Id, status);
                LoadInquiries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _inquiries.Count) return;
            var inq = _inquiries[e.RowIndex];

            if (inq.IsEmergency)
            {
                dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(50, 35, 20);
            }

            if (dgv.Columns[e.ColumnIndex].Name == "colStatus")
            {
                switch (inq.Status)
                {
                    case "pending": e.CellStyle.ForeColor = AppTheme.WarningColor; break;
                    case "replied": e.CellStyle.ForeColor = AppTheme.Accent; break;
                    case "closed": e.CellStyle.ForeColor = AppTheme.TextMuted; break;
                }
            }

            if (dgv.Columns[e.ColumnIndex].Name == "colPriority" && inq.IsEmergency)
            {
                e.CellStyle.ForeColor = AppTheme.DangerColor;
                e.CellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) ViewSelectedInquiry();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            var inq = GetSelectedInquiry();
            if (inq != null) ShowConversation(inq);
        }

        private void ShowConversation(Inquiry inq)
        {
            _selectedInquiry = inq;
            lblConversationTitle.Text = inq.Subject;
            // MODIFIED CODE
            // Messages should focus on communication. Detailed booking/payment information is
            // shown in BookingListPanel, while this header keeps only enough context to know
            // which vehicle and person the conversation belongs to.
            lblConversationMeta.Text =
                $"Vehicle: {inq.VehicleName}\r\n" +
                $"{(_ownerMode ? "From" : "To")}: {(_ownerMode ? inq.SenderName : inq.OwnerName)}";
            txtReply.Enabled = inq.Status != "closed";
            btnSendReply.Enabled = inq.Status != "closed";
            btnProceedPayment.Enabled = !_ownerMode;
            btnConfirmPayment.Enabled = _ownerMode && !string.IsNullOrWhiteSpace(inq.PaymentReference) && inq.PaymentStatus != "paid";
            txtReply.Text = "";

            flpMessages.Controls.Clear();

            // The original inquiry starts the conversation before any replies exist.
            AddChatBubble(inq.SenderName, inq.Message, inq.CreatedAt, inq.SenderId == Session.CurrentUser.Id);

            foreach (var reply in _inquiryService.GetReplies(inq.Id))
            {
                AddChatBubble(reply.SenderName, reply.Message, reply.CreatedAt, reply.SenderId == Session.CurrentUser.Id);
            }
        }

        private void ShowEmptyConversation()
        {
            _selectedInquiry = null;
            lblConversationTitle.Text = "No conversations yet";
            lblConversationMeta.Text = _ownerMode
                ? "Incoming renter messages will appear here."
                : "Messages you send to vehicle owners will appear here.";
            flpMessages.Controls.Clear();
            txtReply.Text = "";
            txtReply.Enabled = false;
            btnSendReply.Enabled = false;
            btnProceedPayment.Enabled = false;
            btnConfirmPayment.Enabled = false;
        }

        private void AddChatBubble(string senderName, string message, DateTime createdAt, bool fromCurrentUser)
        {
            int bubbleWidth = Math.Max(220, flpMessages.Width - 45);
            var bubble = new ChatBubbleControl();
            bubble.BindMessage(senderName, message, createdAt, fromCurrentUser, bubbleWidth);
            flpMessages.Controls.Add(bubble);
            flpMessages.ScrollControlIntoView(bubble);
        }

        private void btnSendReply_Click(object sender, EventArgs e)
        {
            if (_selectedInquiry == null) return;

            string message = txtReply.Text.Trim();
            if (message.Length < 2)
            {
                MessageBox.Show("Please type a reply first.", "Reply Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Both company and personal accounts use the same method; sender_id decides who wrote the reply.
                _inquiryService.SendReply(_selectedInquiry.Id, Session.CurrentUser.Id, message);
                int selectedId = _selectedInquiry.Id;

                LoadInquiries(selectedId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NEW CODE
        // Opens a focused payment dialog from the active chat. Payment method is saved with
        // Pending status first; non-COD methods can then be marked Paid after confirmation.
        private void btnProceedPayment_Click(object sender, EventArgs e)
        {
            if (_selectedInquiry == null) return;
            ShowPaymentDialog(_selectedInquiry);
        }

        private void ShowPaymentDialog(Inquiry inq)
        {
            using (var form = new PaymentDialogForm(inq, _inquiryService))
            {
                if (form.ShowDialog(_mainForm) == DialogResult.OK)
                {
                    LoadInquiries();
                }
            }
        }

        // NEW CODE
        // Company owner confirmation is the trust step: renter submits proof first, owner verifies
        // it, then this action changes the booking payment status to paid.
        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            if (_selectedInquiry == null) return;
            var result = MessageBox.Show(
                $"Confirm payment for reference/proof:\n{_selectedInquiry.PaymentReference}",
                "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                _inquiryService.ConfirmPayment(_selectedInquiry.Id, Session.CurrentUser.Id);
                MessageBox.Show("Payment confirmed.", "Payment Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInquiries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseInquiry_Click(object sender, EventArgs e)
        {
            UpdateSelectedStatus("closed");
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

