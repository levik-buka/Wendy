using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wendy
{
    public partial class ConfigForm : Form
    {
        private int selectedPeriod;

        public ConfigForm()
        {
            selectedPeriod = 0;
            InitializeComponent();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            usersView.Columns[0].DataPropertyName = "Name";
            usersView.Columns[1].DataPropertyName = "StartConsumption";
            this.usersView.DataSource = ((MainForm)Owner).dataSet;
            this.usersView.DataMember = "UserNames";

            startConsuption.Text = ((MainForm)Owner).config.StartConsumptionDisplay();

            selectedPeriod = ((MainForm)Owner).config.GetIndex(DateTime.Now);
            ShowFees();
        }

        private void ShowFees()
        {
            periodBegin.Text = ((MainForm)Owner).config.PeriodBeginsDisplay (selectedPeriod);
            periodEnd.Text = ((MainForm)Owner).config.PeriodEndsDisplay(selectedPeriod);
            waterFee.Text = ((MainForm)Owner).config.WaterFeeDisplay(selectedPeriod);
            wasteFee.Text = ((MainForm)Owner).config.WasteFeeDisplay(selectedPeriod);
            Vat.Text = ((MainForm)Owner).config.VATDisplay(selectedPeriod);
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            ((MainForm)Owner).config.SetStartConsumption(startConsuption.Text);
            SaveFees();
            this.Close();
        }

        private void SaveFees()
        {
            if (selectedPeriod < 0)
            {
                selectedPeriod = ((MainForm)Owner).config.AddIndex();
            }

            ((MainForm)Owner).config.SetPeriod(selectedPeriod, periodBegin.Text, periodEnd.Text);
            ((MainForm)Owner).config.SetWaterFee(selectedPeriod, waterFee.Text);
            ((MainForm)Owner).config.SetWasteFee(selectedPeriod, wasteFee.Text);
            ((MainForm)Owner).config.SetVAT(selectedPeriod, Vat.Text);
        }

        private void nextPeriod_Click(object sender, EventArgs e)
        {
            SaveFees ();
            int nextPeriod = ((MainForm)Owner).config.GetNextIndex(((MainForm)Owner).config.Period(selectedPeriod).End);
            selectedPeriod = NewPeriodDialog(nextPeriod);
            ShowFees();
        }

        private void prevPeriod_Click(object sender, EventArgs e)
        {
            SaveFees();
            int nextPeriod = ((MainForm)Owner).config.GetPrevIndex(((MainForm)Owner).config.Period(selectedPeriod).Begin);
            selectedPeriod = NewPeriodDialog(nextPeriod);
            ShowFees();
        }

        private int NewPeriodDialog(int nextPeriod)
        {
            if (nextPeriod < 0)
            {
                if (MessageBox.Show("Luodaanko uusi hinnastojakso?", "Uusi hinnasto", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    return nextPeriod;
                }
            }
            else
            {
                return nextPeriod;
            }

            return selectedPeriod;
        }
    }
}
