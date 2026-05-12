using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class InquiryListPanel
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel tlpRoot;
        private Label lblTitle;
        private SplitContainer splitMessages;
        private TableLayoutPanel listLayout;
        private RowStyle rowActions;
        private DataGridView dgv;
        private Panel pnlListActions;
        private Button btnCloseInquiry;
        private Panel pnlConversation;
        private TableLayoutPanel conversationLayout;
        private Label lblConversationTitle;
        private Label lblConversationMeta;
        private FlowLayoutPanel flpMessages;
        private FlowLayoutPanel flpPaymentActions;
        private TableLayoutPanel replyLayout;
        private TextBox txtReply;
        private Button btnProceedPayment;
        private Button btnConfirmPayment;
        private Button btnSendReply;

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
            this.tlpRoot = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitMessages = new System.Windows.Forms.SplitContainer();
            this.listLayout = new System.Windows.Forms.TableLayoutPanel();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.pnlListActions = new System.Windows.Forms.Panel();
            this.btnCloseInquiry = new System.Windows.Forms.Button();
            this.pnlConversation = new System.Windows.Forms.Panel();
            this.conversationLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblConversationTitle = new System.Windows.Forms.Label();
            this.lblConversationMeta = new System.Windows.Forms.Label();
            this.flpMessages = new System.Windows.Forms.FlowLayoutPanel();
            this.flpPaymentActions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnProceedPayment = new System.Windows.Forms.Button();
            this.btnConfirmPayment = new System.Windows.Forms.Button();
            this.replyLayout = new System.Windows.Forms.TableLayoutPanel();
            this.txtReply = new System.Windows.Forms.TextBox();
            this.btnSendReply = new System.Windows.Forms.Button();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlpRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMessages)).BeginInit();
            this.splitMessages.Panel1.SuspendLayout();
            this.splitMessages.Panel2.SuspendLayout();
            this.splitMessages.SuspendLayout();
            this.listLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.pnlListActions.SuspendLayout();
            this.pnlConversation.SuspendLayout();
            this.conversationLayout.SuspendLayout();
            this.flpPaymentActions.SuspendLayout();
            this.replyLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpRoot
            // 
            this.tlpRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.tlpRoot.ColumnCount = 1;
            this.tlpRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Controls.Add(this.lblTitle, 0, 0);
            this.tlpRoot.Controls.Add(this.splitMessages, 0, 1);
            this.tlpRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRoot.Location = new System.Drawing.Point(40, 30);
            this.tlpRoot.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRoot.Name = "tlpRoot";
            this.tlpRoot.RowCount = 2;
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlpRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRoot.Size = new System.Drawing.Size(1020, 570);
            this.tlpRoot.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1020, 56);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Messages";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitMessages
            // 
            this.splitMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.splitMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMessages.Location = new System.Drawing.Point(0, 56);
            this.splitMessages.Margin = new System.Windows.Forms.Padding(0);
            this.splitMessages.Name = "splitMessages";
            // 
            // splitMessages.Panel1
            // 
            this.splitMessages.Panel1.Controls.Add(this.listLayout);
            this.splitMessages.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            // 
            // splitMessages.Panel2
            // 
            this.splitMessages.Panel2.Controls.Add(this.pnlConversation);
            this.splitMessages.Panel2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.splitMessages.Size = new System.Drawing.Size(1020, 514);
            this.splitMessages.SplitterDistance = 560;
            this.splitMessages.SplitterWidth = 16;
            this.splitMessages.TabIndex = 1;
            // 
            // listLayout
            // 
            this.listLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.listLayout.ColumnCount = 1;
            this.listLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.listLayout.Controls.Add(this.dgv, 0, 0);
            this.listLayout.Controls.Add(this.pnlListActions, 0, 1);
            this.listLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLayout.Location = new System.Drawing.Point(0, 0);
            this.listLayout.Margin = new System.Windows.Forms.Padding(0);
            this.listLayout.Name = "listLayout";
            this.listLayout.RowCount = 2;
            this.listLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.listLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.listLayout.Size = new System.Drawing.Size(552, 514);
            this.listLayout.TabIndex = 0;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.ColumnHeadersHeight = 36;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colVehicle,
            this.colOwner,
            this.colSubject,
            this.colStatus,
            this.colPriority,
            this.colDate});
            this.dgv.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Margin = new System.Windows.Forms.Padding(0);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 38;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(552, 514);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick_1);
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Dgv_CellFormatting);
            // 
            // pnlListActions
            // 
            this.pnlListActions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnlListActions.Controls.Add(this.btnCloseInquiry);
            this.pnlListActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlListActions.Location = new System.Drawing.Point(0, 526);
            this.pnlListActions.Margin = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.pnlListActions.Name = "pnlListActions";
            this.pnlListActions.Size = new System.Drawing.Size(552, 1);
            this.pnlListActions.TabIndex = 1;
            // 
            // btnCloseInquiry
            // 
            this.btnCloseInquiry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnCloseInquiry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseInquiry.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCloseInquiry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseInquiry.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCloseInquiry.ForeColor = System.Drawing.Color.White;
            this.btnCloseInquiry.Location = new System.Drawing.Point(0, 0);
            this.btnCloseInquiry.Name = "btnCloseInquiry";
            this.btnCloseInquiry.Size = new System.Drawing.Size(100, 36);
            this.btnCloseInquiry.TabIndex = 0;
            this.btnCloseInquiry.Text = "Close";
            this.btnCloseInquiry.UseVisualStyleBackColor = false;
            this.btnCloseInquiry.Visible = false;
            this.btnCloseInquiry.Click += new System.EventHandler(this.btnCloseInquiry_Click);
            // 
            // pnlConversation
            // 
            this.pnlConversation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlConversation.Controls.Add(this.conversationLayout);
            this.pnlConversation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConversation.Location = new System.Drawing.Point(8, 0);
            this.pnlConversation.Name = "pnlConversation";
            this.pnlConversation.Size = new System.Drawing.Size(436, 514);
            this.pnlConversation.TabIndex = 0;
            // 
            // conversationLayout
            // 
            this.conversationLayout.ColumnCount = 1;
            this.conversationLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.conversationLayout.Controls.Add(this.lblConversationTitle, 0, 0);
            this.conversationLayout.Controls.Add(this.lblConversationMeta, 0, 1);
            this.conversationLayout.Controls.Add(this.flpMessages, 0, 2);
            this.conversationLayout.Controls.Add(this.flpPaymentActions, 0, 3);
            this.conversationLayout.Controls.Add(this.replyLayout, 0, 4);
            this.conversationLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conversationLayout.Location = new System.Drawing.Point(0, 0);
            this.conversationLayout.Margin = new System.Windows.Forms.Padding(0);
            this.conversationLayout.Name = "conversationLayout";
            this.conversationLayout.Padding = new System.Windows.Forms.Padding(20, 18, 20, 20);
            this.conversationLayout.RowCount = 5;
            this.conversationLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.conversationLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.conversationLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.conversationLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.conversationLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.conversationLayout.Size = new System.Drawing.Size(436, 514);
            this.conversationLayout.TabIndex = 0;
            // 
            // lblConversationTitle
            // 
            this.lblConversationTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConversationTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblConversationTitle.ForeColor = System.Drawing.Color.White;
            this.lblConversationTitle.Location = new System.Drawing.Point(20, 18);
            this.lblConversationTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblConversationTitle.Name = "lblConversationTitle";
            this.lblConversationTitle.Size = new System.Drawing.Size(396, 32);
            this.lblConversationTitle.TabIndex = 0;
            this.lblConversationTitle.Text = "Select a conversation";
            this.lblConversationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConversationMeta
            // 
            this.lblConversationMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConversationMeta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblConversationMeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblConversationMeta.Location = new System.Drawing.Point(20, 50);
            this.lblConversationMeta.Margin = new System.Windows.Forms.Padding(0);
            this.lblConversationMeta.Name = "lblConversationMeta";
            this.lblConversationMeta.Size = new System.Drawing.Size(396, 50);
            this.lblConversationMeta.TabIndex = 1;
            this.lblConversationMeta.Text = "Choose a row on the left to read and reply.";
            this.lblConversationMeta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flpMessages
            // 
            this.flpMessages.AutoScroll = true;
            this.flpMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.flpMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMessages.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMessages.Location = new System.Drawing.Point(20, 100);
            this.flpMessages.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.flpMessages.Name = "flpMessages";
            this.flpMessages.Padding = new System.Windows.Forms.Padding(10);
            this.flpMessages.Size = new System.Drawing.Size(396, 260);
            this.flpMessages.TabIndex = 2;
            this.flpMessages.WrapContents = false;
            // 
            // flpPaymentActions
            // 
            this.flpPaymentActions.Controls.Add(this.btnProceedPayment);
            this.flpPaymentActions.Controls.Add(this.btnConfirmPayment);
            this.flpPaymentActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPaymentActions.Location = new System.Drawing.Point(20, 372);
            this.flpPaymentActions.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.flpPaymentActions.Name = "flpPaymentActions";
            this.flpPaymentActions.Size = new System.Drawing.Size(396, 36);
            this.flpPaymentActions.TabIndex = 3;
            this.flpPaymentActions.WrapContents = false;
            // 
            // btnProceedPayment
            // 
            this.btnProceedPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnProceedPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProceedPayment.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnProceedPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProceedPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProceedPayment.ForeColor = System.Drawing.Color.White;
            this.btnProceedPayment.Location = new System.Drawing.Point(0, 0);
            this.btnProceedPayment.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnProceedPayment.Name = "btnProceedPayment";
            this.btnProceedPayment.Size = new System.Drawing.Size(155, 36);
            this.btnProceedPayment.TabIndex = 0;
            this.btnProceedPayment.Text = "Proceed to Payment";
            this.btnProceedPayment.UseVisualStyleBackColor = false;
            this.btnProceedPayment.Click += new System.EventHandler(this.btnProceedPayment_Click);
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnConfirmPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmPayment.FlatAppearance.BorderSize = 0;
            this.btnConfirmPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnConfirmPayment.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPayment.Location = new System.Drawing.Point(165, 0);
            this.btnConfirmPayment.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(145, 36);
            this.btnConfirmPayment.TabIndex = 1;
            this.btnConfirmPayment.Text = "Confirm Payment";
            this.btnConfirmPayment.UseVisualStyleBackColor = false;
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            // 
            // replyLayout
            // 
            this.replyLayout.ColumnCount = 2;
            this.replyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.replyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.replyLayout.Controls.Add(this.txtReply, 0, 0);
            this.replyLayout.Controls.Add(this.btnSendReply, 1, 0);
            this.replyLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.replyLayout.Location = new System.Drawing.Point(20, 416);
            this.replyLayout.Margin = new System.Windows.Forms.Padding(0);
            this.replyLayout.Name = "replyLayout";
            this.replyLayout.RowCount = 1;
            this.replyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.replyLayout.Size = new System.Drawing.Size(396, 78);
            this.replyLayout.TabIndex = 4;
            // 
            // txtReply
            // 
            this.txtReply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtReply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReply.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReply.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtReply.ForeColor = System.Drawing.Color.White;
            this.txtReply.Location = new System.Drawing.Point(0, 0);
            this.txtReply.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.txtReply.Multiline = true;
            this.txtReply.Name = "txtReply";
            this.txtReply.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReply.Size = new System.Drawing.Size(260, 78);
            this.txtReply.TabIndex = 0;
            // 
            // btnSendReply
            // 
            this.btnSendReply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnSendReply.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendReply.FlatAppearance.BorderSize = 0;
            this.btnSendReply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendReply.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSendReply.ForeColor = System.Drawing.Color.White;
            this.btnSendReply.Location = new System.Drawing.Point(272, 0);
            this.btnSendReply.Margin = new System.Windows.Forms.Padding(0);
            this.btnSendReply.Name = "btnSendReply";
            this.btnSendReply.Size = new System.Drawing.Size(112, 36);
            this.btnSendReply.TabIndex = 1;
            this.btnSendReply.Text = "Send Reply";
            this.btnSendReply.UseVisualStyleBackColor = false;
            this.btnSendReply.Click += new System.EventHandler(this.btnSendReply_Click);
            // 
            // colId
            // 
            this.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colId.FillWeight = 5F;
            this.colId.Frozen = true;
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 30;
            // 
            // colVehicle
            // 
            this.colVehicle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colVehicle.Frozen = true;
            this.colVehicle.HeaderText = "Vehicle";
            this.colVehicle.MinimumWidth = 26;
            this.colVehicle.Name = "colVehicle";
            this.colVehicle.ReadOnly = true;
            this.colVehicle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colVehicle.Width = 110;
            // 
            // colOwner
            // 
            this.colOwner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colOwner.Frozen = true;
            this.colOwner.HeaderText = "Owner";
            this.colOwner.MinimumWidth = 6;
            this.colOwner.Name = "colOwner";
            this.colOwner.ReadOnly = true;
            this.colOwner.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colOwner.Width = 110;
            // 
            // colSubject
            // 
            this.colSubject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colSubject.Frozen = true;
            this.colSubject.HeaderText = "Subject";
            this.colSubject.MinimumWidth = 6;
            this.colSubject.Name = "colSubject";
            this.colSubject.ReadOnly = true;
            this.colSubject.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSubject.Width = 110;
            // 
            // colStatus
            // 
            this.colStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colStatus.FillWeight = 10F;
            this.colStatus.Frozen = true;
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colStatus.Width = 60;
            // 
            // colPriority
            // 
            this.colPriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colPriority.FillWeight = 10F;
            this.colPriority.Frozen = true;
            this.colPriority.HeaderText = "Priority";
            this.colPriority.MinimumWidth = 6;
            this.colPriority.Name = "colPriority";
            this.colPriority.ReadOnly = true;
            this.colPriority.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPriority.Width = 70;
            // 
            // colDate
            // 
            this.colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colDate.FillWeight = 14F;
            this.colDate.Frozen = true;
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDate.Width = 60;
            // 
            // InquiryListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.tlpRoot);
            this.Name = "InquiryListPanel";
            this.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.Size = new System.Drawing.Size(1100, 630);
            this.tlpRoot.ResumeLayout(false);
            this.splitMessages.Panel1.ResumeLayout(false);
            this.splitMessages.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMessages)).EndInit();
            this.splitMessages.ResumeLayout(false);
            this.listLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.pnlListActions.ResumeLayout(false);
            this.pnlConversation.ResumeLayout(false);
            this.conversationLayout.ResumeLayout(false);
            this.flpPaymentActions.ResumeLayout(false);
            this.replyLayout.ResumeLayout(false);
            this.replyLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colVehicle;
        private DataGridViewTextBoxColumn colOwner;
        private DataGridViewTextBoxColumn colSubject;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colPriority;
        private DataGridViewTextBoxColumn colDate;
    }
}
