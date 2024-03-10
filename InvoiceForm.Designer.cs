namespace Wendy
{
    partial class InvoiceForm
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
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.invoiceTypeTxt = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.arvioConsumption = new System.Windows.Forms.TextBox();
            this.arvioTxt = new System.Windows.Forms.Label();
            this.consumption = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lukema = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wasteFee = new System.Windows.Forms.TextBox();
            this.waterFee = new System.Windows.Forms.TextBox();
            this.basicFee = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.balanced = new System.Windows.Forms.CheckBox();
            this.userName = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sumFee = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(71, 12);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(140, 20);
            this.startDate.TabIndex = 0;
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(233, 12);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(140, 20);
            this.endDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Aikajakso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "-";
            // 
            // invoiceTypeTxt
            // 
            this.invoiceTypeTxt.AutoSize = true;
            this.invoiceTypeTxt.Location = new System.Drawing.Point(12, 38);
            this.invoiceTypeTxt.Name = "invoiceTypeTxt";
            this.invoiceTypeTxt.Size = new System.Drawing.Size(67, 13);
            this.invoiceTypeTxt.TabIndex = 4;
            this.invoiceTypeTxt.Text = "Tasauslasku";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.arvioConsumption);
            this.groupBox1.Controls.Add(this.arvioTxt);
            this.groupBox1.Controls.Add(this.consumption);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lukema);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 95);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lukemat";
            // 
            // arvioConsumption
            // 
            this.arvioConsumption.Location = new System.Drawing.Point(104, 68);
            this.arvioConsumption.Name = "arvioConsumption";
            this.arvioConsumption.Size = new System.Drawing.Size(89, 20);
            this.arvioConsumption.TabIndex = 5;
            this.arvioConsumption.TextChanged += new System.EventHandler(this.arvioConsumption_TextChanged);
            // 
            // arvioTxt
            // 
            this.arvioTxt.AutoSize = true;
            this.arvioTxt.Location = new System.Drawing.Point(7, 71);
            this.arvioTxt.Name = "arvioTxt";
            this.arvioTxt.Size = new System.Drawing.Size(88, 13);
            this.arvioTxt.TabIndex = 4;
            this.arvioTxt.Text = "Arviokulutus (m3)";
            // 
            // consumption
            // 
            this.consumption.Location = new System.Drawing.Point(104, 40);
            this.consumption.Name = "consumption";
            this.consumption.Size = new System.Drawing.Size(89, 20);
            this.consumption.TabIndex = 3;
            this.consumption.TextChanged += new System.EventHandler(this.consumption_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Kulutus (m3)";
            // 
            // lukema
            // 
            this.lukema.Location = new System.Drawing.Point(104, 13);
            this.lukema.Name = "lukema";
            this.lukema.Size = new System.Drawing.Size(89, 20);
            this.lukema.TabIndex = 1;
            this.lukema.TextChanged += new System.EventHandler(this.lukema_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mittarilukema (m3)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wasteFee);
            this.groupBox2.Controls.Add(this.waterFee);
            this.groupBox2.Controls.Add(this.basicFee);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(233, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 95);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Maksut";
            // 
            // wasteFee
            // 
            this.wasteFee.Location = new System.Drawing.Point(90, 65);
            this.wasteFee.Name = "wasteFee";
            this.wasteFee.Size = new System.Drawing.Size(90, 20);
            this.wasteFee.TabIndex = 5;
            this.wasteFee.TextChanged += new System.EventHandler(this.wasteFee_TextChanged);
            // 
            // waterFee
            // 
            this.waterFee.Location = new System.Drawing.Point(90, 39);
            this.waterFee.Name = "waterFee";
            this.waterFee.Size = new System.Drawing.Size(90, 20);
            this.waterFee.TabIndex = 4;
            this.waterFee.TextChanged += new System.EventHandler(this.waterFee_TextChanged);
            // 
            // basicFee
            // 
            this.basicFee.Location = new System.Drawing.Point(90, 13);
            this.basicFee.Name = "basicFee";
            this.basicFee.Size = new System.Drawing.Size(90, 20);
            this.basicFee.TabIndex = 3;
            this.basicFee.TextChanged += new System.EventHandler(this.basicFee_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Jätevesimaksu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Vesimaksu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Perusmaksu";
            // 
            // balanced
            // 
            this.balanced.AutoSize = true;
            this.balanced.Enabled = false;
            this.balanced.Location = new System.Drawing.Point(85, 38);
            this.balanced.Name = "balanced";
            this.balanced.Size = new System.Drawing.Size(62, 17);
            this.balanced.TabIndex = 7;
            this.balanced.Text = "Tasattu";
            this.balanced.UseVisualStyleBackColor = true;
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Location = new System.Drawing.Point(230, 39);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(55, 13);
            this.userName.TabIndex = 8;
            this.userName.Text = "Username";
            this.userName.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Yhteensä:";
            // 
            // sumFee
            // 
            this.sumFee.AutoSize = true;
            this.sumFee.Location = new System.Drawing.Point(82, 163);
            this.sumFee.Name = "sumFee";
            this.sumFee.Size = new System.Drawing.Size(46, 13);
            this.sumFee.TabIndex = 10;
            this.sumFee.Text = "0,00 eur";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(242, 162);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 11;
            this.okButton.Text = "&Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(338, 162);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 12;
            this.cancelButton.Text = "&Peruuta";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // InvoiceForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(434, 196);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.sumFee);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.balanced);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.invoiceTypeTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceForm";
            this.Text = "Vesilasku";
            this.Shown += new System.EventHandler(this.InvoiceForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label sumFee;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        protected System.Windows.Forms.Label arvioTxt;
        protected System.Windows.Forms.CheckBox balanced;
        protected System.Windows.Forms.Label userName;
        protected System.Windows.Forms.TextBox arvioConsumption;
        protected System.Windows.Forms.DateTimePicker startDate;
        protected System.Windows.Forms.DateTimePicker endDate;
        protected System.Windows.Forms.TextBox lukema;
        protected System.Windows.Forms.TextBox consumption;
        protected System.Windows.Forms.TextBox wasteFee;
        protected System.Windows.Forms.TextBox waterFee;
        protected System.Windows.Forms.TextBox basicFee;
        protected System.Windows.Forms.Label invoiceTypeTxt;
    }
}