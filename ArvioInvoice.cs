using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Wendy
{
    public class ArvioInvoice : InvoiceForm
    {
        override protected void InitializeLabels()
        {
            // Default arviolasku
            balanced.Checked = false;
            invoiceTypeTxt.Text = "Arviolasku";
            arvioTxt.Show();
            arvioConsumption.Show();
        }

        override protected DataRow[] ShowData()
        {
            DataRow[] invoiceRow = base.ShowData ();
            arvioConsumption.Text = String.Format("{0:0}", m_estimation); ;
            return invoiceRow;
        }

        override protected DataRow[] SaveInvoice()
        {
            DataRow[] invoiceRow = base.SaveInvoice ();
            if (invoiceRow.Length >= 1)
            {
                invoiceRow[0].BeginEdit();
                invoiceRow[0]["estimation"] = arvioConsumption.Text;
                invoiceRow[0].EndEdit();
            }
            return invoiceRow;
        }

        override protected DataRow AddInvoice()
        {
            DataRow newRow = base.AddInvoice();

            newRow.BeginEdit();
            newRow["balanced"] = false;
            newRow["estimation"] = arvioConsumption.Text;
            newRow.EndEdit();

            return newRow;
        }

        override protected void consumption_TextChanged(object sender, EventArgs e)
        {
            // Empty
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

        override protected void CalculateFees(double consumption)
        {
            int index = ((MainForm)Owner).config.GetIndex(endDate.Value);
            waterFee.Text =
                String.Format("{0:0.00}", consumption * ((MainForm)Owner).config.WaterFee(index));
            wasteFee.Text =
                String.Format("{0:0.00}", consumption * ((MainForm)Owner).config.WasteFee(index));
        }
    }
}
