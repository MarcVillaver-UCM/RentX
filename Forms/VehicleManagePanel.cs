using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using RentXpress.Models;
using RentXpress.Services;

namespace RentXpress.Forms
{
    public partial class VehicleManagePanel : UserControl
    {
        private readonly VehicleService _vehicleService = new VehicleService();
        private readonly MainForm _mainForm;
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();
        private Vehicle _selectedVehicle;
        private byte[] _selectedImageBytes;

        public VehicleManagePanel()
        {
            InitializeComponent();
            if (!IsDesignerHosted()) LoadVehicles();
        }

        public VehicleManagePanel(MainForm mainForm)
        {
            _mainForm = mainForm;
            InitializeComponent();
            if (!IsDesignerHosted()) LoadVehicles();
        }

        private bool IsDesignerHosted()
        {
            return DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime;
        }

        private void LoadVehicles()
        {
            try
            {
                if (!Session.IsLoggedIn || Session.CurrentUser == null)
                {
                    ShowStatus("Please log in to manage your vehicles.", true);
                    return;
                }

                _vehicles.Clear();
                _vehicles.AddRange(_vehicleService.GetByOwner(Session.CurrentUser.Id));
                dgvVehicles.Rows.Clear();
                foreach (var v in _vehicles) dgvVehicles.Rows.Add(v.Id, v.Name, v.Type, v.PriceDisplay, v.Status);
                lblStatus.ForeColor = AppTheme.TextSecondary;
                lblStatus.Text = _vehicles.Count == 0 ? "No vehicles yet. Add your first vehicle on the right." : $"{_vehicles.Count} vehicle(s) loaded.";
                if (_vehicles.Count == 0) ClearForm();
            }
            catch (Exception ex) { ShowStatus(ex.Message, true); }
        }

        private void dgvVehicles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVehicles.SelectedRows.Count == 0) return;
            int id = Convert.ToInt32(dgvVehicles.SelectedRows[0].Cells["Id"].Value);
            var vehicle = _vehicles.Find(v => v.Id == id);
            if (vehicle != null) PopulateForm(vehicle);
        }

        private void PopulateForm(Vehicle v)
        {
            _selectedVehicle = v;
            _selectedImageBytes = v.ImageData;
            txtName.Text = v.Name;
            cmbType.Text = v.Type;
            txtFuel.Text = v.FuelType;
            cmbTransmission.Text = v.Transmission;
            nudSeats.Value = Math.Min(nudSeats.Maximum, Math.Max(nudSeats.Minimum, v.Seats));
            nudPrice.Value = Math.Min(nudPrice.Maximum, Math.Max(nudPrice.Minimum, v.PricePerDay));
            cmbStatus.Text = v.Status;
            txtTags.Text = v.Tags;
            // NEW CODE
            txtLocation.Text = v.CurrentLocation;
            txtDescription.Text = v.Description;
            SetPreview(_selectedImageBytes);
            // MODIFIED CODE
            // Selecting a row means the detail panel is now editing that existing vehicle.
            btnSave.Text = "Edit Vehicle";
            ShowStatus($"Editing {v.Name}", false);
        }

        private void ClearForm()
        {
            _selectedVehicle = null;
            _selectedImageBytes = null;
            txtName.Text = "";
            cmbType.SelectedIndex = 0;
            txtFuel.Text = "Gasoline";
            cmbTransmission.SelectedIndex = 0;
            nudSeats.Value = 5;
            nudPrice.Value = 50;
            cmbStatus.SelectedIndex = 0;
            txtTags.Text = "";
            // NEW CODE
            txtLocation.Text = "";
            txtDescription.Text = "";
            SetPreview(null);
            dgvVehicles.ClearSelection();
            // MODIFIED CODE
            // No selected vehicle means Save will insert a new row for the current owner_id.
            btnSave.Text = "Save Vehicle";
            ShowStatus("Ready to add a vehicle.", false);
        }

        // NEW CODE
        // Add Vehicle does not create a database row immediately. It resets the form into
        // insert mode, then btnSave_Click saves the new vehicle with Session.CurrentUser.Id.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtName.Focus();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Choose vehicle image";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (dialog.ShowDialog(_mainForm) != DialogResult.OK) return;
                _selectedImageBytes = VehicleImageHelper.ReadImageFile(dialog.FileName);
                SetPreview(_selectedImageBytes);
                ShowStatus("Image selected. Click Save Vehicle to store it in the database.", false);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            // NEW CODE
            // A company cannot list or update rentable vehicles until renters have payment
            // destinations for GCash and bank transfer. This prevents incomplete listings.
            if (Session.CurrentUser.AccountType == "company" && !Session.CurrentUser.HasCompanyPaymentDetails)
            {
                ShowStatus("Complete company payment details in your profile before listing vehicles.", true);
                return;
            }
            try
            {
                var vehicle = _selectedVehicle ?? new Vehicle { OwnerId = Session.CurrentUser.Id };
                vehicle.Name = txtName.Text.Trim();
                vehicle.Type = cmbType.Text.Trim();
                vehicle.FuelType = txtFuel.Text.Trim();
                vehicle.Transmission = cmbTransmission.Text.Trim();
                vehicle.Seats = (int)nudSeats.Value;
                vehicle.PricePerDay = nudPrice.Value;
                vehicle.Status = cmbStatus.Text.Trim();
                vehicle.Tags = txtTags.Text.Trim();
                // NEW CODE
                vehicle.CurrentLocation = txtLocation.Text.Trim();
                vehicle.Description = txtDescription.Text.Trim();
                vehicle.ImageData = _selectedImageBytes;
                bool ok = _selectedVehicle == null ? _vehicleService.Add(vehicle) : _vehicleService.Update(vehicle);
                if (!ok) throw new Exception("No database rows were changed.");
                LoadVehicles();
                ClearForm();
                ShowStatus("Vehicle saved successfully.", false);
            }
            catch (Exception ex) { ShowStatus(ex.Message, true); }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedVehicle == null) { ShowStatus("Select a vehicle first.", true); return; }
            var result = MessageBox.Show($"Delete {_selectedVehicle.Name}?", "Delete Vehicle", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;
            try
            {
                _vehicleService.Delete(_selectedVehicle.Id);
                LoadVehicles();
                ClearForm();
                ShowStatus("Vehicle deleted.", false);
            }
            catch (Exception ex) { ShowStatus(ex.Message, true); }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text)) return ShowValidation("Vehicle name is required.");
            if (string.IsNullOrWhiteSpace(cmbType.Text)) return ShowValidation("Vehicle type is required.");
            if (string.IsNullOrWhiteSpace(txtFuel.Text)) return ShowValidation("Fuel type is required.");
            if (string.IsNullOrWhiteSpace(cmbTransmission.Text)) return ShowValidation("Transmission is required.");
            // NEW CODE
            if (string.IsNullOrWhiteSpace(txtLocation.Text)) return ShowValidation("Vehicle location is required.");
            return true;
        }

        private bool ShowValidation(string message) { ShowStatus(message, true); return false; }
        private void ShowStatus(string message, bool error) { lblStatus.ForeColor = error ? AppTheme.DangerColor : AppTheme.Accent; lblStatus.Text = message; }

        private void SetPreview(byte[] imageBytes)
        {
            if (picVehicle.Image != null) { picVehicle.Image.Dispose(); picVehicle.Image = null; }
            picVehicle.Image = VehicleImageHelper.ImageFromBytes(imageBytes);
        }

        private static void StyleGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = AppTheme.BgInput;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = AppTheme.TextPrimary;
            grid.ColumnHeadersDefaultCellStyle.Font = AppTheme.FontButton;
            grid.DefaultCellStyle.BackColor = AppTheme.BgCard;
            grid.DefaultCellStyle.ForeColor = AppTheme.TextPrimary;
            grid.DefaultCellStyle.SelectionBackColor = AppTheme.AccentHover;
            grid.DefaultCellStyle.SelectionForeColor = AppTheme.TextPrimary;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 34, 34);
        }

        private static Label MakeLabel(string text, int x, int y, Font font, Color color) => new Label { Text = text, Location = new Point(x, y), Font = font, ForeColor = color, AutoSize = true, BackColor = Color.Transparent };
        private static TextBox MakeTextBox(int x, int y, int width) => new TextBox { Location = new Point(x, y), Size = new Size(width, 29), BackColor = AppTheme.BgInput, ForeColor = AppTheme.TextPrimary, BorderStyle = BorderStyle.FixedSingle, Font = AppTheme.FontBody };
        private static NumericUpDown MakeNumber(int x, int y, int width, decimal min, decimal max, decimal value) => new NumericUpDown { Location = new Point(x, y), Size = new Size(width, 29), Minimum = min, Maximum = max, Value = value, BackColor = AppTheme.BgInput, ForeColor = AppTheme.TextPrimary, BorderStyle = BorderStyle.FixedSingle, Font = AppTheme.FontBody };

        private static ComboBox MakeComboBox(int x, int y, int width, string[] items)
        {
            var combo = new ComboBox { Location = new Point(x, y), Size = new Size(width, 29), BackColor = AppTheme.BgInput, ForeColor = AppTheme.TextPrimary, FlatStyle = FlatStyle.Flat, DropDownStyle = ComboBoxStyle.DropDown, Font = AppTheme.FontBody };
            combo.Items.AddRange(items);
            if (combo.Items.Count > 0) combo.SelectedIndex = 0;
            return combo;
        }

        private static Button MakeButton(string text, int x, int y, int width, Color backColor, Color foreColor)
        {
            var button = new Button { Text = text, Location = new Point(x, y), Size = new Size(width, 38), BackColor = backColor, ForeColor = foreColor, FlatStyle = FlatStyle.Flat, Font = AppTheme.FontButton, Cursor = Cursors.Hand, UseVisualStyleBackColor = false };
            button.FlatAppearance.BorderSize = backColor == AppTheme.Accent ? 0 : 1;
            return button;
        }

        private static void AddField(Control parent, string label, Control input, int labelX, int labelY)
        {
            parent.Controls.Add(MakeLabel(label, labelX, labelY, AppTheme.FontBody, AppTheme.TextPrimary));
            parent.Controls.Add(input);
        }

        private void VehicleManagePanel_Load(object sender, EventArgs e)
        {

        }

        private void lblType_Click(object sender, EventArgs e)
        {

        }
    }
}

