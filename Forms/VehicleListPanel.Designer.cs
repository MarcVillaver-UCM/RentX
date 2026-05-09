using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class VehicleListPanel
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHero;
        private Label lblSub;
        private Panel pnlSearch;
        private Label lblSearchIcon;
        private TextBox txtSearch;
        private ComboBox cmbType;
        private Label lblCount;
        private Panel pnlGrid;
        private Timer _searchTimer;

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
            this.components = new System.ComponentModel.Container();
            this.lblHero = new System.Windows.Forms.Label();
            this.lblSub = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this._searchTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHero
            // 
            this.lblHero.AutoSize = true;
            this.lblHero.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblHero.ForeColor = System.Drawing.Color.White;
            this.lblHero.Location = new System.Drawing.Point(40, 30);
            this.lblHero.Name = "lblHero";
            this.lblHero.Size = new System.Drawing.Size(331, 41);
            this.lblHero.TabIndex = 0;
            this.lblHero.Text = "Find Your Perfect Ride";
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSub.Location = new System.Drawing.Point(40, 75);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(427, 17);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Choose from our wide selection of quality vehicles for your next journey";
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.lblSearchIcon);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.cmbType);
            this.pnlSearch.Location = new System.Drawing.Point(40, 110);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(900, 56);
            this.pnlSearch.TabIndex = 2;
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.AutoSize = true;
            this.lblSearchIcon.BackColor = System.Drawing.Color.Transparent;
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSearchIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSearchIcon.Location = new System.Drawing.Point(12, 14);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(19, 21);
            this.lblSearchIcon.TabIndex = 0;
            this.lblSearchIcon.Text = "S";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.txtSearch.Location = new System.Drawing.Point(40, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(580, 17);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Search vehicles...";
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbType.ForeColor = System.Drawing.Color.White;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(650, 13);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(240, 25);
            this.cmbType.TabIndex = 2;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblCount.Location = new System.Drawing.Point(40, 180);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(64, 17);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Loading...";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnlGrid.Location = new System.Drawing.Point(40, 205);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(900, 455);
            this.pnlGrid.TabIndex = 4;
            this.pnlGrid.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGrid_Paint);
            // 
            // _searchTimer
            // 
            this._searchTimer.Interval = 400;
            this._searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            // 
            // VehicleListPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.lblSub);
            this.Controls.Add(this.lblHero);
            this.Name = "VehicleListPanel";
            this.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.Size = new System.Drawing.Size(980, 700);
            this.Resize += new System.EventHandler(this.VehicleListPanel_Resize);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

