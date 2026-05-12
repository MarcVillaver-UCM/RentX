using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class VehicleCardControl
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlImage;
        private PictureBox picVehicle;
        private Label lblImageFallback;
        private FlowLayoutPanel flpTags;
        private Label lblName;
        private Label lblPrice;
        private Label lblType;
        private Label lblSpecs;
        private Label lblRating;
        private Button btnDetails;
        private Button btnBook;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                picVehicle?.Image?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlImage = new System.Windows.Forms.Panel();
            this.picVehicle = new System.Windows.Forms.PictureBox();
            this.lblImageFallback = new System.Windows.Forms.Label();
            this.flpTags = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblSpecs = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.btnDetails = new System.Windows.Forms.Button();
            this.btnBook = new System.Windows.Forms.Button();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlImage
            // 
            this.pnlImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.pnlImage.Controls.Add(this.picVehicle);
            this.pnlImage.Controls.Add(this.lblImageFallback);
            this.pnlImage.Controls.Add(this.flpTags);
            this.pnlImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlImage.Location = new System.Drawing.Point(0, 0);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(320, 145);
            this.pnlImage.TabIndex = 0;
            // 
            // picVehicle
            // 
            this.picVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.picVehicle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picVehicle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picVehicle.Location = new System.Drawing.Point(0, 0);
            this.picVehicle.Name = "picVehicle";
            this.picVehicle.Size = new System.Drawing.Size(320, 145);
            this.picVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVehicle.TabIndex = 0;
            this.picVehicle.TabStop = false;
            // 
            // lblImageFallback
            // 
            this.lblImageFallback.BackColor = System.Drawing.Color.Transparent;
            this.lblImageFallback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblImageFallback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImageFallback.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblImageFallback.ForeColor = System.Drawing.Color.White;
            this.lblImageFallback.Location = new System.Drawing.Point(0, 0);
            this.lblImageFallback.Name = "lblImageFallback";
            this.lblImageFallback.Size = new System.Drawing.Size(320, 145);
            this.lblImageFallback.TabIndex = 1;
            this.lblImageFallback.Text = "Vehicle";
            this.lblImageFallback.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flpTags
            // 
            this.flpTags.AutoSize = true;
            this.flpTags.BackColor = System.Drawing.Color.Transparent;
            this.flpTags.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flpTags.Location = new System.Drawing.Point(10, 8);
            this.flpTags.Name = "flpTags";
            this.flpTags.Size = new System.Drawing.Size(290, 26);
            this.flpTags.TabIndex = 2;
            this.flpTags.WrapContents = false;
            // 
            // lblName
            // 
            this.lblName.AutoEllipsis = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(12, 150);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(205, 28);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Vehicle Name";
            // 
            // lblPrice
            // 
            this.lblPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.lblPrice.Location = new System.Drawing.Point(215, 152);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(95, 24);
            this.lblPrice.TabIndex = 2;
            this.lblPrice.Text = "PHP 0/day";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblType
            // 
            this.lblType.AutoEllipsis = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblType.Location = new System.Drawing.Point(12, 174);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(296, 22);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Type";
            // 
            // lblSpecs
            // 
            this.lblSpecs.AutoEllipsis = true;
            this.lblSpecs.BackColor = System.Drawing.Color.Transparent;
            this.lblSpecs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSpecs.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSpecs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSpecs.Location = new System.Drawing.Point(12, 196);
            this.lblSpecs.Name = "lblSpecs";
            this.lblSpecs.Size = new System.Drawing.Size(296, 24);
            this.lblSpecs.TabIndex = 4;
            this.lblSpecs.Text = "Seats: 0   Fuel: -   Trans: -";
            // 
            // lblRating
            // 
            this.lblRating.AutoEllipsis = true;
            this.lblRating.BackColor = System.Drawing.Color.Transparent;
            this.lblRating.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRating.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRating.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.lblRating.Location = new System.Drawing.Point(12, 220);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(296, 24);
            this.lblRating.TabIndex = 5;
            this.lblRating.Text = "Rating: 0.0";
            // 
            // btnDetails
            // 
            this.btnDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetails.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Location = new System.Drawing.Point(10, 250);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(130, 34);
            this.btnDetails.TabIndex = 6;
            this.btnDetails.Text = "View Details";
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnBook
            // 
            this.btnBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnBook.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBook.FlatAppearance.BorderSize = 0;
            this.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBook.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBook.ForeColor = System.Drawing.Color.White;
            this.btnBook.Location = new System.Drawing.Point(175, 250);
            this.btnBook.Name = "btnBook";
            this.btnBook.Size = new System.Drawing.Size(130, 34);
            this.btnBook.TabIndex = 7;
            this.btnBook.Text = "Book Now";
            this.btnBook.UseVisualStyleBackColor = false;
            this.btnBook.Click += new System.EventHandler(this.btnBook_Click);
            this.btnBook.MouseEnter += new System.EventHandler(this.btnBook_MouseEnter);
            this.btnBook.MouseLeave += new System.EventHandler(this.btnBook_MouseLeave);
            // 
            // VehicleCardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.Controls.Add(this.pnlImage);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblSpecs);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnBook);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "VehicleCardControl";
            this.Size = new System.Drawing.Size(320, 328);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VehicleCardControl_Paint);
            this.pnlImage.ResumeLayout(false);
            this.pnlImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
