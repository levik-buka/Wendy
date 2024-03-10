namespace Wendy
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.InvoiceView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aikajakso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kulutus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Perusmaksu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vesimaksu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jätevesi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tasaus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Kokmaksu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estimation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VatTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewTasaus = new System.Windows.Forms.Button();
            this.NewArvio = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.SelectedSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.PrintBtn = new System.Windows.Forms.Button();
            this.configButton = new System.Windows.Forms.Button();
            this.dataSet = new System.Data.DataSet();
            this.InvoicesTable = new System.Data.DataTable();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.UsersTable = new System.Data.DataTable();
            this.InvoiceIdCol = new System.Data.DataColumn();
            this.UserCol = new System.Data.DataColumn();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.UserNames = new System.Data.DataTable();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.ConfigFee = new System.Data.DataTable();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn22 = new System.Data.DataColumn();
            this.Config = new System.Data.DataTable();
            this.dataColumn18 = new System.Data.DataColumn();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceView)).BeginInit();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Config)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.InvoiceView, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.NewTasaus, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NewArvio, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.PrintBtn, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.configButton, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(981, 222);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // InvoiceView
            // 
            this.InvoiceView.AllowUserToAddRows = false;
            this.InvoiceView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.InvoiceView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.InvoiceView.ColumnHeadersHeight = 45;
            this.InvoiceView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Aikajakso,
            this.Nimi,
            this.Kulutus,
            this.Perusmaksu,
            this.Vesimaksu,
            this.Jätevesi,
            this.Tasaus,
            this.Kokmaksu,
            this.Estimation,
            this.VatTotal});
            this.InvoiceView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceView.Location = new System.Drawing.Point(103, 3);
            this.InvoiceView.Name = "InvoiceView";
            this.InvoiceView.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.InvoiceView, 4);
            this.InvoiceView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InvoiceView.Size = new System.Drawing.Size(875, 194);
            this.InvoiceView.TabIndex = 0;
            this.InvoiceView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InvoiceView_CellMouseDoubleClick);
            this.InvoiceView.SelectionChanged += new System.EventHandler(this.InvoiceView_SelectionChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // Aikajakso
            // 
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle20.Format = "d";
            dataGridViewCellStyle20.NullValue = null;
            this.Aikajakso.DefaultCellStyle = dataGridViewCellStyle20;
            this.Aikajakso.HeaderText = "Aikajakso";
            this.Aikajakso.Name = "Aikajakso";
            this.Aikajakso.ReadOnly = true;
            this.Aikajakso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Aikajakso.Width = 80;
            // 
            // Nimi
            // 
            dataGridViewCellStyle21.NullValue = null;
            this.Nimi.DefaultCellStyle = dataGridViewCellStyle21;
            this.Nimi.HeaderText = "Nimi";
            this.Nimi.Name = "Nimi";
            this.Nimi.ReadOnly = true;
            this.Nimi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Kulutus
            // 
            dataGridViewCellStyle22.NullValue = "0 m3";
            this.Kulutus.DefaultCellStyle = dataGridViewCellStyle22;
            this.Kulutus.HeaderText = "Kulutus m3";
            this.Kulutus.Name = "Kulutus";
            this.Kulutus.ReadOnly = true;
            this.Kulutus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Kulutus.Width = 82;
            // 
            // Perusmaksu
            // 
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "0.00";
            dataGridViewCellStyle23.NullValue = "0";
            this.Perusmaksu.DefaultCellStyle = dataGridViewCellStyle23;
            this.Perusmaksu.HeaderText = "Perusmaksu";
            this.Perusmaksu.Name = "Perusmaksu";
            this.Perusmaksu.ReadOnly = true;
            this.Perusmaksu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Vesimaksu
            // 
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Format = "0.00";
            dataGridViewCellStyle24.NullValue = "0";
            this.Vesimaksu.DefaultCellStyle = dataGridViewCellStyle24;
            this.Vesimaksu.HeaderText = "Vesimaksu";
            this.Vesimaksu.Name = "Vesimaksu";
            this.Vesimaksu.ReadOnly = true;
            this.Vesimaksu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Jätevesi
            // 
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.Format = "0.00";
            dataGridViewCellStyle25.NullValue = "0";
            this.Jätevesi.DefaultCellStyle = dataGridViewCellStyle25;
            this.Jätevesi.HeaderText = "Jätevesi";
            this.Jätevesi.Name = "Jätevesi";
            this.Jätevesi.ReadOnly = true;
            this.Jätevesi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Tasaus
            // 
            this.Tasaus.HeaderText = "Tasattu";
            this.Tasaus.Name = "Tasaus";
            this.Tasaus.ReadOnly = true;
            this.Tasaus.Width = 50;
            // 
            // Kokmaksu
            // 
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle26.Format = "0.00";
            dataGridViewCellStyle26.NullValue = "0";
            this.Kokmaksu.DefaultCellStyle = dataGridViewCellStyle26;
            this.Kokmaksu.HeaderText = "Kok. maksu";
            this.Kokmaksu.Name = "Kokmaksu";
            this.Kokmaksu.ReadOnly = true;
            this.Kokmaksu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Estimation
            // 
            this.Estimation.HeaderText = "Estimation";
            this.Estimation.Name = "Estimation";
            this.Estimation.ReadOnly = true;
            this.Estimation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Estimation.Visible = false;
            // 
            // VatTotal
            // 
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle27.Format = "0.00";
            dataGridViewCellStyle27.NullValue = "0";
            this.VatTotal.DefaultCellStyle = dataGridViewCellStyle27;
            this.VatTotal.HeaderText = "Maksettava (alv)";
            this.VatTotal.Name = "VatTotal";
            this.VatTotal.ReadOnly = true;
            this.VatTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NewTasaus
            // 
            this.NewTasaus.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NewTasaus.Location = new System.Drawing.Point(10, 32);
            this.NewTasaus.Name = "NewTasaus";
            this.NewTasaus.Size = new System.Drawing.Size(80, 23);
            this.NewTasaus.TabIndex = 2;
            this.NewTasaus.Text = "Tasauslasku";
            this.NewTasaus.UseVisualStyleBackColor = true;
            this.NewTasaus.Click += new System.EventHandler(this.NewTasaus_Click);
            // 
            // NewArvio
            // 
            this.NewArvio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.NewArvio.Location = new System.Drawing.Point(10, 3);
            this.NewArvio.Name = "NewArvio";
            this.NewArvio.Size = new System.Drawing.Size(80, 23);
            this.NewArvio.TabIndex = 1;
            this.NewArvio.Text = "Arviolasku";
            this.NewArvio.UseVisualStyleBackColor = true;
            this.NewArvio.Click += new System.EventHandler(this.NewArvio_Click);
            // 
            // statusStrip
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip, 2);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectedSum});
            this.statusStrip.Location = new System.Drawing.Point(0, 200);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(981, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // SelectedSum
            // 
            this.SelectedSum.Name = "SelectedSum";
            this.SelectedSum.Size = new System.Drawing.Size(33, 17);
            this.SelectedSum.Text = "0.00";
            // 
            // PrintBtn
            // 
            this.PrintBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PrintBtn.Location = new System.Drawing.Point(10, 144);
            this.PrintBtn.Name = "PrintBtn";
            this.PrintBtn.Size = new System.Drawing.Size(80, 23);
            this.PrintBtn.TabIndex = 4;
            this.PrintBtn.Text = "Tulosta";
            this.PrintBtn.UseVisualStyleBackColor = true;
            this.PrintBtn.Click += new System.EventHandler(this.PrintBtn_Click);
            // 
            // configButton
            // 
            this.configButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.configButton.Location = new System.Drawing.Point(10, 174);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(80, 23);
            this.configButton.TabIndex = 1;
            this.configButton.Text = "Asetukset";
            this.configButton.UseVisualStyleBackColor = true;
            this.configButton.Click += new System.EventHandler(this.config_Click);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "ElectraData";
            this.dataSet.Locale = new System.Globalization.CultureInfo("fi");
            this.dataSet.Relations.AddRange(new System.Data.DataRelation[] {
            new System.Data.DataRelation("IdRelation", "Invoices", "Users", new string[] {
                        "Id"}, new string[] {
                        "Id"}, false)});
            this.dataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.InvoicesTable,
            this.UsersTable,
            this.UserNames,
            this.ConfigFee,
            this.Config});
            // 
            // InvoicesTable
            // 
            this.InvoicesTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn12,
            this.dataColumn19});
            this.InvoicesTable.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id"}, true)});
            this.InvoicesTable.PrimaryKey = new System.Data.DataColumn[] {
        this.dataColumn2};
            this.InvoicesTable.TableName = "Invoices";
            // 
            // dataColumn2
            // 
            this.dataColumn2.AllowDBNull = false;
            this.dataColumn2.AutoIncrement = true;
            this.dataColumn2.ColumnMapping = System.Data.MappingType.Attribute;
            this.dataColumn2.ColumnName = "Id";
            this.dataColumn2.DataType = typeof(int);
            // 
            // dataColumn3
            // 
            this.dataColumn3.AllowDBNull = false;
            this.dataColumn3.ColumnName = "StartDate";
            this.dataColumn3.DataType = typeof(System.DateTime);
            // 
            // dataColumn4
            // 
            this.dataColumn4.AllowDBNull = false;
            this.dataColumn4.ColumnName = "EndDate";
            this.dataColumn4.DataType = typeof(System.DateTime);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Consumption";
            this.dataColumn5.DataType = typeof(int);
            this.dataColumn5.DefaultValue = 0;
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "WaterFee";
            this.dataColumn6.DataType = typeof(double);
            this.dataColumn6.DefaultValue = 0;
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "WasteFee";
            this.dataColumn7.DataType = typeof(double);
            this.dataColumn7.DefaultValue = 0;
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "BasicFee";
            this.dataColumn8.DataType = typeof(double);
            this.dataColumn8.DefaultValue = 0;
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "Balanced";
            this.dataColumn12.DataType = typeof(bool);
            this.dataColumn12.DefaultValue = false;
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "Estimation";
            this.dataColumn19.DataType = typeof(int);
            this.dataColumn19.DefaultValue = 0;
            // 
            // UsersTable
            // 
            this.UsersTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.InvoiceIdCol,
            this.UserCol,
            this.dataColumn1,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn13});
            this.UsersTable.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id",
                        "User"}, true),
            new System.Data.ForeignKeyConstraint("IdRelation", "Invoices", new string[] {
                        "Id"}, new string[] {
                        "Id"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade),
            new System.Data.ForeignKeyConstraint("UserRelation", "UserNames", new string[] {
                        "Name"}, new string[] {
                        "User"}, System.Data.AcceptRejectRule.None, System.Data.Rule.Cascade, System.Data.Rule.Cascade)});
            this.UsersTable.PrimaryKey = new System.Data.DataColumn[] {
        this.InvoiceIdCol,
        this.UserCol};
            this.UsersTable.TableName = "Users";
            // 
            // InvoiceIdCol
            // 
            this.InvoiceIdCol.AllowDBNull = false;
            this.InvoiceIdCol.ColumnMapping = System.Data.MappingType.Attribute;
            this.InvoiceIdCol.ColumnName = "Id";
            this.InvoiceIdCol.DataType = typeof(int);
            // 
            // UserCol
            // 
            this.UserCol.AllowDBNull = false;
            this.UserCol.ColumnName = "User";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Consumption";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "WaterFee";
            this.dataColumn9.DataType = typeof(double);
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "WasteFee";
            this.dataColumn10.DataType = typeof(double);
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "BasicFee";
            this.dataColumn11.DataType = typeof(double);
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "Balanced";
            this.dataColumn13.DataType = typeof(bool);
            // 
            // UserNames
            // 
            this.UserNames.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn14,
            this.dataColumn15});
            this.UserNames.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint2", new string[] {
                        "Name"}, false)});
            this.UserNames.TableName = "UserNames";
            // 
            // dataColumn14
            // 
            this.dataColumn14.AllowDBNull = false;
            this.dataColumn14.Caption = "Name";
            this.dataColumn14.ColumnMapping = System.Data.MappingType.Attribute;
            this.dataColumn14.ColumnName = "Name";
            this.dataColumn14.DefaultValue = "";
            // 
            // dataColumn15
            // 
            this.dataColumn15.Caption = "StartConsumption";
            this.dataColumn15.ColumnName = "StartConsumption";
            this.dataColumn15.DataType = typeof(int);
            this.dataColumn15.DefaultValue = 0;
            // 
            // ConfigFee
            // 
            this.ConfigFee.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn20,
            this.dataColumn21,
            this.dataColumn22});
            this.ConfigFee.TableName = "ConfigFee";
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "WaterFee";
            this.dataColumn16.DataType = typeof(double);
            this.dataColumn16.DefaultValue = 0;
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "WasteFee";
            this.dataColumn17.DataType = typeof(double);
            this.dataColumn17.DefaultValue = 0;
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "VAT";
            this.dataColumn20.DataType = typeof(double);
            this.dataColumn20.DefaultValue = 0;
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnMapping = System.Data.MappingType.Attribute;
            this.dataColumn21.ColumnName = "Begin";
            this.dataColumn21.DataType = typeof(System.DateTime);
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnMapping = System.Data.MappingType.Attribute;
            this.dataColumn22.ColumnName = "End";
            this.dataColumn22.DataType = typeof(System.DateTime);
            // 
            // Config
            // 
            this.Config.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn18});
            this.Config.TableName = "Config";
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "StartConsumption";
            this.dataColumn18.DataType = typeof(int);
            this.dataColumn18.DefaultValue = 0;
            // 
            // printDoc
            // 
            this.printDoc.DocumentName = "Vesilaskun erittely";
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 222);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Wendy";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.m_mainForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceView)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoicesTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserNames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ConfigFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Config)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button NewArvio;
        private System.Windows.Forms.DataGridView InvoiceView;
        private System.Windows.Forms.Button NewTasaus;
        public System.Data.DataSet dataSet;
        public System.Data.DataTable InvoicesTable;
        public System.Data.DataTable UsersTable;
        private System.Data.DataColumn InvoiceIdCol;
        private System.Data.DataColumn UserCol;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
        private System.Data.DataColumn dataColumn4;
        private System.Data.DataColumn dataColumn5;
        private System.Data.DataColumn dataColumn6;
        private System.Data.DataColumn dataColumn7;
        private System.Data.DataColumn dataColumn8;
        private System.Data.DataColumn dataColumn9;
        private System.Data.DataColumn dataColumn10;
        private System.Data.DataColumn dataColumn11;
        private System.Data.DataColumn dataColumn12;
        private System.Data.DataColumn dataColumn13;
        public System.Data.DataTable UserNames;
        private System.Data.DataColumn dataColumn14;
        private System.Data.DataColumn dataColumn15;
        public System.Data.DataTable ConfigFee;
        private System.Data.DataColumn dataColumn16;
        private System.Data.DataColumn dataColumn17;
        private System.Windows.Forms.Button configButton;
        private System.Data.DataColumn dataColumn19;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel SelectedSum;
        private System.Data.DataColumn dataColumn20;
        public System.Data.DataTable Config;
        private System.Data.DataColumn dataColumn21;
        private System.Data.DataColumn dataColumn22;
        private System.Data.DataColumn dataColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aikajakso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nimi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kulutus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Perusmaksu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vesimaksu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jätevesi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Tasaus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kokmaksu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estimation;
        private System.Windows.Forms.DataGridViewTextBoxColumn VatTotal;
        private System.Windows.Forms.Button PrintBtn;
        public System.Drawing.Printing.PrintDocument printDoc;

    }
}

