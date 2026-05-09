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
        private Button btnCloseInquiry;
        private TableLayoutPanel tlpRoot;
        private SplitContainer splitMessages;
        private Panel pnlConversation;
        private FlowLayoutPanel flpMessages;
        private Label lblConversationTitle;
        private Label lblConversationMeta;
        private TextBox txtReply;
        private Button btnSendReply;
        // NEW CODE
        private Button btnProceedPayment;
        private Button btnConfirmPayment;

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
            BuildConversationPanel();
            BuildResponsiveLayout();
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

            // MODIFIED CODE
            // The extra chat-opening button was redundant because selecting or double-clicking
            // a conversation already opens it. Removing it avoids a dead-looking extra action.
            btnCloseInquiry = MakeActionButton("Close", 40, 575, 100, AppTheme.BgInput, AppTheme.TextPrimary);

            btnCloseInquiry.Click += (s, e) => UpdateSelectedStatus("closed");
            btnCloseInquiry.Visible = _ownerMode;
        }

        private Button MakeActionButton(string text, int x, int y, int width, Color backColor, Color foreColor)
        {
            var button = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(width, 36),
                BackColor = backColor,
                ForeColor = foreColor,
                FlatStyle = FlatStyle.Flat,
                Font = AppTheme.FontButton,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Left | AnchorStyles.Bottom,
                UseVisualStyleBackColor = false
            };
            button.FlatAppearance.BorderColor = AppTheme.BorderColor;
            button.FlatAppearance.BorderSize = backColor == AppTheme.Accent ? 0 : 1;
            return button;
        }

        private void ResizeDgv()
        {
            LayoutMessagePanels();
        }

        private void BuildConversationPanel()
        {
            // This whole right-side area is created in code so both account modes share one chat UI.
            pnlConversation = new Panel
            {
                BackColor = AppTheme.BgCard,
                Dock = DockStyle.Fill
            };
            pnlConversation.Resize += (s, e) => LayoutMessagePanels();

            lblConversationTitle = new Label
            {
                AutoSize = false,
                Font = AppTheme.FontH2,
                ForeColor = AppTheme.TextPrimary,
                Location = new Point(20, 18),
                Size = new Size(330, 28),
                Text = "Select a conversation"
            };

            lblConversationMeta = new Label
            {
                AutoSize = false,
                Font = AppTheme.FontBody,
                ForeColor = AppTheme.TextSecondary,
                Location = new Point(20, 48),
                Size = new Size(330, 45),
                Text = "Choose a row on the left to read and reply."
            };

            flpMessages = new FlowLayoutPanel
            {
                AutoScroll = true,
                BackColor = AppTheme.BgDark,
                FlowDirection = FlowDirection.TopDown,
                Location = new Point(20, 100),
                Padding = new Padding(10),
                WrapContents = false
            };

            txtReply = new TextBox
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                BackColor = AppTheme.BgInput,
                BorderStyle = BorderStyle.FixedSingle,
                Font = AppTheme.FontBody,
                ForeColor = AppTheme.TextPrimary,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            btnSendReply = MakeActionButton("Send Reply", 0, 0, 110, AppTheme.Accent, AppTheme.TextPrimary);
            btnSendReply.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            btnSendReply.Click += btnSendReply_Click;

            // NEW CODE
            // Payment starts from the full conversation view so renters can review chat context
            // before choosing GCash, Bank Transfer, or COD.
            btnProceedPayment = MakeActionButton("Proceed to Payment", 0, 0, 155, AppTheme.BgInput, AppTheme.TextPrimary);
            btnProceedPayment.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            btnProceedPayment.Click += btnProceedPayment_Click;

            // NEW CODE
            // Owners use this after checking the renter's submitted reference/proof.
            btnConfirmPayment = MakeActionButton("Confirm Payment", 0, 0, 145, AppTheme.Accent, AppTheme.TextPrimary);
            btnConfirmPayment.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            btnConfirmPayment.Click += btnConfirmPayment_Click;
            btnConfirmPayment.Visible = _ownerMode;

            pnlConversation.Controls.Add(lblConversationTitle);
            pnlConversation.Controls.Add(lblConversationMeta);
            pnlConversation.Controls.Add(flpMessages);
            pnlConversation.Controls.Add(txtReply);
            pnlConversation.Controls.Add(btnSendReply);
            pnlConversation.Controls.Add(btnProceedPayment);
            pnlConversation.Controls.Add(btnConfirmPayment);
        }

        private void BuildResponsiveLayout()
        {
            SuspendLayout();

            Controls.Clear();

            tlpRoot = new TableLayoutPanel
            {
                BackColor = AppTheme.BgDark,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(40, 30, 40, 30),
                RowCount = 2
            };
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            lblTitle.AutoSize = false;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Margin = new Padding(0);
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;

            splitMessages = new SplitContainer
            {
                BackColor = AppTheme.BgDark,
                Dock = DockStyle.Fill,
                FixedPanel = FixedPanel.None,
                IsSplitterFixed = false,
                Margin = new Padding(0),
                Orientation = Orientation.Vertical,
                Panel1MinSize = 25,
                Panel2MinSize = 25,
                SplitterWidth = 16
            };
            splitMessages.SplitterMoved += (s, e) => LayoutMessagePanels();
            splitMessages.Resize += (s, e) => BalanceSplitPanels();

            var listLayout = new TableLayoutPanel
            {
                BackColor = AppTheme.BgDark,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                RowCount = 2
            };
            listLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            listLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, _ownerMode ? 48F : 0F));

            dgv.Anchor = AnchorStyles.None;
            dgv.Dock = DockStyle.Fill;
            dgv.Location = Point.Empty;
            dgv.Margin = new Padding(0);

            listLayout.Controls.Add(dgv, 0, 0);

            if (_ownerMode)
            {
                var actionBar = new Panel
                {
                    BackColor = AppTheme.BgDark,
                    Dock = DockStyle.Fill,
                    Margin = new Padding(0, 12, 0, 0)
                };
                btnCloseInquiry.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                btnCloseInquiry.Location = Point.Empty;
                actionBar.Controls.Add(btnCloseInquiry);
                listLayout.Controls.Add(actionBar, 0, 1);
            }

            splitMessages.Panel1.Padding = new Padding(0, 0, 8, 0);
            splitMessages.Panel2.Padding = new Padding(8, 0, 0, 0);
            splitMessages.Panel1.Controls.Add(listLayout);
            splitMessages.Panel2.Controls.Add(pnlConversation);

            tlpRoot.Controls.Add(lblTitle, 0, 0);
            tlpRoot.Controls.Add(splitMessages, 0, 1);
            Controls.Add(tlpRoot);

            BalanceSplitPanels();
            ResumeLayout(false);
        }

        private void BalanceSplitPanels()
        {
            if (splitMessages == null || splitMessages.Width <= 0) return;

            int availableWidth = splitMessages.Width - splitMessages.SplitterWidth;
            if (availableWidth <= 0) return;

            int listMinWidth = Math.Min(420, Math.Max(25, availableWidth / 2));
            int chatMinWidth = Math.Min(360, Math.Max(25, availableWidth - listMinWidth));
            if (availableWidth <= listMinWidth + chatMinWidth) return;

            splitMessages.Panel1MinSize = listMinWidth;
            splitMessages.Panel2MinSize = chatMinWidth;

            int desiredListWidth = Math.Max(listMinWidth, (int)(availableWidth * 0.56));
            int maxListWidth = availableWidth - chatMinWidth;
            splitMessages.SplitterDistance = Math.Min(desiredListWidth, maxListWidth);
            LayoutMessagePanels();
        }

        private void LayoutMessagePanels()
        {
            if (pnlConversation == null || flpMessages == null) return;

            int panelWidth = Math.Max(320, pnlConversation.ClientSize.Width);
            int panelHeight = Math.Max(260, pnlConversation.ClientSize.Height);
            int actionTop = Math.Max(110, panelHeight - 92);
            int paymentTop = Math.Max(110, panelHeight - 132);

            lblConversationTitle.Size = new Size(Math.Max(120, panelWidth - 40), 28);
            lblConversationMeta.Size = new Size(Math.Max(120, panelWidth - 40), 45);
            flpMessages.Location = new Point(20, 100);
            flpMessages.Size = new Size(Math.Max(120, panelWidth - 40), Math.Max(70, panelHeight - 205));
            txtReply.Location = new Point(20, actionTop);
            txtReply.Size = new Size(Math.Max(120, panelWidth - 185), 72);
            btnSendReply.Location = new Point(Math.Max(20, panelWidth - 120), actionTop);
            btnProceedPayment.Location = new Point(20, paymentTop);
            btnConfirmPayment.Location = new Point(185, paymentTop);
        }

        private void LoadInquiries()
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
                    dgv.Rows[0].Selected = true;
                    ShowConversation(_inquiries[0]);
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
            var bubble = new Panel
            {
                AutoSize = true,
                BackColor = fromCurrentUser ? Color.FromArgb(24, 95, 78) : AppTheme.BgCard,
                Margin = fromCurrentUser ? new Padding(35, 6, 0, 6) : new Padding(0, 6, 35, 6),
                Padding = new Padding(10),
                Width = bubbleWidth
            };

            var header = new Label
            {
                AutoSize = false,
                Font = AppTheme.FontSmall,
                ForeColor = AppTheme.TextSecondary,
                Location = new Point(10, 8),
                Size = new Size(bubbleWidth - 20, 18),
                Text = $"{senderName}  |  {createdAt:g}"
            };

            var body = new Label
            {
                AutoSize = false,
                Font = AppTheme.FontBody,
                ForeColor = AppTheme.TextPrimary,
                Location = new Point(10, 30),
                MaximumSize = new Size(bubbleWidth - 20, 0),
                Size = new Size(bubbleWidth - 20, 0),
                Text = message
            };
            body.Height = TextRenderer.MeasureText(message, body.Font, new Size(body.Width, 0), TextFormatFlags.WordBreak).Height + 8;

            bubble.Height = body.Bottom + 10;
            bubble.Controls.Add(header);
            bubble.Controls.Add(body);
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
                ShowConversation(_selectedInquiry);
                LoadInquiries();
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
            using (var form = new Form())
            {
                form.Text = "Proceed to Payment";
                form.StartPosition = FormStartPosition.CenterParent;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.BackColor = AppTheme.BgDark;
                form.ClientSize = new Size(520, 570);

                var title = MakePaymentLabel("Payment Options", 24, 20, AppTheme.FontH2, AppTheme.TextPrimary);
                var summary = MakePaymentLabel(
                    // NEW CODE
                    $"Rental days: {Math.Max(1, inq.NumberOfDays)}\r\nOwner amount: ${inq.OwnerAmount:F2}\r\nPlatform fee: ${inq.PlatformFee:F2}\r\nTotal: ${inq.TotalAmount:F2}",
                    24, 55, AppTheme.FontBody, AppTheme.TextSecondary);
                summary.Size = new Size(470, 82);
                summary.AutoSize = false;

                var cmbMethod = new ComboBox
                {
                    BackColor = AppTheme.BgInput,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    FlatStyle = FlatStyle.Flat,
                    Font = AppTheme.FontBody,
                    ForeColor = AppTheme.TextPrimary,
                    Location = new Point(24, 130),
                    Size = new Size(220, 29)
                };
                cmbMethod.Items.AddRange(new object[] { "GCash", "Bank Transfer", "Cash on Delivery (COD)" });
                cmbMethod.SelectedIndex = 0;

                var details = MakePaymentLabel("", 24, 175, AppTheme.FontBody, AppTheme.TextPrimary);
                details.AutoSize = false;
                details.Size = new Size(240, 210);

                // NEW CODE
                // Renter enters a transfer reference, receipt number, or short proof note.
                // This replaces the unsafe renter-side "Mark Paid" button.
                var lblReference = MakePaymentLabel("Payment reference / proof note", 24, 392, AppTheme.FontBody, AppTheme.TextPrimary);
                var txtReference = new TextBox
                {
                    BackColor = AppTheme.BgInput,
                    BorderStyle = BorderStyle.FixedSingle,
                    Font = AppTheme.FontBody,
                    ForeColor = AppTheme.TextPrimary,
                    Location = new Point(24, 417),
                    Size = new Size(461, 29),
                    Text = inq.PaymentReference ?? ""
                };

                var qr = new PictureBox
                {
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(285, 175),
                    Size = new Size(200, 200),
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                var btnSubmitProof = MakeActionButton("Submit Payment Proof", 24, 505, 180, AppTheme.Accent, AppTheme.TextPrimary);
                var btnClose = MakeActionButton("Close", 395, 505, 90, AppTheme.BgInput, AppTheme.TextPrimary);

                Action refreshPaymentUi = () =>
                {
                    string method = cmbMethod.SelectedItem.ToString();

                    if (method == "GCash")
                    {
                        // NEW CODE
                        // QR payload includes owner GCash number and amount so the renter can scan
                        // the generated code and pay the company directly.
                        string payload = $"GCASH|NUMBER={inq.OwnerGCashNumber}|NAME={inq.OwnerGCashName}|AMOUNT={inq.OwnerAmount:F2}";
                        qr.Image?.Dispose();
                        qr.Image = QrCodeLibrary.Generate(payload);
                        qr.Visible = true;
                        details.Text = $"Pay company via GCash:\r\nNumber: {inq.OwnerGCashNumber}\r\nName: {inq.OwnerGCashName}\r\nAmount to company: ${inq.OwnerAmount:F2}\r\n\r\nPlatform fee: ${inq.PlatformFee:F2}";
                    }
                    else if (method == "Bank Transfer")
                    {
                        qr.Image?.Dispose();
                        qr.Image = null;
                        qr.Visible = false;
                        details.Text = $"Bank transfer details:\r\nBank: {inq.OwnerBankName}\r\nAccount #: {inq.OwnerBankAccountNumber}\r\nAccount Name: {inq.OwnerBankAccountName}\r\nAmount to company: ${inq.OwnerAmount:F2}\r\n\r\nPlatform fee: ${inq.PlatformFee:F2}";
                    }
                    else
                    {
                        // NEW CODE
                        // COD pays the owner later in cash, but the platform fee must still be paid
                        // online so the platform is not bypassed.
                        string payload = $"RENTXPRESS_PLATFORM_FEE|INQUIRY={inq.Id}|AMOUNT={inq.PlatformFee:F2}";
                        qr.Image?.Dispose();
                        qr.Image = QrCodeLibrary.Generate(payload);
                        qr.Visible = true;
                        details.Text = $"COD selected.\r\nPay the company ${inq.OwnerAmount:F2} on delivery.\r\n\r\nRequired online platform fee: ${inq.PlatformFee:F2}\r\nScan the QR to pay RentXpress.";
                    }
                };

                cmbMethod.SelectedIndexChanged += (s, e) => refreshPaymentUi();
                btnSubmitProof.Click += (s, e) =>
                {
                    string method = cmbMethod.SelectedItem.ToString();
                    string storedMethod = method == "Cash on Delivery (COD)" ? "cod" : method == "GCash" ? "gcash" : "bank";
                    if (string.IsNullOrWhiteSpace(txtReference.Text))
                    {
                        MessageBox.Show("Please enter a reference number or proof note.", "Proof Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    _inquiryService.SubmitPaymentProof(inq.Id, storedMethod, txtReference.Text.Trim());
                    MessageBox.Show("Payment proof submitted. The owner must confirm it before status becomes paid.", "Proof Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInquiries();
                    form.Close();
                };
                btnClose.Click += (s, e) => form.Close();

                form.Controls.Add(title);
                form.Controls.Add(summary);
                form.Controls.Add(cmbMethod);
                form.Controls.Add(details);
                form.Controls.Add(lblReference);
                form.Controls.Add(txtReference);
                form.Controls.Add(qr);
                form.Controls.Add(btnSubmitProof);
                form.Controls.Add(btnClose);
                refreshPaymentUi();
                form.ShowDialog(_mainForm);
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

        private Label MakePaymentLabel(string text, int x, int y, Font font, Color color)
        {
            return new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = font,
                ForeColor = color,
                Location = new Point(x, y),
                Text = text
            };
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dgv_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

