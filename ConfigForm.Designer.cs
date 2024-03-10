namespace Wendy
{
    partial class ConfigForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.usersView = new System.Windows.Forms.DataGridView();
            this.Nimi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startLukema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.okbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.startConsuption = new System.Windows.Forms.TextBox();
            this.waterFee = new System.Windows.Forms.TextBox();
            this.wasteFee = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Vat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.periodBegin = new System.Windows.Forms.MaskedTextBox();
            this.periodEnd = new System.Windows.Forms.MaskedTextBox();
            this.prevPeriod = new System.Windows.Forms.Button();
            this.nextPeriod = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.usersView);
            this.groupBox1.Location = new System.Drawing.Point(12, 180);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 163);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kuluttajat";
            // 
            // usersView
            // 
            this.usersView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nimi,
            this.startLukema});
            this.usersView.Location = new System.Drawing.Point(6, 19);
            this.usersView.Name = "usersView";
            this.usersView.Size = new System.Drawing.Size(314, 138);
            this.usersView.TabIndex = 0;
            // 
            // Nimi
            // 
            this.Nimi.HeaderText = "Nimi";
            this.Nimi.Name = "Nimi";
            this.Nimi.Width = 120;
            // 
            // startLukema
            // 
            this.startLukema.HeaderText = "Mittarin alkulukema (m3)";
            this.startLukema.Name = "startLukema";
            this.startLukema.Width = 150;
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(97, 349);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(75, 23);
            this.okbutton.TabIndex = 1;
            this.okbutton.Text = "Ok";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelbutton.Location = new System.Drawing.Point(178, 349);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelbutton.TabIndex = 2;
            this.cancelbutton.Text = "Peruuta";
            this.cancelbutton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 156);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Päämittarin alkulukema";
            // 
            // startConsuption
            // 
            this.startConsuption.Location = new System.Drawing.Point(148, 153);
            this.startConsuption.Name = "startConsuption";
            this.startConsuption.Size = new System.Drawing.Size(120, 20);
            this.startConsuption.TabIndex = 4;
            // 
            // waterFee
            // 
            this.waterFee.Location = new System.Drawing.Point(148, 61);
            this.waterFee.Name = "waterFee";
            this.waterFee.Size = new System.Drawing.Size(120, 20);
            this.waterFee.TabIndex = 5;
            // 
            // wasteFee
            // 
            this.wasteFee.Location = new System.Drawing.Point(148, 88);
            this.wasteFee.Name = "wasteFee";
            this.wasteFee.Size = new System.Drawing.Size(120, 20);
            this.wasteFee.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Vesimaksu (eur/m3)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Jätevesimaksu (eur/m3)";
            // 
            // Vat
            // 
            this.Vat.Location = new System.Drawing.Point(148, 114);
            this.Vat.Name = "Vat";
            this.Vat.Size = new System.Drawing.Size(61, 20);
            this.Vat.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Alv %";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 104);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hinnasto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Aikajakso";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(170, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "-";
            // 
            // periodBegin
            // 
            this.periodBegin.Location = new System.Drawing.Point(99, 10);
            this.periodBegin.Mask = "00/00/0000";
            this.periodBegin.Name = "periodBegin";
            this.periodBegin.Size = new System.Drawing.Size(65, 20);
            this.periodBegin.TabIndex = 17;
            this.periodBegin.ValidatingType = typeof(System.DateTime);
            // 
            // periodEnd
            // 
            this.periodEnd.Location = new System.Drawing.Point(186, 11);
            this.periodEnd.Mask = "00/00/0000";
            this.periodEnd.Name = "periodEnd";
            this.periodEnd.Size = new System.Drawing.Size(65, 20);
            this.periodEnd.TabIndex = 18;
            this.periodEnd.ValidatingType = typeof(System.DateTime);
            // 
            // prevPeriod
            // 
            this.prevPeriod.Location = new System.Drawing.Point(85, 8);
            this.prevPeriod.Name = "prevPeriod";
            this.prevPeriod.Size = new System.Drawing.Size(17, 23);
            this.prevPeriod.TabIndex = 19;
            this.prevPeriod.Text = "<";
            this.prevPeriod.UseVisualStyleBackColor = true;
            this.prevPeriod.Click += new System.EventHandler(this.prevPeriod_Click);
            // 
            // nextPeriod
            // 
            this.nextPeriod.Location = new System.Drawing.Point(247, 9);
            this.nextPeriod.Name = "nextPeriod";
            this.nextPeriod.Size = new System.Drawing.Size(19, 23);
            this.nextPeriod.TabIndex = 20;
            this.nextPeriod.Text = ">";
            this.nextPeriod.UseVisualStyleBackColor = true;
            this.nextPeriod.Click += new System.EventHandler(this.nextPeriod_Click);
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.okbutton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelbutton;
            this.ClientSize = new System.Drawing.Size(351, 382);
            this.Controls.Add(this.nextPeriod);
            this.Controls.Add(this.prevPeriod);
            this.Controls.Add(this.periodEnd);
            this.Controls.Add(this.periodBegin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Vat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wasteFee);
            this.Controls.Add(this.waterFee);
            this.Controls.Add(this.startConsuption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.okbutton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigForm";
            this.Text = "Asetukset";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView usersView;
        private System.Windows.Forms.Button okbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nimi;
        private System.Windows.Forms.DataGridViewTextBoxColumn startLukema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox startConsuption;
        private System.Windows.Forms.TextBox waterFee;
        private System.Windows.Forms.TextBox wasteFee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Vat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox periodBegin;
        private System.Windows.Forms.MaskedTextBox periodEnd;
        private System.Windows.Forms.Button prevPeriod;
        private System.Windows.Forms.Button nextPeriod;
    }
}