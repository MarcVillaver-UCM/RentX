using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class PaymentDialogForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblSummary;
        private ComboBox cmbMethod;
        private Label lblDetails;
        private PictureBox picQr;
        private Label lblReference;
        private TextBox txtReference;
        private Button btnSubmitProof;
        private Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                picQr?.Image?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.cmbMethod = new System.Windows.Forms.ComboBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.picQr = new System.Windows.Forms.PictureBox();
            this.lblReference = new System.Windows.Forms.Label();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.btnSubmitProof = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(24, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(197, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Payment Options";
            // 
            // lblSummary
            // 
            this.lblSummary.BackColor = System.Drawing.Color.Transparent;
            this.lblSummary.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSummary.Location = new System.Drawing.Point(24, 55);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(470, 82);
            this.lblSummary.TabIndex = 1;
            this.lblSummary.Text = "Rental summary";
            // 
            // cmbMethod
            // 
            this.cmbMethod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.cmbMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMethod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMethod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbMethod.ForeColor = System.Drawing.Color.White;
            this.cmbMethod.FormattingEnabled = true;
            this.cmbMethod.Items.AddRange(new object[] {
            "GCash",
            "Bank Transfer",
            "Cash on Delivery (COD)"});
            this.cmbMethod.Location = new System.Drawing.Point(24, 130);
            this.cmbMethod.Name = "cmbMethod";
            this.cmbMethod.Size = new System.Drawing.Size(220, 29);
            this.cmbMethod.TabIndex = 2;
            this.cmbMethod.SelectedIndexChanged += new System.EventHandler(this.cmbMethod_SelectedIndexChanged);
            // 
            // lblDetails
            // 
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblDetails.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDetails.ForeColor = System.Drawing.Color.White;
            this.lblDetails.Location = new System.Drawing.Point(24, 175);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(240, 210);
            this.lblDetails.TabIndex = 3;
            // 
            // picQr
            // 
            this.picQr.BackColor = System.Drawing.Color.White;
            this.picQr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQr.Location = new System.Drawing.Point(285, 175);
            this.picQr.Name = "picQr";
            this.picQr.Size = new System.Drawing.Size(200, 200);
            this.picQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQr.TabIndex = 4;
            this.picQr.TabStop = false;
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.BackColor = System.Drawing.Color.Transparent;
            this.lblReference.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblReference.ForeColor = System.Drawing.Color.White;
            this.lblReference.Location = new System.Drawing.Point(24, 392);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(246, 21);
            this.lblReference.TabIndex = 5;
            this.lblReference.Text = "Payment reference / proof note";
            // 
            // txtReference
            // 
            this.txtReference.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtReference.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReference.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtReference.ForeColor = System.Drawing.Color.White;
            this.txtReference.Location = new System.Drawing.Point(24, 417);
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(461, 29);
            this.txtReference.TabIndex = 6;
            // 
            // btnSubmitProof
            // 
            this.btnSubmitProof.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnSubmitProof.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitProof.FlatAppearance.BorderSize = 0;
            this.btnSubmitProof.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitProof.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmitProof.ForeColor = System.Drawing.Color.White;
            this.btnSubmitProof.Location = new System.Drawing.Point(24, 505);
            this.btnSubmitProof.Name = "btnSubmitProof";
            this.btnSubmitProof.Size = new System.Drawing.Size(180, 36);
            this.btnSubmitProof.TabIndex = 7;
            this.btnSubmitProof.Text = "Submit Payment Proof";
            this.btnSubmitProof.UseVisualStyleBackColor = false;
            this.btnSubmitProof.Click += new System.EventHandler(this.btnSubmitProof_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(395, 505);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 36);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PaymentDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(520, 570);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.cmbMethod);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.picQr);
            this.Controls.Add(this.lblReference);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.btnSubmitProof);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Proceed to Payment";
            ((System.ComponentModel.ISupportInitialize)(this.picQr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
