using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class AboutPanel
    {
        private System.ComponentModel.IContainer components = null;
        private Panel pnlHero;
        private Label lblTitle;
        private Label lblSub;
        private Panel pnlStats;
        private Label lblStory;
        private Panel pnlStory;
        private Label lblStory1;
        private Label lblValues;

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
            this.pnlHero = new System.Windows.Forms.Panel();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblSub = new System.Windows.Forms.Label();
            this.stat3 = new System.Windows.Forms.Label();
            this.stat4 = new System.Windows.Forms.Label();
            this.lblValues = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStory = new System.Windows.Forms.Label();
            this.stat1 = new System.Windows.Forms.Label();
            this.stat2 = new System.Windows.Forms.Label();
            this.pnlValues = new System.Windows.Forms.Panel();
            this.value3 = new System.Windows.Forms.Label();
            this.value1 = new System.Windows.Forms.Label();
            this.value4 = new System.Windows.Forms.Label();
            this.value2 = new System.Windows.Forms.Label();
            this.pnlStory = new System.Windows.Forms.Panel();
            this.lblStory1 = new System.Windows.Forms.Label();
            this.pnlHero.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlValues.SuspendLayout();
            this.pnlStory.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHero
            // 
            this.pnlHero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlHero.Controls.Add(this.pnlStats);
            this.pnlHero.Controls.Add(this.stat3);
            this.pnlHero.Controls.Add(this.stat4);
            this.pnlHero.Controls.Add(this.lblValues);
            this.pnlHero.Controls.Add(this.lblTitle);
            this.pnlHero.Controls.Add(this.lblStory);
            this.pnlHero.Controls.Add(this.stat1);
            this.pnlHero.Controls.Add(this.stat2);
            this.pnlHero.Controls.Add(this.pnlValues);
            this.pnlHero.Controls.Add(this.pnlStory);
            this.pnlHero.Location = new System.Drawing.Point(0, 0);
            this.pnlHero.Name = "pnlHero";
            this.pnlHero.Size = new System.Drawing.Size(1536, 808);
            this.pnlHero.TabIndex = 0;
            this.pnlHero.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHero_Paint);
            // 
            // pnlStats
            // 
            this.pnlStats.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnlStats.Controls.Add(this.lblSub);
            this.pnlStats.Location = new System.Drawing.Point(15, 63);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(1502, 120);
            this.pnlStats.TabIndex = 1;
            this.pnlStats.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStats_Paint);
            // 
            // lblSub
            // 
            this.lblSub.AutoSize = true;
            this.lblSub.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSub.Location = new System.Drawing.Point(427, 24);
            this.lblSub.Name = "lblSub";
            this.lblSub.Size = new System.Drawing.Size(580, 46);
            this.lblSub.TabIndex = 1;
            this.lblSub.Text = "Your trusted partner for convenient, affordable, and reliable vehicle rentals.\r\nW" +
    "e\'re committed to making your journey smooth and memorable.";
            this.lblSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSub.Click += new System.EventHandler(this.lblSub_Click);
            // 
            // stat3
            // 
            this.stat3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.stat3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stat3.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.stat3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.stat3.Location = new System.Drawing.Point(895, 186);
            this.stat3.Name = "stat3";
            this.stat3.Size = new System.Drawing.Size(220, 110);
            this.stat3.TabIndex = 2;
            this.stat3.Text = "50+\r\nLocations";
            this.stat3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stat3.Click += new System.EventHandler(this.stat3_Click);
            // 
            // stat4
            // 
            this.stat4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.stat4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stat4.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.stat4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.stat4.Location = new System.Drawing.Point(1212, 186);
            this.stat4.Name = "stat4";
            this.stat4.Size = new System.Drawing.Size(220, 110);
            this.stat4.TabIndex = 3;
            this.stat4.Text = "4.8/5\r\nAverage Rating";
            this.stat4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stat4.Click += new System.EventHandler(this.stat4_Click);
            // 
            // lblValues
            // 
            this.lblValues.AutoSize = true;
            this.lblValues.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblValues.ForeColor = System.Drawing.Color.White;
            this.lblValues.Location = new System.Drawing.Point(697, 492);
            this.lblValues.Name = "lblValues";
            this.lblValues.Size = new System.Drawing.Size(169, 41);
            this.lblValues.TabIndex = 4;
            this.lblValues.Text = "Our Values";
            this.lblValues.Click += new System.EventHandler(this.lblValues_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(583, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(398, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "About RentXpress";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // lblStory
            // 
            this.lblStory.AutoSize = true;
            this.lblStory.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblStory.ForeColor = System.Drawing.Color.White;
            this.lblStory.Location = new System.Drawing.Point(712, 305);
            this.lblStory.Name = "lblStory";
            this.lblStory.Size = new System.Drawing.Size(154, 41);
            this.lblStory.TabIndex = 2;
            this.lblStory.Text = "Our Story";
            this.lblStory.Click += new System.EventHandler(this.lblStory_Click);
            // 
            // stat1
            // 
            this.stat1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.stat1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stat1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.stat1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.stat1.Location = new System.Drawing.Point(176, 186);
            this.stat1.Name = "stat1";
            this.stat1.Size = new System.Drawing.Size(220, 110);
            this.stat1.TabIndex = 0;
            this.stat1.Text = "100,000+\r\nHappy Customers";
            this.stat1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stat1.Click += new System.EventHandler(this.stat1_Click);
            // 
            // stat2
            // 
            this.stat2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.stat2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stat2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.stat2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.stat2.Location = new System.Drawing.Point(537, 186);
            this.stat2.Name = "stat2";
            this.stat2.Size = new System.Drawing.Size(220, 110);
            this.stat2.TabIndex = 1;
            this.stat2.Text = "500+\r\nVehicles Available";
            this.stat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stat2.Click += new System.EventHandler(this.stat2_Click);
            // 
            // pnlValues
            // 
            this.pnlValues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.pnlValues.Controls.Add(this.value3);
            this.pnlValues.Controls.Add(this.value1);
            this.pnlValues.Controls.Add(this.value4);
            this.pnlValues.Controls.Add(this.value2);
            this.pnlValues.Location = new System.Drawing.Point(15, 560);
            this.pnlValues.Name = "pnlValues";
            this.pnlValues.Size = new System.Drawing.Size(1505, 120);
            this.pnlValues.TabIndex = 5;
            this.pnlValues.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlValues_Paint);
            // 
            // value3
            // 
            this.value3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.value3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.value3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.value3.ForeColor = System.Drawing.Color.White;
            this.value3.Location = new System.Drawing.Point(161, 0);
            this.value3.Name = "value3";
            this.value3.Size = new System.Drawing.Size(215, 120);
            this.value3.TabIndex = 2;
            this.value3.Text = "Quality Service\r\nSupport when needed.";
            this.value3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.value3.Click += new System.EventHandler(this.value3_Click);
            // 
            // value1
            // 
            this.value1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.value1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.value1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.value1.ForeColor = System.Drawing.Color.White;
            this.value1.Location = new System.Drawing.Point(527, 0);
            this.value1.Name = "value1";
            this.value1.Size = new System.Drawing.Size(215, 120);
            this.value1.TabIndex = 0;
            this.value1.Text = "Safety First\r\nEvery vehicle is inspected.";
            this.value1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.value1.Click += new System.EventHandler(this.value1_Click);
            // 
            // value4
            // 
            this.value4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.value4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.value4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.value4.ForeColor = System.Drawing.Color.White;
            this.value4.Location = new System.Drawing.Point(885, 0);
            this.value4.Name = "value4";
            this.value4.Size = new System.Drawing.Size(215, 120);
            this.value4.TabIndex = 3;
            this.value4.Text = "Eco-Friendly\r\nHybrid and electric fleet.";
            this.value4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.value4.Click += new System.EventHandler(this.value4_Click);
            // 
            // value2
            // 
            this.value2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.value2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.value2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.value2.ForeColor = System.Drawing.Color.White;
            this.value2.Location = new System.Drawing.Point(1202, 0);
            this.value2.Name = "value2";
            this.value2.Size = new System.Drawing.Size(215, 120);
            this.value2.TabIndex = 1;
            this.value2.Text = "Transparent Pricing\r\nNo hidden fees.";
            this.value2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.value2.Click += new System.EventHandler(this.value2_Click);
            // 
            // pnlStory
            // 
            this.pnlStory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlStory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlStory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStory.Controls.Add(this.lblStory1);
            this.pnlStory.Location = new System.Drawing.Point(24, 349);
            this.pnlStory.Name = "pnlStory";
            this.pnlStory.Padding = new System.Windows.Forms.Padding(20);
            this.pnlStory.Size = new System.Drawing.Size(1502, 130);
            this.pnlStory.TabIndex = 3;
            this.pnlStory.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStory_Paint);
            // 
            // lblStory1
            // 
            this.lblStory1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStory1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblStory1.Location = new System.Drawing.Point(309, 32);
            this.lblStory1.Name = "lblStory1";
            this.lblStory1.Size = new System.Drawing.Size(917, 86);
            this.lblStory1.TabIndex = 0;
            this.lblStory1.Text = "Founded in 2020, RentXpress was born from a simple idea: making vehicle rentals a" +
    "ccessible, transparent, and hassle-free for everyone. Today, we serve thousands " +
    "of customers across multiple locations.";
            this.lblStory1.Click += new System.EventHandler(this.lblStory1_Click);
            // 
            // AboutPanel
            // 
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.pnlHero);
            this.Name = "AboutPanel";
            this.Size = new System.Drawing.Size(1979, 709);
            this.Load += new System.EventHandler(this.AboutPanel_Load);
            this.pnlHero.ResumeLayout(false);
            this.pnlHero.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.pnlValues.ResumeLayout(false);
            this.pnlStory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Label stat1;
        private Label value1;
        private Label stat3;
        private Label stat4;
        private Label stat2;
        private Panel pnlValues;
        private Label value3;
        private Label value4;
        private Label value2;
    }
}

