using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;

namespace Wendy
{
    public class Printing
    {
        private MainForm m_owner = null;
        private Graphics g = null;
        private float y = 0;
        private DatePeriod lastPeriod;
        private int pageCount = 0;
        
        private Fee[] totalFee;

        public Fee[] TotalFee
        {
            get { return totalFee; }
        }
        private Fee[] tasausFee;

        public Fee[] TasausFee
        {
            get { return tasausFee; }
        }

        public int InvoiceCount = 0;
        private int currentInvoice = 0;

        public int CurrentInvoiceIndex
        {
            get { return currentInvoice; }
        }

        private int balancedInvoiceCount = 0;
        public int BalancedInvoiceCount
        {
            get { return balancedInvoiceCount; }
            set 
            { 
                balancedInvoiceCount = value;
                if (currentBalancedInvoice == 0)
                {
                    currentBalancedInvoice = value;
                }
            }
        }

        private int currentBalancedInvoice = 0;
        public int CurrentBalancedInvoiceIndex
        {
            get { return currentBalancedInvoice; }
        }

        private bool totalSummaryPrinted = false;
        private bool tasausSummaryPrinted = false;

        public Printing(Form owner)
        {
            m_owner = (MainForm)owner;
            lastPeriod = new DatePeriod();
            
            int columnCount = m_owner.config.GetUserCount () + 1;
            totalFee = new Fee[columnCount];
            tasausFee = new Fee[columnCount];
            for (int i = 0; i < columnCount; i++)
            {
                totalFee[i] = new Fee();
                tasausFee[i] = new Fee();
            }
        }

        private float GetXForUser(int userIndex, int userCount)
        {
            return 200 + ((float)(GetDynamicWidth() * userIndex) / userCount);
        }
        private float GetXForRowTitle()
        {
            return 25;
        }
        private float GetXForSummary()
        {
            return GetDynamicWidth() + 150;
        }
        private int GetDynamicWidth()
        {
            return m_owner.printDoc.DefaultPageSettings.Bounds.Width - 350;
        }

        public bool HasMoreToPrint()
        {
            if (currentInvoice < InvoiceCount)
                return true;
            else if (currentBalancedInvoice > 0)
                return true;
            else if (BalancedInvoiceCount > 0 && !tasausSummaryPrinted)
                return true;
            else if (InvoiceCount > 1 && !totalSummaryPrinted)
                return true;
            else
                return false;
        }

        public bool DoesInvoiceFitPage()
        {
            return ((y + 220) < m_owner.printDoc.DefaultPageSettings.Bounds.Height);
        }

        public bool DoesSummaryFitPage()
        {
            return ((y + 30) < m_owner.printDoc.DefaultPageSettings.Bounds.Height);
        }

        public void ResetInvoiceCounters()
        {
            BalancedInvoiceCount = 0;
            currentBalancedInvoice = 0;
            currentInvoice++;
            y += 30;

            for (int i = 0; i < tasausFee.Length; i++)
            {
                tasausFee[i] = new Fee();
            }
        }

        public void PrintHeader(Graphics grp)
        {
            g = grp;
            y = 10;
            pageCount++;

            Font headerFont = new Font("Arial", 20, FontStyle.Bold);
            Font printFont = new Font("Arial", 8, FontStyle.Regular);

            g.DrawString("Vesilaskuerittely", headerFont, Brushes.Blue, m_owner.printDoc.DefaultPageSettings.Bounds.Width / 2 - 125, y);
            g.DrawString(DateTime.Now.ToShortDateString(), printFont, Brushes.Black, m_owner.printDoc.DefaultPageSettings.Bounds.Width - 100, y);
            y += printFont.Height;
            g.DrawString("Sivu: " + pageCount.ToString (), printFont, Brushes.Black, m_owner.printDoc.DefaultPageSettings.Bounds.Width - 100, y);

            y = 50;
        }

        public void PrintLine(int ticks)
        {
            g.DrawLine(new Pen(Brushes.Blue, ticks), GetXForRowTitle(), y, GetXForSummary() + 150, y);
            y += ticks + 3;
        }

        public void PrintInvoice(Int32 invoiceId, int level)
        {
            if (level == 0)
            {
                ResetInvoiceCounters();
            }
            else if (level > 0 && currentBalancedInvoice > 0)
            {
                currentBalancedInvoice--;
            }

            PrintInvoiceDatePeriod(invoiceId, level);
            PrintUsers();
            PrintConsumptionLine(invoiceId);
            PrintWaterFeeLine(invoiceId);
            PrintWasteFeeLine(invoiceId);
            PrintBasicFeeLine(invoiceId);
            PrintLine(1);
            PrintSummaryLine(invoiceId, level);
            y += 20;
        }

        private void PrintUsers()
        {
            Font printFont = new Font("Arial", 10, FontStyle.Bold);
            int i = 0;

            DataRow[] users = m_owner.UserNames.Select();
            foreach (DataRow user in users)
            {
                g.DrawString(user["name"].ToString(), printFont, Brushes.Black, GetXForUser(i, users.Length), y);
                i++;
            }
            g.DrawString("YHTEENSÄ", printFont, Brushes.Black, GetXForSummary(), y);

            y += printFont.Height + 3;
        }

        private void PrintConsumptionLine(Int32 invoiceId)
        {
            Font printFont = new Font("Arial", 10, FontStyle.Regular);

            g.DrawString("Kulutus/Lukema (m3)", printFont, Brushes.Black, GetXForRowTitle(), y);

            DateTime endDate = new DateTime();
            int estimation = 0;
            int totalConsumpion = 0;
            int periodTotalConsumption = 0;
            bool balanced = false;

            DataRow[] invoiceRow = m_owner.InvoicesTable.Select("id = " + invoiceId);
            if (invoiceRow.Length >= 1)
            {
                balanced = m_owner.IsRowBalanced(invoiceRow[0]);
                endDate = Convert.ToDateTime(invoiceRow[0]["enddate"]);
                totalConsumpion = Convert.ToInt32(invoiceRow[0]["consumption"]);
                periodTotalConsumption = m_owner.GetConsumption(balanced, endDate, totalConsumpion);
                try
                {
                    estimation = Convert.ToInt32(invoiceRow[0]["estimation"]);
                }
                catch { }
            }

            int i = 0;
            DataRow[] users = m_owner.UserNames.Select();
            foreach (DataRow user in users)
            {
                string userName = user["name"].ToString();

                string query = String.Format("id = {0} and user = '{1}'", invoiceId, userName);
                DataRow[] userRow = m_owner.UsersTable.Select(query);
                if (userRow.Length >= 1)
                {
                    int userConsumption = Convert.ToInt32(userRow[0]["consumption"]);
                    int periodUserConsumption = m_owner.GetConsumption(userName, balanced, endDate, userConsumption);

                    string valueLine = "";
                    if (!balanced)
                    {
                        valueLine = String.Format("{0:0}", m_owner.CalculateEstimation(periodTotalConsumption, estimation, periodUserConsumption));
                    }
                    else
                    {
                        valueLine = String.Format("{0:0}", periodUserConsumption);
                    }
                    valueLine += "/" + userConsumption;

                    g.DrawString(valueLine, printFont, Brushes.Black, GetXForUser(i, users.Length), y);
                }
                i++;
            }

            string summaryLine = String.Format("{0:0}", estimation);
            if (balanced)
            {
                summaryLine = String.Format("{0:0}", m_owner.GetConsumption(balanced, endDate, totalConsumpion));
            }
            summaryLine += "/" + totalConsumpion;

            g.DrawString(summaryLine, printFont, Brushes.Black, GetXForSummary(), y);

            y += printFont.Height;
        }

        private void PrintBasicFeeLine(Int32 invoiceId)
        {
            Font printFont = new Font("Arial", 10, FontStyle.Regular);

            g.DrawString("Perusmaksu", printFont, Brushes.Black, GetXForRowTitle(), y);

            int i = 0;
            DataRow[] users = m_owner.UserNames.Select();
            foreach (DataRow user in users)
            {
                Fee userFee = m_owner.GetInvoiceFee(user["name"].ToString(), invoiceId);
                string valueLine = String.Format("{0:0.00 eur}", userFee.BasicFee);
                g.DrawString(valueLine, printFont, Brushes.Black, GetXForUser(i, users.Length), y);
                i++;
            }

            Fee invoiceFee = m_owner.GetInvoiceFee(invoiceId);
            string summaryLine = String.Format("{0:0.00 eur}", invoiceFee.BasicFee);
            g.DrawString(summaryLine, printFont, Brushes.Black, GetXForSummary(), y);

            y += printFont.Height;
        }

        private void PrintWaterFeeLine(Int32 invoiceId)
        {
            Font printFont = new Font("Arial", 10, FontStyle.Regular);

            g.DrawString("Vesimaksu", printFont, Brushes.Black, GetXForRowTitle(), y);

            int i = 0;
            DataRow[] users = m_owner.UserNames.Select();
            foreach (DataRow user in users)
            {
                Fee userFee = m_owner.GetInvoiceFee(user["name"].ToString(), invoiceId);
                string valueLine = String.Format("{0:0.00 eur}", userFee.WaterFee);
                g.DrawString(valueLine, printFont, Brushes.Black, GetXForUser(i, users.Length), y);
                i++;
            }

            Fee invoiceFee = m_owner.GetInvoiceFee(invoiceId);
            string summaryLine = String.Format("{0:0.00 eur}", invoiceFee.WaterFee);
            g.DrawString(summaryLine, printFont, Brushes.Black, GetXForSummary(), y);

            y += printFont.Height;
        }

        private void PrintWasteFeeLine(Int32 invoiceId)
        {
            Font printFont = new Font("Arial", 10, FontStyle.Regular);

            g.DrawString("Jätevesimaksu", printFont, Brushes.Black, GetXForRowTitle(), y);

            int i = 0;
            DataRow[] users = m_owner.UserNames.Select();
            foreach (DataRow user in users)
            {
                Fee userFee = m_owner.GetInvoiceFee (user["name"].ToString(), invoiceId);
                string valueLine = String.Format("{0:0.00 eur}", userFee.WasteFee);
                g.DrawString(valueLine, printFont, Brushes.Black, GetXForUser(i, users.Length), y);
                i++;
            }

            Fee invoiceFee = m_owner.GetInvoiceFee(invoiceId);
            string summaryLine = String.Format("{0:0.00 eur}", invoiceFee.WasteFee);
            g.DrawString(summaryLine, printFont, Brushes.Black, GetXForSummary(), y);

            y += printFont.Height;
        }

        private void PrintInvoiceDatePeriod(Int32 invoiceId, int level)
        {
            Font printFont = new Font("Arial", 12, FontStyle.Bold);

            DataRow[] invoices = m_owner.InvoicesTable.Select("id = " + invoiceId);
            if (invoices.Length > 0)
            {
                string text = "ARVIOLASKU";
                if (m_owner.IsRowBalanced(invoices[0]))
                {
                    text = "TASAUSLASKU";
                }

                DatePeriod period = m_owner.GetInvoiceDatePeriod(invoiceId);
                text += ": " + period.Begin.ToShortDateString() + " - " + period.End.ToShortDateString();

                g.DrawString(text, printFont, Brushes.Black, 10 + (level * 15), y);

                y += printFont.Height + 10;

                if (period.End > lastPeriod.End)
                {
                    lastPeriod = period;
                }
            }
        }

        private void PrintSummaryLine(Int32 invoiceId, int level)
        {
            Font printFont = new Font("Arial", 10, FontStyle.Regular);

            DateTime endDate = m_owner.GetInvoiceDatePeriod(invoiceId).End;
            double VAT = m_owner.config.VAT(m_owner.config.GetIndex(endDate));

            g.DrawString("YHTEENSÄ", printFont, Brushes.Black, GetXForRowTitle(), y);
            y += printFont.Height;
            string summaryLine = String.Format("(alv {0:0.0}%)", VAT);
            g.DrawString(summaryLine, printFont, Brushes.Black, GetXForRowTitle(), y);
            y -= printFont.Height;

            int i = 0;
            DataRow[] users = m_owner.UserNames.Select();
            foreach (DataRow user in users)
            {
                Fee userFee = m_owner.GetInvoiceFee(user["name"].ToString(), invoiceId);

                string valueLine = String.Format("{0:0.00 eur}", userFee.GetSum());
                g.DrawString(valueLine, printFont, Brushes.Black, GetXForUser(i, users.Length), y);
                y += printFont.Height;

                valueLine = String.Format("{0:0.00 eur}", m_owner.CalculateVAT(userFee.GetSum(), endDate));
                g.DrawString(valueLine, printFont, Brushes.Black, GetXForUser(i, users.Length), y);
                y -= printFont.Height;

                if (level == 0)
                {
                    totalFee[i] += userFee;
                    tasausFee[i] += userFee;
                }
                else if (level > 0)
                {
                    totalFee[i] -= userFee;
                    tasausFee[i] -= userFee;
                }

                i++;
            }

            Fee totalInvoiceFee = m_owner.GetInvoiceFee(invoiceId);
            summaryLine = String.Format("{0:0.00 eur}", totalInvoiceFee.GetSum());
            g.DrawString(summaryLine, printFont, Brushes.Black, GetXForSummary(), y);
            y += printFont.Height;

            summaryLine = String.Format("{0:0.00 eur}", m_owner.CalculateVAT(totalInvoiceFee.GetSum(), endDate));
            g.DrawString(summaryLine, printFont, Brushes.Black, GetXForSummary(), y);
            y += printFont.Height;

            if (level == 0)
            {
                totalFee[totalFee.Length - 1] += totalInvoiceFee;
                tasausFee[tasausFee.Length - 1] += totalInvoiceFee;
            }
            else if (level > 0)
            {
                totalFee[totalFee.Length - 1] -= totalInvoiceFee;
                tasausFee[tasausFee.Length - 1] -= totalInvoiceFee;
            }
        }

        public void PrintTasausSummary(Int32 invoiceId)
        {
            tasausSummaryPrinted = true;

            Font printFont = new Font("Arial", 12, FontStyle.Bold);
            Brush color = Brushes.Blue;

            DateTime endDate = m_owner.GetInvoiceDatePeriod(invoiceId).End;
            double VAT = m_owner.config.VAT(m_owner.config.GetIndex(endDate));

            PrintLine(2);
            g.DrawString("TASAUSMAKSU", printFont, Brushes.Black, GetXForRowTitle(), y);
            y += printFont.Height;
            string summaryLine = String.Format("(alv {0:0.0}%)", VAT);
            g.DrawString(summaryLine, printFont, Brushes.Black, GetXForRowTitle(), y);
            y -= printFont.Height;

            for (int i = 0; i < tasausFee.Length - 1; i++)
            {
                if (tasausFee[i].GetSum() > 0)
                {
                    color = Brushes.Red;
                }
                else
                {
                    color = Brushes.Blue;
                }

                string valueLine = String.Format("{0:0.00 eur}", tasausFee[i].GetSum());
                g.DrawString(valueLine, printFont, color, GetXForUser(i, tasausFee.Length - 1), y);
                y += printFont.Height;

                valueLine = String.Format("{0:0.00 eur}", m_owner.CalculateVAT(tasausFee[i].GetSum(), endDate));
                g.DrawString(valueLine, printFont, color, GetXForUser(i, tasausFee.Length - 1), y);
                y -= printFont.Height;
            }

            if (tasausFee[tasausFee.Length - 1].GetSum() > 0)
            {
                color = Brushes.Red;
            }
            else
            {
                color = Brushes.Blue;
            }

            summaryLine = String.Format("{0:0.00 eur}", tasausFee[tasausFee.Length - 1].GetSum());
            g.DrawString(summaryLine, printFont, color, GetXForSummary(), y);
            y += printFont.Height;

            summaryLine = String.Format("{0:0.00 eur}", m_owner.CalculateVAT(tasausFee[tasausFee.Length - 1].GetSum(), endDate));
            g.DrawString(summaryLine, printFont, color, GetXForSummary(), y);
            y += printFont.Height;
        }

        public void PrintTotalSummary()
        {
            y += 50;
            totalSummaryPrinted = true;

            Font printFont = new Font("Arial", 12, FontStyle.Bold);

            double VAT = m_owner.config.VAT(m_owner.config.GetIndex(lastPeriod.End));

            PrintLine(3);
            g.DrawString("YHTEENVETO:", printFont, Brushes.Blue, GetXForRowTitle(), y);
            y += printFont.Height;
            string summaryLine = String.Format("(alv {0:0.0}%)", VAT);
            g.DrawString(summaryLine, printFont, Brushes.Blue, GetXForRowTitle(), y);
            y -= printFont.Height;

            for (int i = 0; i < totalFee.Length - 1; i++)
            {
                string valueLine = String.Format("{0:0.00 eur}", totalFee[i].GetSum());
                g.DrawString(valueLine, printFont, Brushes.Blue, GetXForUser(i, totalFee.Length - 1), y);
                y += printFont.Height;

                valueLine = String.Format("{0:0.00 eur}", m_owner.CalculateVAT(totalFee[i].GetSum(), lastPeriod.End));
                g.DrawString(valueLine, printFont, Brushes.Blue, GetXForUser(i, totalFee.Length - 1), y);
                y -= printFont.Height;
            }

            summaryLine = String.Format("{0:0.00 eur}", totalFee[totalFee.Length - 1].GetSum());
            g.DrawString(summaryLine, printFont, Brushes.Blue, GetXForSummary(), y);
            y += printFont.Height;

            summaryLine = String.Format("{0:0.00 eur}", m_owner.CalculateVAT(totalFee[totalFee.Length - 1].GetSum(), lastPeriod.End));
            g.DrawString(summaryLine, printFont, Brushes.Blue, GetXForSummary(), y);
            y += printFont.Height;
        }

    }
}
