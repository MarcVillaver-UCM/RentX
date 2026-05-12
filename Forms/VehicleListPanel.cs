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
            if (pnlGrid == null) return;

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
                var card = new VehicleCardControl
                {
                    Location = new Point(col * (cardW + colGap), row * (cardH + rowGap)),
                    Size = new Size(cardW, cardH)
                };
                card.BindVehicle(v);
                card.ViewDetailsClicked += (s, e) => OpenDetails(((VehicleCardControl)s).Vehicle);
                card.BookClicked += (s, e) => OpenInquiry(((VehicleCardControl)s).Vehicle);
                pnlGrid.Controls.Add(card);
                col++;
                if (col >= cols) { col = 0; row++; }
            }

            int totalH = (row + 1) * (cardH + rowGap);
            pnlGrid.AutoScrollMinSize = new Size(0, totalH);
            pnlGrid.AutoScroll = true;
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
            RenderCards();
        }

        private void pnlGrid_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}



