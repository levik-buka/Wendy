using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Wendy
{
    class UserTasaus : InvoiceForm
    {
        private string m_username;
        public string Username { get { return m_username; } set { m_username = value; } }

        override protected void InitializeLabels()
        {
            // Default tasauslasku
            base.InitializeLabels();
            userName.Show();
            startDate.Enabled = false;
            endDate.Enabled = false;
        }

        override protected DataRow[] ShowData()
        {
            base.ShowData();

            userName.Text = Username;

            string query = String.Format("id = {0} and user = '{1}'", InvoiceId, Username);
            DataRow[] invoiceRow = ((MainForm)Owner).UsersTable.Select(query);
            if (invoiceRow.Length >= 1)
            {
                if (!DBNull.Value.Equals(invoiceRow[0]["consumption"])
                    && Convert.ToInt32(invoiceRow[0]["consumption"]) != 0)
                {
                    lukema.Text = invoiceRow[0]["consumption"].ToString();
                }
                else
                {
                    lukema.Text = String.Format("{0:0}", CalculateUserLukema(Convert.ToInt32(lukema.Text)));
                }

                if (!DBNull.Value.Equals(invoiceRow[0]["basicfee"])
                    && Convert.ToInt32(invoiceRow[0]["basicfee"]) != 0)
                {
                    basicFee.Text = invoiceRow[0]["basicfee"].ToString();
                }
                else
                {
                    basicFee.Text = String.Format("{0:0.00}", CalculateUserBasicFee(Convert.ToDouble(basicFee.Text)));
                }

                if (!DBNull.Value.Equals(invoiceRow[0]["waterfee"])
                    && Convert.ToInt32(invoiceRow[0]["waterfee"]) != 0)
                {
                    waterFee.Text = invoiceRow[0]["waterfee"].ToString();
                }
                if (!DBNull.Value.Equals(invoiceRow[0]["wastefee"])
                    && Convert.ToInt32(invoiceRow[0]["wastefee"]) != 0)
                {
                    wasteFee.Text = invoiceRow[0]["wastefee"].ToString();
                }

                balanced.Checked = ((MainForm)Owner).IsRowBalanced(invoiceRow[0]);
            }
            else
            {
                lukema.Text = String.Format("{0:0}", CalculateUserLukema(Convert.ToInt32(lukema.Text)));
                basicFee.Text = String.Format("{0:0.00}", CalculateUserBasicFee(Convert.ToDouble(basicFee.Text)));
            }

            return invoiceRow;
        }

        override public Int32 GetConsumption(DateTime before, Int32 lukemaNow)
        {
            return ((MainForm)Owner).GetConsumption(Username, balanced.Checked, before, lukemaNow);
        }

        override public Fee GetNonBalancedFee(DateTime before)
        {
            return ((MainForm)Owner).GetNonBalancedFee(Username, before);
        }

        override protected DataRow[] SaveInvoice()
        {
            string query = String.Format("id = {0} and user = '{1}'", InvoiceId, Username);
            DataRow[] invoiceRow = ((MainForm)Owner).UsersTable.Select(query);
            if (invoiceRow.Length >= 1)
            {
                invoiceRow[0].BeginEdit();
                invoiceRow[0]["consumption"] = lukema.Text;
                invoiceRow[0]["basicfee"] = Convert.ToDouble(basicFee.Text);
                invoiceRow[0]["waterfee"] = Convert.ToDouble(waterFee.Text);
                invoiceRow[0]["wastefee"] = Convert.ToDouble(wasteFee.Text);
                invoiceRow[0].EndEdit();
            }
            else
            {
                AddInvoice();
            }
            return invoiceRow;
        }

        override protected DataRow AddInvoice()
        {
            if (InvoiceId >= 0)
            {
                DataRow newRow = ((MainForm)Owner).UsersTable.NewRow();

                newRow["id"] = InvoiceId;
                newRow["user"] = Username;
                newRow["consumption"] = lukema.Text;
                newRow["basicfee"] = Convert.ToDouble(basicFee.Text);
                newRow["waterfee"] = Convert.ToDouble(waterFee.Text);
                newRow["wastefee"] = Convert.ToDouble(wasteFee.Text);
                newRow["balanced"] = true;

                ((MainForm)Owner).UsersTable.Rows.Add(newRow);
                return newRow;
            }
            return null;
        }

        virtual protected Double CalculateUserBasicFee(Double totalBasicFee)
        {
            return totalBasicFee / ((MainForm)Owner).config.GetUserCount ();
        }

        virtual protected Int32 CalculateUserLukema(Int32 totalLukema)
        {
            Int32 lukema = totalLukema;

            string query = String.Format("id = {0}", InvoiceId);
            DataRow[] invoiceRow = ((MainForm)Owner).UsersTable.Select(query);
            if (invoiceRow.Length > 0)
            {
                foreach (DataRow row in invoiceRow)
                {
                    if (row["user"].ToString() != Username)
                    {
                        lukema -= Convert.ToInt32(row["consumption"]);
                    }
                }
            }
            else
            {
                Int32 kulutus = ((MainForm)Owner).GetConsumption(balanced.Checked, endDate.Value, lukema);
                lukema = -((MainForm)Owner).GetConsumption(Username, balanced.Checked, endDate.Value, 0) + kulutus;
            }

            return lukema;
        }
    }
}
