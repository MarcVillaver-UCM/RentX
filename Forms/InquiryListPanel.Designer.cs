using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class InquiryListPanel
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgv;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colVehicle;
        private DataGridViewTextBoxColumn colOwner;
        private DataGridViewTextBoxColumn colSubject;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colPriority;
        private DataGridViewTextBoxColumn colDate;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(53, 37);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(173, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Messages";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgv.Location = new System.Drawing.Point(61, 87);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 38;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1241, 591);
            this.dgv.TabIndex = 1;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick_1);
            this.dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.Dgv_CellFormatting);
            // 
            // colId
            // 
            this.colId.FillWeight = 5F;
            this.colId.HeaderText = "ID";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colVehicle
            // 
            this.colVehicle.HeaderText = "Vehicle";
            this.colVehicle.MinimumWidth = 6;
            this.colVehicle.Name = "colVehicle";
            this.colVehicle.ReadOnly = true;
            // 
            // colOwner
            // 
            this.colOwner.HeaderText = "Owner";
            this.colOwner.MinimumWidth = 6;
            this.colOwner.Name = "colOwner";
            this.colOwner.ReadOnly = true;
            // 
            // colSubject
            // 
            this.colSubject.HeaderText = "Subject";
            this.colSubject.MinimumWidth = 6;
            this.colSubject.Name = "colSubject";
            this.colSubject.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.FillWeight = 10F;
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colPriority
            // 
            this.colPriority.FillWeight = 10F;
            this.colPriority.HeaderText = "Priority";
            this.colPriority.MinimumWidth = 6;
            this.colPriority.Name = "colPriority";
            this.colPriority.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.FillWeight = 14F;
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // InquiryListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "InquiryListPanel";
            this.Padding = new System.Windows.Forms.Padding(53, 37, 53, 37);
            this.Size = new System.Drawing.Size(1348, 738);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

