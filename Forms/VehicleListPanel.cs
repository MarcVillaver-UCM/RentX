using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RentXpress.Models;
using RentXpress.Services;

namespace RentXpress.Forms
{
    public partial class VehicleListPanel : UserControl
    {
        private readonly VehicleService _vehicleService = new VehicleService();
        private readonly MainForm _mainForm;
        private List<Vehicle> _vehicles = new List<Vehicle>();

        public VehicleListPanel()
        {
            InitializeComponent();
        }

        public VehicleListPanel(MainForm mainForm)
        {
            _mainForm = mainForm;
            this.BackColor = AppTheme.BgDark;
            this.Padding = new Padding(40, 30, 40, 30);
            InitializeComponent();
            LoadTypeFilter();
            LoadVehicles();
        }



        private void ResizeGrid()
        {
            pnlGrid.Size = new Size(this.Width - 80, this.Height - 210);
            RenderCards();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            _searchTimer.Start();
        }

        private void LoadTypeFilter()
        {
            try
            {
                cmbType.Items.Clear();
                foreach (var t in _vehicleService.GetTypes())
                    cmbType.Items.Add(t);
                if (cmbType.Items.Count > 0) cmbType.SelectedIndex = 0;
            }
            catch { cmbType.Items.Add("All Types"); cmbType.SelectedIndex = 0; }
        }

        private void LoadVehicles()
        {
            try
            {
                string search = txtSearch.Text == "Search vehicles..." ? "" : txtSearch.Text;
                string type = cmbType.SelectedItem?.ToString() ?? "All Types";
                _vehicles = _vehicleService.GetAll(search, type);
                lblCount.Text = $"{_vehicles.Count} vehicle{(_vehicles.Count != 1 ? "s" : "")} available";
                RenderCards();
            }
            catch (Exception ex)
            {
                lblCount.Text = "Error loading vehicles";
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderCards()
        {
            pnlGrid.Controls.Clear();
            if (_vehicles.Count == 0)
            {
                var lbl = new Label { Text = "No vehicles found.", Font = AppTheme.FontH2, ForeColor = AppTheme.TextSecondary, AutoSize = true, Location = new Point(300, 100) };
                pnlGrid.Controls.Add(lbl);
                return;
            }

            int cardW = 320, cardH = 320, colGap = 20, rowGap = 20;
            int cols = Math.Max(1, (pnlGrid.Width + colGap) / (cardW + colGap));
            int row = 0, col = 0;

            foreach (var v in _vehicles)
            {
                var card = BuildVehicleCard(v, col * (cardW + colGap), row * (cardH + rowGap), cardW, cardH);
                pnlGrid.Controls.Add(card);
                col++;
                if (col >= cols) { col = 0; row++; }
            }

            int totalH = (row + 1) * (cardH + rowGap);
            pnlGrid.AutoScrollMinSize = new Size(0, totalH);
            pnlGrid.AutoScroll = true;
        }

        private void ApplyCardHoverToChildren(Control parent, EventHandler enter, EventHandler leave)
        {
            foreach (Control child in parent.Controls)
            {
                child.MouseEnter += enter;
                child.MouseLeave += leave;

                if (child.HasChildren)
                {
                    ApplyCardHoverToChildren(child, enter, leave);
                }
            }
        }



        private Panel BuildVehicleCard(Vehicle v, int x, int y, int w, int h)
        {
            var card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(w, h),
                BackColor = AppTheme.BgCard,
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand
            };

            bool isHovered = false;

            EventHandler mouseEnter = (s, e) =>
            {
                isHovered = true;
                card.BackColor = Color.FromArgb(38, 38, 38);
                card.Invalidate();
            };

            EventHandler mouseLeave = (s, e) =>
            {
                if (!card.ClientRectangle.Contains(card.PointToClient(Cursor.Position)))
                {
                    isHovered = false;
                    card.BackColor = AppTheme.BgCard;
                    card.Invalidate();
                }
            };

            card.Paint += (s, e) =>
            {
                var borderColor = isHovered ? AppTheme.Accent : AppTheme.BorderColor;
                var borderWidth = isHovered ? 2 : 1;

                using (var pen = new Pen(borderColor, borderWidth))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            card.MouseEnter += mouseEnter;
            card.MouseLeave += mouseLeave;

            var imgPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(w, 145),
                BackColor = Color.FromArgb(50, 50, 50),
                Cursor = Cursors.Hand
            };

            var picture = new PictureBox
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(50, 50, 50),
                SizeMode = PictureBoxSizeMode.Zoom,
                Cursor = Cursors.Hand
            };

            picture.Image = VehicleImageHelper.ImageFromBytes(v.ImageData);
            imgPanel.Controls.Add(picture);

            if (picture.Image == null)
            {
                var imgLabel = new Label
                {
                    Text = GetVehicleEmoji(v.Type),
                    Font = new Font("Segoe UI Emoji", 48f),
                    AutoSize = true,
                    BackColor = Color.Transparent,
                    Location = new Point(w / 2 - 50, 25),
                    Cursor = Cursors.Hand
                };

                imgPanel.Controls.Add(imgLabel);
                imgLabel.BringToFront();
            }

            int tagX = 10;
            foreach (var tag in (v.Tags ?? "").Split(','))
            {
                if (string.IsNullOrWhiteSpace(tag)) continue;

                var tagLbl = new Label
                {
                    Text = tag.Trim(),
                    Font = AppTheme.FontSmall,
                    ForeColor = AppTheme.TextPrimary,
                    BackColor = AppTheme.Accent,
                    AutoSize = true,
                    Padding = new Padding(6, 2, 6, 2),
                    Location = new Point(tagX, 8),
                    Cursor = Cursors.Hand
                };

                imgPanel.Controls.Add(tagLbl);
                tagX += tagLbl.Width + 5;
            }

            int cy = 150;

            var lblName = new Label
            {
                Text = v.Name,
                Font = AppTheme.FontH2,
                ForeColor = AppTheme.TextPrimary,
                AutoSize = true,
                Location = new Point(12, cy),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            var lblPrice = new Label
            {
                Text = v.PriceDisplay,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = AppTheme.Accent,
                AutoSize = true,
                Location = new Point(w - 95, cy),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            cy += 24;

            var lblType = new Label
            {
                Text = v.Type,
                Font = AppTheme.FontSmall,
                ForeColor = AppTheme.TextSecondary,
                AutoSize = true,
                Location = new Point(12, cy),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            cy += 22;

            var lblSpecs = new Label
            {
                Text = $"👥 {v.Seats}   ⛽ {v.FuelType}   ⚙ {v.Transmission}",
                Font = AppTheme.FontSmall,
                ForeColor = AppTheme.TextSecondary,
                AutoSize = true,
                Location = new Point(12, cy),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            cy += 24;

            var lblRating = new Label
            {
                Text = $"⭐ {v.Rating:F1} ({v.ReviewCount / 1000.0:F1}k reviews)",
                Font = AppTheme.FontSmall,
                ForeColor = AppTheme.StarColor,
                AutoSize = true,
                Location = new Point(12, cy),
                BackColor = Color.Transparent,
                Cursor = Cursors.Hand
            };

            cy += 30;

            var btnDetails = new Button
            {
                Text = "View Details",
                Font = AppTheme.FontBody,
                BackColor = AppTheme.BgInput,
                ForeColor = AppTheme.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 34),
                Location = new Point(10, cy),
                Cursor = Cursors.Hand
            };

            btnDetails.FlatAppearance.BorderColor = AppTheme.BorderColor;
            btnDetails.FlatAppearance.BorderSize = 1;
            btnDetails.Click += (s, e) => OpenDetails(v);

            var btnBook = new Button
            {
                Text = "Book Now",
                Font = AppTheme.FontButton,
                BackColor = AppTheme.Accent,
                ForeColor = AppTheme.TextPrimary,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(130, 34),
                Location = new Point(w - 145, cy),
                Cursor = Cursors.Hand
            };

            btnBook.FlatAppearance.BorderSize = 0;
            btnBook.MouseEnter += (s, e) => btnBook.BackColor = AppTheme.AccentHover;
            btnBook.MouseLeave += (s, e) => btnBook.BackColor = AppTheme.Accent;
            btnBook.Click += (s, e) => OpenInquiry(v);

            card.Controls.AddRange(new Control[]
            {
        imgPanel,
        lblName,
        lblPrice,
        lblType,
        lblSpecs,
        lblRating,
        btnDetails,
        btnBook
            });

            ApplyCardHoverToChildren(card, mouseEnter, mouseLeave);

            return card;
        }



        private string GetVehicleEmoji(string type)
        {
            switch (type?.ToLower())
            {
                case "suv": return "ðŸš™";
                case "electric": return "âš¡ðŸš—";
                case "truck": return "ðŸš›";
                case "hatchback": return "ðŸš—";
                default: return "ðŸš—";
            }
        }

        private void OpenDetails(Vehicle v)
        {
            var dlg = new VehicleDetailForm(v, _mainForm);
            dlg.ShowDialog(_mainForm);
        }

        private void OpenInquiry(Vehicle v)
        {
            if (!Session.IsLoggedIn)
            {
                MessageBox.Show("Please log in to send an inquiry.", "Login Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var dlg = new InquiryForm(v);
            dlg.ShowDialog(_mainForm);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVehicles();
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            _searchTimer.Stop();
            LoadVehicles();
        }

        private void VehicleListPanel_Resize(object sender, EventArgs e)
        {
            ResizeGrid();
        }

        private void pnlGrid_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}



