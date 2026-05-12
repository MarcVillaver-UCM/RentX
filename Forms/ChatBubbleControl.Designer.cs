using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class ChatBubbleControl
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeader;
        private Label lblBody;

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
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblBody = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = false;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblHeader.Location = new System.Drawing.Point(10, 8);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(260, 18);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Sender | Date";
            // 
            // lblBody
            // 
            this.lblBody.AutoSize = false;
            this.lblBody.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblBody.ForeColor = System.Drawing.Color.White;
            this.lblBody.Location = new System.Drawing.Point(10, 30);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(260, 40);
            this.lblBody.TabIndex = 1;
            this.lblBody.Text = "Message body";
            // 
            // ChatBubbleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblBody);
            this.Name = "ChatBubbleControl";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(280, 80);
            this.ResumeLayout(false);

        }
    }
}
