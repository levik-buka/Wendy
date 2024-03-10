using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Wendy
{
    class UserArvio : UserTasaus
    {
        override protected void InitializeLabels()
        {
            // Default tasauslasku
            base.InitializeLabels();
            balanced.Checked = false;
            invoiceTypeTxt.Text = "Arviolasku";
            arvioTxt.Show();
            arvioConsumption.Show();
            arvioConsumption.Enabled = false;
        }

        override protected void consumption_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateArvio(Convert.ToInt32(consumption.Text));
            }
            catch
            {
                CalculateArvio(0);
            }
        }

        override protected void arvioConsumption_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateFees(Convert.ToDouble(arvioConsumption.Text));
            }
            catch
            {
                CalculateFees(0);
            }
        }

        virtual protected void CalculateArvio(Int32 realUserConsumption)
        {
            arvioConsumption.Text = String.Format("{0:0}", ((MainForm)Owner).CalculateEstimation (m_totalConsumption, m_estimation, realUserConsumption));
        }

        override protected void CalculateFees(double consumption)
        {
            int index = ((MainForm)Owner).config.GetIndex(endDate.Value);
            waterFee.Text =
                String.Format("{0:0.00}", consumption * ((MainForm)Owner).config.WaterFee(index));
            wasteFee.Text =
                String.Format("{0:0.00}", consumption * ((MainForm)Owner).config.WasteFee(index));
        }

        override protected DataRow AddInvoice()
        {
            if (InvoiceId >= 0)
            {
                DataRow newRow = base.AddInvoice ();

                newRow.BeginEdit();
                newRow["balanced"] = false;
                newRow.EndEdit();

                return newRow;
            }
            return null;
        }

    }
}
