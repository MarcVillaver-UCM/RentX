using System;
using System.Drawing;
using System.Windows.Forms;
using RentXpress.Models;
using RentXpress.Services;

namespace RentXpress.Forms
{
    public partial class VehicleCardControl : UserControl
    {
        private bool _isHovered;
        private Vehicle _vehicle;

        public event EventHandler ViewDetailsClicked;
        public event EventHandler BookClicked;

        public Vehicle Vehicle => _vehicle;

        public VehicleCardControl()
        {
            InitializeComponent();
            WireHoverEvents(this);
        }

        public void BindVehicle(Vehicle vehicle)
        {
            _vehicle = vehicle;

            lblName.Text = vehicle.Name;
            lblPrice.Text = vehicle.PriceDisplay;
            lblType.Text = vehicle.Type;
            lblSpecs.Text = $"Seats: {vehicle.Seats}   Fuel: {vehicle.FuelType}   Trans: {vehicle.Transmission}";
            lblRating.Text = $"Rating: {vehicle.Rating:F1} ({vehicle.ReviewCount / 1000.0:F1}k reviews)";
            lblImageFallback.Text = GetVehicleFallbackText(vehicle.Type);

            picVehicle.Image?.Dispose();
            picVehicle.Image = VehicleImageHelper.ImageFromBytes(vehicle.ImageData);
            lblImageFallback.Visible = picVehicle.Image == null;

            RenderTags(vehicle.Tags);
        }

        private void RenderTags(string tags)
        {
            flpTags.Controls.Clear();
            foreach (var tag in (tags ?? "").Split(','))
            {
                if (string.IsNullOrWhiteSpace(tag)) continue;

                var label = new Label
                {
                    AutoSize = true,
                    BackColor = AppTheme.Accent,
                    Cursor = Cursors.Hand,
                    Font = AppTheme.FontSmall,
                    ForeColor = AppTheme.TextPrimary,
                    Margin = new Padding(0, 0, 5, 0),
                    Padding = new Padding(6, 2, 6, 2),
                    Text = tag.Trim()
                };
                flpTags.Controls.Add(label);
            }
        }

        private static string GetVehicleFallbackText(string type)
        {
            if (string.IsNullOrWhiteSpace(type)) return "Vehicle";
            return type;
        }

        private void WireHoverEvents(Control parent)
        {
            parent.MouseEnter += VehicleCardControl_MouseEnter;
            parent.MouseLeave += VehicleCardControl_MouseLeave;

            foreach (Control child in parent.Controls)
            {
                WireHoverEvents(child);
            }
        }

        private void VehicleCardControl_MouseEnter(object sender, EventArgs e)
        {
            _isHovered = true;
            BackColor = Color.FromArgb(38, 38, 38);
            Invalidate();
        }

        private void VehicleCardControl_MouseLeave(object sender, EventArgs e)
        {
            if (ClientRectangle.Contains(PointToClient(Cursor.Position))) return;

            _isHovered = false;
            BackColor = AppTheme.BgCard;
            Invalidate();
        }

        private void VehicleCardControl_Paint(object sender, PaintEventArgs e)
        {
            var borderColor = _isHovered ? AppTheme.Accent : AppTheme.BorderColor;
            var borderWidth = _isHovered ? 2 : 1;

            using (var pen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            ViewDetailsClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            BookClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnBook_MouseEnter(object sender, EventArgs e)
        {
            btnBook.BackColor = AppTheme.AccentHover;
        }

        private void btnBook_MouseLeave(object sender, EventArgs e)
        {
            btnBook.BackColor = AppTheme.Accent;
        }
    }
}
