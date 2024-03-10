using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Wendy
{
    public partial class InvoiceForm : Form
    {
        protected Int32 m_estimation = 0;
        protected Int32 m_totalConsumption = 0;

        private Int32 m_invoiceId = -1;
        public Int32 InvoiceId { get { return m_invoiceId; } set { m_invoiceId = value; } }
	

        public InvoiceForm()
        {
            InitializeComponent();
            InitializeLabels();
        }

        virtual protected void InitializeLabels()
        {
            // Default tasauslasku
            balanced.Checked = true;
            arvioTxt.Hide();
            arvioConsumption.Hide();
        }

        virtual protected DataRow[] ShowData()
        {
            DataRow[] invoiceRow = ((MainForm)Owner).InvoicesTable.Select("id = " + InvoiceId);
            if (invoiceRow.Length >= 1)
            {
                startDate.Value = Convert.ToDateTime(invoiceRow[0]["startdate"]);
                endDate.Value = Convert.ToDateTime(invoiceRow[0]["enddate"]);
                balanced.Checked = ((MainForm)Owner).IsRowBalanced(invoiceRow[0]);

                try
                {
                    m_totalConsumption = ((MainForm)Owner).GetConsumption(balanced.Checked, endDate.Value, Convert.ToInt32(invoiceRow[0]["consumption"]));
                }
                catch { }
                try
                {
                    m_estimation = Convert.ToInt32(invoiceRow[0]["estimation"]);
                }
                catch { }

                lukema.Text = invoiceRow[0]["consumption"].ToString();
                basicFee.Text = invoiceRow[0]["basicfee"].ToString();

                if (!DBNull.Value.Equals(invoiceRow[0]["waterfee"])
                    && Convert.ToInt32 (invoiceRow[0]["waterfee"]) != 0)
                {
                    waterFee.Text = invoiceRow[0]["waterfee"].ToString();
                }

                if (!DBNull.Value.Equals(invoiceRow[0]["wastefee"])
                    && Convert.ToInt32(invoiceRow[0]["wastefee"]) != 0)
                {
                    wasteFee.Text = invoiceRow[0]["wastefee"].ToString();
                }
            }

            return invoiceRow;
        }

        virtual public Int32 GetConsumption(DateTime before, Int32 lukemaNow)
        {
            return ((MainForm)Owner).GetConsumption(balanced.Checked, before, lukemaNow);
        }

        virtual public Fee GetNonBalancedFee(DateTime before)
        {
            return ((MainForm)Owner).GetNonBalancedFee(before);
        }

        protected void CalculateSum()
        {
            try
            {
                sumFee.Text =
                    String.Format("{0:0.00 eur}", Convert.ToDouble(basicFee.Text) + Convert.ToDouble(waterFee.Text) + Convert.ToDouble(wasteFee.Text));
            }
            catch { }
        }

        
        virtual protected void CalculateFees(double consumption)
        {
            int index = ((MainForm)Owner).config.GetIndex(endDate.Value);
            Fee fee = GetNonBalancedFee(endDate.Value);
            double leftConsumption = consumption - fee.Consumption;

            waterFee.Text =
                String.Format("{0:0.00}", (leftConsumption * ((MainForm)Owner).config.WaterFee(index)) + fee.WaterFee);
            wasteFee.Text =
                String.Format("{0:0.00}", (leftConsumption * ((MainForm)Owner).config.WasteFee(index)) + fee.WasteFee);
        }

        protected void CalculateConsumption()
        {
            try
            {
                consumption.Text = 
                    String.Format("{0:0}", GetConsumption (endDate.Value, Convert.ToInt32 (lukema.Text)));
            }
            catch { }
        }

        private void InvoiceForm_Shown(object sender, EventArgs e)
        {
            ShowData();
        }

        virtual protected void consumption_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateFees(Convert.ToDouble(consumption.Text));
            }
            catch
            {
                CalculateFees(0);
            }
        }

        virtual protected void arvioConsumption_TextChanged(object sender, EventArgs e)
        {
            // Empty
        }

        private void lukema_TextChanged(object sender, EventArgs e)
        {
            CalculateConsumption();
        }

        private void basicFee_TextChanged(object sender, EventArgs e)
        {
            CalculateSum();
        }

        private void waterFee_TextChanged(object sender, EventArgs e)
        {
            CalculateSum();
        }

        private void wasteFee_TextChanged(object sender, EventArgs e)
        {
            CalculateSum();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (InvoiceId >= 0)
            {
                SaveInvoice();
            }
            else
            {
                AddInvoice();
            }

            Close();
        }

        virtual protected DataRow[] SaveInvoice()
        {
            DataRow[] invoiceRow = ((MainForm)Owner).InvoicesTable.Select("id = " + InvoiceId);
            if (invoiceRow.Length >= 1)
            {
                invoiceRow[0].BeginEdit();
                invoiceRow[0]["startdate"] = startDate.Value;
                invoiceRow[0]["enddate"] = endDate.Value;
                invoiceRow[0]["consumption"] = lukema.Text;
                invoiceRow[0]["basicfee"] = Convert.ToDouble (basicFee.Text);
                invoiceRow[0]["waterfee"] = Convert.ToDouble (waterFee.Text);
                invoiceRow[0]["wastefee"] = Convert.ToDouble (wasteFee.Text);
                invoiceRow[0].EndEdit();
            }
            return invoiceRow;
        }

        virtual protected DataRow AddInvoice()
        {
            DataRow newRow = ((MainForm)Owner).InvoicesTable.NewRow();
            newRow["startdate"] = startDate.Value;
            newRow["enddate"] = endDate.Value;
            newRow["consumption"] = lukema.Text;
            newRow["basicfee"] = Convert.ToDouble(basicFee.Text);
            newRow["waterfee"] = Convert.ToDouble(waterFee.Text);
            newRow["wastefee"] = Convert.ToDouble(wasteFee.Text);
            newRow["balanced"] = true;

            ((MainForm)Owner).InvoicesTable.Rows.Add(newRow);

            InvoiceId = Convert.ToInt32 (newRow["id"]);
            return newRow;
        }
    }
}
