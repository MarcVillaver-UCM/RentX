using System.Drawing;
using System.Windows.Forms;

namespace RentXpress.Forms
{
    partial class VehicleManagePanel
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblStatus;
        private DataGridView dgvVehicles;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colType;
        private DataGridViewTextBoxColumn colPrice;
        private DataGridViewTextBoxColumn colStatus;
        private Panel pnlForm;
        private Label lblDetailsTitle;
        private Label lblName;
        private Label lblType;
        private Label lblFuel;
        private Label lblTransmission;
        private Label lblSeats;
        private Label lblPrice;
        private Label lblVehicleStatus;
        private Label lblTags;
        // NEW CODE
        private Label lblLocation;
        private Label lblDescription;
        private TextBox txtName;
        private ComboBox cmbType;
        private TextBox txtFuel;
        private ComboBox cmbTransmission;
        private NumericUpDown nudSeats;
        private NumericUpDown nudPrice;
        private ComboBox cmbStatus;
        private TextBox txtTags;
        // NEW CODE
        private TextBox txtLocation;
        private TextBox txtDescription;
        private PictureBox picVehicle;
        // NEW CODE
        private Button btnAdd;
        private Button btnUpload;
        private Button btnSave;
        private Button btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.dgvVehicles = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblDetailsTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblFuel = new System.Windows.Forms.Label();
            this.lblTransmission = new System.Windows.Forms.Label();
            this.lblSeats = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblVehicleStatus = new System.Windows.Forms.Label();
            this.lblTags = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtFuel = new System.Windows.Forms.TextBox();
            this.cmbTransmission = new System.Windows.Forms.ComboBox();
            this.nudSeats = new System.Windows.Forms.NumericUpDown();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.picVehicle = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).BeginInit();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(40, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(286, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Manage Vehicles";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblSubtitle.Location = new System.Drawing.Point(40, 72);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(372, 21);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Add, edit, and remove the vehicles you offer for rent.";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblStatus.Location = new System.Drawing.Point(40, 102);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(134, 21);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Loading vehicles...";
            // 
            // dgvVehicles
            // 
            this.dgvVehicles.AllowUserToAddRows = false;
            this.dgvVehicles.AllowUserToDeleteRows = false;
            this.dgvVehicles.AllowUserToResizeRows = false;
            this.dgvVehicles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvVehicles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVehicles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.dgvVehicles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVehicles.ColumnHeadersHeight = 38;
            this.dgvVehicles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colType,
            this.colPrice,
            this.colStatus});
            this.dgvVehicles.Location = new System.Drawing.Point(40, 135);
            this.dgvVehicles.MultiSelect = false;
            this.dgvVehicles.Name = "dgvVehicles";
            this.dgvVehicles.ReadOnly = true;
            this.dgvVehicles.RowHeadersVisible = false;
            this.dgvVehicles.RowHeadersWidth = 51;
            this.dgvVehicles.RowTemplate.Height = 36;
            this.dgvVehicles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehicles.Size = new System.Drawing.Size(605, 455);
            this.dgvVehicles.TabIndex = 3;
            this.dgvVehicles.SelectionChanged += new System.EventHandler(this.dgvVehicles_SelectionChanged);
            // 
            // colId
            // 
            this.colId.HeaderText = "Id";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "Id";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "Name";
            this.colName.ReadOnly = true;
            // 
            // colType
            // 
            this.colType.HeaderText = "Type";
            this.colType.MinimumWidth = 6;
            this.colType.Name = "Type";
            this.colType.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Price";
            this.colPrice.MinimumWidth = 6;
            this.colPrice.Name = "Price";
            this.colPrice.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "Status";
            this.colStatus.ReadOnly = true;
            // 
            // pnlForm
            // 
            this.pnlForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.pnlForm.Controls.Add(this.lblDetailsTitle);
            this.pnlForm.Controls.Add(this.lblName);
            this.pnlForm.Controls.Add(this.lblType);
            this.pnlForm.Controls.Add(this.lblFuel);
            this.pnlForm.Controls.Add(this.lblTransmission);
            this.pnlForm.Controls.Add(this.lblSeats);
            this.pnlForm.Controls.Add(this.lblPrice);
            this.pnlForm.Controls.Add(this.lblVehicleStatus);
            this.pnlForm.Controls.Add(this.lblTags);
            this.pnlForm.Controls.Add(this.lblLocation);
            this.pnlForm.Controls.Add(this.lblDescription);
            this.pnlForm.Controls.Add(this.txtName);
            this.pnlForm.Controls.Add(this.cmbType);
            this.pnlForm.Controls.Add(this.txtFuel);
            this.pnlForm.Controls.Add(this.cmbTransmission);
            this.pnlForm.Controls.Add(this.nudSeats);
            this.pnlForm.Controls.Add(this.nudPrice);
            this.pnlForm.Controls.Add(this.cmbStatus);
            this.pnlForm.Controls.Add(this.txtTags);
            this.pnlForm.Controls.Add(this.txtLocation);
            this.pnlForm.Controls.Add(this.txtDescription);
            this.pnlForm.Controls.Add(this.picVehicle);
            this.pnlForm.Controls.Add(this.btnAdd);
            this.pnlForm.Controls.Add(this.btnUpload);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.btnDelete);
            this.pnlForm.Location = new System.Drawing.Point(670, 135);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(390, 455);
            this.pnlForm.TabIndex = 4;
            // 
            // lblDetailsTitle
            // 
            this.lblDetailsTitle.AutoSize = true;
            this.lblDetailsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDetailsTitle.ForeColor = System.Drawing.Color.White;
            this.lblDetailsTitle.Location = new System.Drawing.Point(20, 18);
            this.lblDetailsTitle.Name = "lblDetailsTitle";
            this.lblDetailsTitle.Size = new System.Drawing.Size(179, 32);
            this.lblDetailsTitle.TabIndex = 0;
            this.lblDetailsTitle.Text = "Vehicle Details";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(20, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 21);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblType.ForeColor = System.Drawing.Color.White;
            this.lblType.Location = new System.Drawing.Point(210, 50);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(42, 21);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Type";
            this.lblType.Click += new System.EventHandler(this.lblType_Click);
            // 
            // lblFuel
            // 
            this.lblFuel.AutoSize = true;
            this.lblFuel.BackColor = System.Drawing.Color.Transparent;
            this.lblFuel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFuel.ForeColor = System.Drawing.Color.White;
            this.lblFuel.Location = new System.Drawing.Point(20, 106);
            this.lblFuel.Name = "lblFuel";
            this.lblFuel.Size = new System.Drawing.Size(39, 21);
            this.lblFuel.TabIndex = 3;
            this.lblFuel.Text = "Fuel";
            // 
            // lblTransmission
            // 
            this.lblTransmission.AutoSize = true;
            this.lblTransmission.BackColor = System.Drawing.Color.Transparent;
            this.lblTransmission.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTransmission.ForeColor = System.Drawing.Color.White;
            this.lblTransmission.Location = new System.Drawing.Point(210, 106);
            this.lblTransmission.Name = "lblTransmission";
            this.lblTransmission.Size = new System.Drawing.Size(101, 21);
            this.lblTransmission.TabIndex = 4;
            this.lblTransmission.Text = "Transmission";
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.BackColor = System.Drawing.Color.Transparent;
            this.lblSeats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSeats.ForeColor = System.Drawing.Color.White;
            this.lblSeats.Location = new System.Drawing.Point(22, 164);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(47, 21);
            this.lblSeats.TabIndex = 5;
            this.lblSeats.Text = "Seats";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblPrice.ForeColor = System.Drawing.Color.White;
            this.lblPrice.Location = new System.Drawing.Point(210, 166);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(85, 21);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price / Day";
            // 
            // lblVehicleStatus
            // 
            this.lblVehicleStatus.AutoSize = true;
            this.lblVehicleStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblVehicleStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblVehicleStatus.ForeColor = System.Drawing.Color.White;
            this.lblVehicleStatus.Location = new System.Drawing.Point(20, 224);
            this.lblVehicleStatus.Name = "lblVehicleStatus";
            this.lblVehicleStatus.Size = new System.Drawing.Size(52, 21);
            this.lblVehicleStatus.TabIndex = 7;
            this.lblVehicleStatus.Text = "Status";
            // 
            // lblTags
            // 
            this.lblTags.AutoSize = true;
            this.lblTags.BackColor = System.Drawing.Color.Transparent;
            this.lblTags.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblTags.ForeColor = System.Drawing.Color.White;
            this.lblTags.Location = new System.Drawing.Point(210, 224);
            this.lblTags.Name = "lblTags";
            this.lblTags.Size = new System.Drawing.Size(40, 21);
            this.lblTags.TabIndex = 8;
            this.lblTags.Text = "Tags";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblLocation.ForeColor = System.Drawing.Color.White;
            this.lblLocation.Location = new System.Drawing.Point(16, 282);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(69, 21);
            this.lblLocation.TabIndex = 23;
            this.lblLocation.Text = "Location";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(16, 336);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(89, 21);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtName.ForeColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(20, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(163, 29);
            this.txtName.TabIndex = 10;
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbType.ForeColor = System.Drawing.Color.White;
            this.cmbType.Items.AddRange(new object[] {
            "Car",
            "SUV",
            "Van",
            "Motorcycle",
            "Truck"});
            this.cmbType.Location = new System.Drawing.Point(214, 74);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(167, 29);
            this.cmbType.TabIndex = 11;
            this.cmbType.Text = "Car";
            // 
            // txtFuel
            // 
            this.txtFuel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtFuel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFuel.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtFuel.ForeColor = System.Drawing.Color.White;
            this.txtFuel.Location = new System.Drawing.Point(20, 132);
            this.txtFuel.Name = "txtFuel";
            this.txtFuel.Size = new System.Drawing.Size(163, 29);
            this.txtFuel.TabIndex = 12;
            this.txtFuel.Text = "Gasoline";
            // 
            // cmbTransmission
            // 
            this.cmbTransmission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.cmbTransmission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTransmission.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTransmission.ForeColor = System.Drawing.Color.White;
            this.cmbTransmission.Items.AddRange(new object[] {
            "Automatic",
            "Manual"});
            this.cmbTransmission.Location = new System.Drawing.Point(214, 132);
            this.cmbTransmission.Name = "cmbTransmission";
            this.cmbTransmission.Size = new System.Drawing.Size(167, 29);
            this.cmbTransmission.TabIndex = 13;
            this.cmbTransmission.Text = "Automatic";
            // 
            // nudSeats
            // 
            this.nudSeats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.nudSeats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudSeats.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudSeats.ForeColor = System.Drawing.Color.White;
            this.nudSeats.Location = new System.Drawing.Point(20, 190);
            this.nudSeats.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.nudSeats.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSeats.Name = "nudSeats";
            this.nudSeats.Size = new System.Drawing.Size(163, 29);
            this.nudSeats.TabIndex = 14;
            this.nudSeats.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // nudPrice
            // 
            this.nudPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.nudPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudPrice.ForeColor = System.Drawing.Color.White;
            this.nudPrice.Location = new System.Drawing.Point(214, 190);
            this.nudPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(167, 29);
            this.nudPrice.TabIndex = 15;
            this.nudPrice.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // cmbStatus
            // 
            this.cmbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbStatus.ForeColor = System.Drawing.Color.White;
            this.cmbStatus.Items.AddRange(new object[] {
            "available",
            "unavailable",
            "maintenance"});
            this.cmbStatus.Location = new System.Drawing.Point(20, 248);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(163, 29);
            this.cmbStatus.TabIndex = 16;
            this.cmbStatus.Text = "available";
            // 
            // txtTags
            // 
            this.txtTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtTags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTags.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTags.ForeColor = System.Drawing.Color.White;
            this.txtTags.Location = new System.Drawing.Point(214, 248);
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(167, 29);
            this.txtTags.TabIndex = 17;
            // 
            // txtLocation
            // 
            this.txtLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocation.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtLocation.ForeColor = System.Drawing.Color.White;
            this.txtLocation.Location = new System.Drawing.Point(20, 306);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(361, 29);
            this.txtLocation.TabIndex = 24;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescription.ForeColor = System.Drawing.Color.White;
            this.txtDescription.Location = new System.Drawing.Point(20, 360);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(361, 45);
            this.txtDescription.TabIndex = 18;
            // 
            // picVehicle
            // 
            this.picVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.picVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picVehicle.Location = new System.Drawing.Point(20, 412);
            this.picVehicle.Name = "picVehicle";
            this.picVehicle.Size = new System.Drawing.Size(82, 50);
            this.picVehicle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picVehicle.TabIndex = 19;
            this.picVehicle.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(245, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(105, 30);
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add Vehicle";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.Location = new System.Drawing.Point(112, 416);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(87, 38);
            this.btnUpload.TabIndex = 20;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(201)))), ((int)(((byte)(151)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(205, 416);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 38);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save Vehicle";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(296, 416);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 38);
            this.btnDelete.TabIndex = 22;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // VehicleManagePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgvVehicles);
            this.Controls.Add(this.pnlForm);
            this.Name = "VehicleManagePanel";
            this.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.Size = new System.Drawing.Size(1100, 630);
            this.Load += new System.EventHandler(this.VehicleManagePanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehicles)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVehicle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
