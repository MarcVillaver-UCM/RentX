using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class InquiryForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlMain;
        private Label title;
        private Label lblVehicleName;
        private Label lblOwner;
        private Panel sep;
        private Label lblSubject;
        private TextBox txtSubject;
        private Label lblMsg;
        private TextBox txtMessage;
        // NEW CODE
        private Label lblDays;
        private NumericUpDown nudNumberOfDays;
        private CheckBox chkEmergency;
        private Label lblEmergencyWarning;
        private Panel pnlEmergency;
        private Label lblPrio;
        private ComboBox cmbPriority;
        // NEW CODE
        private Label lblBasePrice;
        private Label lblSurcharge;
        private Label lblTotalPrice;
        private Label lblPayment;
        private ComboBox cmbPaymentMethod;
        private Label lblError;
        private Button btnSend;
        private Button btnCancel;

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
            this.title = new System.Windows.Forms.Label();
            this.lblVehicleName = new System.Windows.Forms.Label();
            this.lblOwner = new System.Windows.Forms.Label();
            this.sep = new System.Windows.Forms.Panel();
            this.lblSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblDays = new System.Windows.Forms.Label();
            this.nudNumberOfDays = new System.Windows.Forms.NumericUpDown();
            this.chkEmergency = new System.Windows.Forms.CheckBox();
            this.lblEmergencyWarning = new System.Windows.Forms.Label();
            this.pnlEmergency = new System.Windows.Forms.Panel();
            this.lblPrio = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblBasePrice = new System.Windows.Forms.Label();
            this.lblSurcharge = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblError = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlEmergency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfDays)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.title);
            this.pnlMain.Controls.Add(this.lblVehicleName);
            this.pnlMain.Controls.Add(this.lblOwner);
            this.pnlMain.Controls.Add(this.sep);
            this.pnlMain.Controls.Add(this.lblSubject);
            this.pnlMain.Controls.Add(this.txtSubject);
            this.pnlMain.Controls.Add(this.lblMsg);
            this.pnlMain.Controls.Add(this.txtMessage);
            this.pnlMain.Controls.Add(this.lblDays);
            this.pnlMain.Controls.Add(this.nudNumberOfDays);
            this.pnlMain.Controls.Add(this.chkEmergency);
            this.pnlMain.Controls.Add(this.lblEmergencyWarning);
            this.pnlMain.Controls.Add(this.pnlEmergency);
            this.pnlMain.Controls.Add(this.lblBasePrice);
            this.pnlMain.Controls.Add(this.lblSurcharge);
            this.pnlMain.Controls.Add(this.lblTotalPrice);
            this.pnlMain.Controls.Add(this.lblPayment);
            this.pnlMain.Controls.Add(this.cmbPaymentMethod);
            this.pnlMain.Controls.Add(this.lblError);
            this.pnlMain.Controls.Add(this.btnSend);
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(30);
            this.pnlMain.Size = new System.Drawing.Size(560, 740);
            this.pnlMain.TabIndex = 0;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(30, 50);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(180, 37);
            this.title.TabIndex = 0;
            this.title.Text = "Send Inquiry";
            // 
            // lblVehicleName
            // 
            this.lblVehicleName.AutoSize = true;
            this.lblVehicleName.BackColor = System.Drawing.Color.Transparent;
            this.lblVehicleName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblVehicleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.lblVehicleName.Location = new System.Drawing.Point(30, 95);
            this.lblVehicleName.Name = "lblVehicleName";
            this.lblVehicleName.Size = new System.Drawing.Size(131, 25);
            this.lblVehicleName.TabIndex = 1;
            this.lblVehicleName.Text = "Vehicle Name";
            // 
            // lblOwner
            // 
            this.lblOwner.AutoSize = true;
            this.lblOwner.BackColor = System.Drawing.Color.Transparent;
            this.lblOwner.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblOwner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblOwner.Location = new System.Drawing.Point(30, 121);
            this.lblOwner.Name = "lblOwner";
            this.lblOwner.Size = new System.Drawing.Size(46, 17);
            this.lblOwner.TabIndex = 2;
            this.lblOwner.Text = "Owner";
            // 
            // sep
            // 
            this.sep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.sep.Location = new System.Drawing.Point(30, 156);
            this.sep.Name = "sep";
            this.sep.Size = new System.Drawing.Size(480, 1);
            this.sep.TabIndex = 3;
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.BackColor = System.Drawing.Color.Transparent;
            this.lblSubject.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubject.ForeColor = System.Drawing.Color.White;
            this.lblSubject.Location = new System.Drawing.Point(30, 171);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(50, 17);
            this.lblSubject.TabIndex = 4;
            this.lblSubject.Text = "Subject";
            // 
            // txtSubject
            // 
            this.txtSubject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubject.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSubject.ForeColor = System.Drawing.Color.White;
            this.txtSubject.Location = new System.Drawing.Point(30, 193);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(480, 24);
            this.txtSubject.TabIndex = 5;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblMsg.ForeColor = System.Drawing.Color.White;
            this.lblMsg.Location = new System.Drawing.Point(30, 238);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(61, 17);
            this.lblMsg.TabIndex = 6;
            this.lblMsg.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMessage.ForeColor = System.Drawing.Color.White;
            this.txtMessage.Location = new System.Drawing.Point(30, 260);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(480, 100);
            this.txtMessage.TabIndex = 7;
            // 
            // lblDays
            // 
            // NEW CODE
            // Required rental duration. NumericUpDown prevents empty/non-numeric input.
            this.lblDays.AutoSize = true;
            this.lblDays.BackColor = System.Drawing.Color.Transparent;
            this.lblDays.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDays.ForeColor = System.Drawing.Color.White;
            this.lblDays.Location = new System.Drawing.Point(30, 372);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(102, 17);
            this.lblDays.TabIndex = 19;
            this.lblDays.Text = "Number of Days";
            // 
            // nudNumberOfDays
            // 
            this.nudNumberOfDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.nudNumberOfDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudNumberOfDays.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudNumberOfDays.ForeColor = System.Drawing.Color.White;
            this.nudNumberOfDays.Location = new System.Drawing.Point(30, 394);
            this.nudNumberOfDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfDays.Name = "nudNumberOfDays";
            this.nudNumberOfDays.Size = new System.Drawing.Size(120, 24);
            this.nudNumberOfDays.TabIndex = 20;
            this.nudNumberOfDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumberOfDays.ValueChanged += new System.EventHandler(this.nudNumberOfDays_ValueChanged);
            // 
            // chkEmergency
            // 
            this.chkEmergency.AutoSize = true;
            this.chkEmergency.BackColor = System.Drawing.Color.Transparent;
            this.chkEmergency.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.chkEmergency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.chkEmergency.Location = new System.Drawing.Point(30, 430);
            this.chkEmergency.Name = "chkEmergency";
            this.chkEmergency.Size = new System.Drawing.Size(157, 21);
            this.chkEmergency.TabIndex = 8;
            this.chkEmergency.Text = "Urgent Booking (+5%)";
            this.chkEmergency.UseVisualStyleBackColor = false;
            this.chkEmergency.CheckedChanged += new System.EventHandler(this.chkEmergency_CheckedChanged);
            // 
            // lblEmergencyWarning
            // 
            this.lblEmergencyWarning.AutoSize = true;
            this.lblEmergencyWarning.BackColor = System.Drawing.Color.Transparent;
            this.lblEmergencyWarning.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblEmergencyWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblEmergencyWarning.Location = new System.Drawing.Point(30, 460);
            this.lblEmergencyWarning.Name = "lblEmergencyWarning";
            this.lblEmergencyWarning.Size = new System.Drawing.Size(349, 15);
            this.lblEmergencyWarning.TabIndex = 9;
            this.lblEmergencyWarning.Text = "Urgent bookings notify the owner faster and add a 5% surcharge.";
            this.lblEmergencyWarning.Visible = false;
            // 
            // pnlEmergency
            // 
            this.pnlEmergency.BackColor = System.Drawing.Color.Transparent;
            this.pnlEmergency.Controls.Add(this.lblPrio);
            this.pnlEmergency.Controls.Add(this.cmbPriority);
            this.pnlEmergency.Location = new System.Drawing.Point(30, 482);
            this.pnlEmergency.Name = "pnlEmergency";
            this.pnlEmergency.Size = new System.Drawing.Size(480, 46);
            this.pnlEmergency.TabIndex = 10;
            this.pnlEmergency.Visible = false;
            // 
            // lblPrio
            // 
            this.lblPrio.AutoSize = true;
            this.lblPrio.BackColor = System.Drawing.Color.Transparent;
            this.lblPrio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPrio.ForeColor = System.Drawing.Color.White;
            this.lblPrio.Location = new System.Drawing.Point(0, 12);
            this.lblPrio.Name = "lblPrio";
            this.lblPrio.Size = new System.Drawing.Size(85, 17);
            this.lblPrio.TabIndex = 0;
            this.lblPrio.Text = "Priority Level:";
            // 
            // cmbPriority
            // 
            this.cmbPriority.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPriority.ForeColor = System.Drawing.Color.White;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Items.AddRange(new object[] {
            "high",
            "critical"});
            this.cmbPriority.Location = new System.Drawing.Point(109, 12);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(180, 21);
            this.cmbPriority.TabIndex = 1;
            this.cmbPriority.SelectedIndexChanged += new System.EventHandler(this.cmbPriority_SelectedIndexChanged);
            // 
            // lblBasePrice
            // 
            this.lblBasePrice.AutoSize = true;
            this.lblBasePrice.BackColor = System.Drawing.Color.Transparent;
            this.lblBasePrice.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBasePrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblBasePrice.Location = new System.Drawing.Point(30, 534);
            this.lblBasePrice.Name = "lblBasePrice";
            this.lblBasePrice.Size = new System.Drawing.Size(73, 17);
            this.lblBasePrice.TabIndex = 14;
            this.lblBasePrice.Text = "Base: $0.00";
            // 
            // lblSurcharge
            // 
            this.lblSurcharge.AutoSize = true;
            this.lblSurcharge.BackColor = System.Drawing.Color.Transparent;
            this.lblSurcharge.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSurcharge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSurcharge.Location = new System.Drawing.Point(30, 558);
            this.lblSurcharge.Name = "lblSurcharge";
            this.lblSurcharge.Size = new System.Drawing.Size(117, 17);
            this.lblSurcharge.TabIndex = 15;
            this.lblSurcharge.Text = "Platform fee: $0.00";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalPrice.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.lblTotalPrice.Location = new System.Drawing.Point(350, 546);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(114, 25);
            this.lblTotalPrice.TabIndex = 16;
            this.lblTotalPrice.Text = "Total: $0.00";
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.BackColor = System.Drawing.Color.Transparent;
            this.lblPayment.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPayment.ForeColor = System.Drawing.Color.White;
            this.lblPayment.Location = new System.Drawing.Point(30, 592);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(107, 17);
            this.lblPayment.TabIndex = 17;
            this.lblPayment.Text = "Payment Method";
            // 
            // cmbPaymentMethod
            // 
            this.cmbPaymentMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPaymentMethod.ForeColor = System.Drawing.Color.White;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Cash",
            "GCash",
            "Bank Transfer"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(30, 616);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(220, 25);
            this.cmbPaymentMethod.TabIndex = 18;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblError.Location = new System.Drawing.Point(30, 662);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(480, 20);
            this.lblError.TabIndex = 11;
            this.lblError.Visible = false;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSend.ForeColor = System.Drawing.Color.White;
            this.btnSend.Location = new System.Drawing.Point(30, 684);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(220, 40);
            this.btnSend.TabIndex = 12;
            this.btnSend.Text = "Send Inquiry";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(410, 684);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // InquiryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(560, 740);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "InquiryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Send Inquiry";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlEmergency.ResumeLayout(false);
            this.pnlEmergency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfDays)).EndInit();
            this.ResumeLayout(false);

        }
    }
}

