using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Printing;

namespace Wendy
{
    public partial class MainForm : Form
    {
        public Config config;
        Printing prv = null;

        public MainForm()
        {
            InitializeComponent();
            try
            {
                dataSet.ReadXml("wendy.xml");
            }
            catch
            { }

            config = new Config(this);
        }

        private void m_mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Tallennetaanko muutokset?", "Lopetus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                dataSet.WriteXml("wendy.xml");
            }
        }

        private void InvoiceView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                InvoiceForm form = null;
                if (e.RowIndex % (config.GetUserCount() + 1) == 0)
                {
                    try
                    {
                        if (Convert.ToInt32(InvoiceView.Rows[e.RowIndex].Cells[9].Value) > 0)
                        {
                            form = new ArvioInvoice();  // Arviolasku
                        }
                    }
                    catch { }

                    if (form == null)
                    {
                        form = new InvoiceForm();   // Tasauslasku
                    }
                }
                else
                {
                    try
                    {
                        if (Convert.ToInt32(InvoiceView.Rows[e.RowIndex].Cells[9].Value) > 0)
                        {
                            form = new UserArvio();
                        }
                    }
                    catch { }

                    if (form == null)
                    {
                        form = new UserTasaus();
                    }
                    ((UserTasaus)form).Username = InvoiceView.Rows[e.RowIndex].Cells[2].Value.ToString();
                }

                if (form != null)
                {
                    form.InvoiceId = Convert.ToInt32(InvoiceView.Rows[e.RowIndex].Cells[0].Value);
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        if (e.RowIndex % (config.GetUserCount() + 1) == 0)
                        {
                            ShowInvoiceRow(e.RowIndex, form.InvoiceId);
                        }
                        else
                        {
                            ShowUserRow(e.RowIndex, form.InvoiceId, ((UserTasaus)form).Username);
                        }
                    }
                }
            }
        }

        public Int32 GetStartConsumption(String user)
        {
            Int32 startLukema = 0;

            try
            {
                string query = "Name = '" + user + "'";
                DataRow[] confRow = UserNames.Select(query);
                startLukema = Convert.ToInt32(confRow[0]["startConsumption"]);
            }
            catch { }

            return startLukema;
        }

        public Int32 GetConsumption(bool balanced, DateTime before, Int32 lukemaNow)
        {
            bool done = false;
            Int32 prevLukema = 0;

            string beforeT = before.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            DataRow[] invoices = InvoicesTable.Select("endDate < #" + beforeT + "#", "endDate DESC");

            for (int i = 0; i < invoices.Length && !done; i++)
            {
                prevLukema = Convert.ToInt32(invoices[i]["consumption"]);
                if (!balanced || IsRowBalanced (invoices[i]))
                {
                    done = true;
                }
            }

            if (!done)
            {
                prevLukema = config.StartConsumption();
            }

            return lukemaNow - prevLukema;
        }

        public Fee GetNonBalancedFee(DateTime before)
        {
            bool done = false;
            int index = 0;
            Int32 LastBalancedLukema = 0;
            Consumption[] consumption;
            Fee fee = new Fee();

            string beforeT = before.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            DataRow[] invoices = InvoicesTable.Select("endDate < #" + beforeT + "#", "endDate DESC");
            consumption = new Consumption[invoices.Length];

            for (index = 0; index < invoices.Length && !done; index++)
            {
                consumption[index] = new Consumption();
                consumption[index].Lukema = Convert.ToInt32(invoices[index]["consumption"]);
                consumption[index].Date = Convert.ToDateTime(invoices[index]["enddate"]);
                LastBalancedLukema = consumption[index].Lukema;

                if (IsRowBalanced (invoices[index]))
                {
                    done = true;
                    index--;
                }
            }

            if (!done)
            {
                LastBalancedLukema = config.StartConsumption();
            }

            for (int i = index - 1; i >= 0; i--)
            {
                int confIndex = config.GetIndex(consumption[i].Date);
                Int32 kulutus = consumption[i].Lukema - LastBalancedLukema;

                LastBalancedLukema = consumption[i].Lukema;
                fee.Consumption += kulutus;
                fee.WaterFee += (kulutus * config.WaterFee(confIndex));
                fee.WasteFee += (kulutus * config.WasteFee(confIndex));
                fee.BasicFee += Convert.ToDouble (invoices[i]["basicfee"]);
            }

            return fee;
        }

        public Int32 GetConsumption(string user, bool balanced, DateTime before, Int32 lukemaNow)
        {
            bool done = false;
            Int32 prevLukema = 0;

            string beforeT = before.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            DataRow[] invoices = InvoicesTable.Select("endDate < #" + beforeT + "#", "endDate DESC");
            for (int i  = 0; i < invoices.Length && !done; i++)
            {
                string query = String.Format("id = {0} and user = '{1}'", invoices[i]["id"], user);
                DataRow[] users = UsersTable.Select(query);
                if (users.Length > 0)
                {
                    prevLukema = Convert.ToInt32(users[0]["consumption"]);
                }

                if (!balanced || IsRowBalanced(invoices[i]))
                {
                    done = true;
                }
            }

            if (!done)
            {
                prevLukema = GetStartConsumption(user);
            }

            return lukemaNow - prevLukema;
        }

        public Fee GetNonBalancedFee(string user, DateTime before)
        {
            bool done = false;
            int index = 0;
            Fee fee = new Fee();
            Consumption[] consumption;
            Int32 LastBalancedLukema = 0;

            string beforeT = before.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            DataRow[] invoices = InvoicesTable.Select("endDate < #" + beforeT + "#", "endDate DESC");
            consumption = new Consumption[invoices.Length];

            for (index = 0; index < invoices.Length && !done; index++)
            {
                string query = String.Format("id = {0} and user = '{1}'", invoices[index]["id"], user);
                DataRow[] users = UsersTable.Select(query);
                if (users.Length > 0)
                {
                    consumption[index] = new Consumption();
                    consumption[index].Lukema = Convert.ToInt32(users[0]["consumption"]);
                    consumption[index].Date = Convert.ToDateTime(invoices[index]["enddate"]);
                    LastBalancedLukema = consumption[index].Lukema;
                }

                if (IsRowBalanced(invoices[index]))
                {
                    done = true;
                }
            }

            if (!done)
            {
                LastBalancedLukema = config.StartConsumption();
            }

            for (int i = index - 1; i >= 0; i--)
            {
                int confIndex = config.GetIndex(consumption[i].Date);
                Int32 kulutus = consumption[i].Lukema - LastBalancedLukema;

                LastBalancedLukema = consumption[i].Lukema;
                fee.Consumption += kulutus;
                fee.WaterFee += (kulutus * config.WaterFee(confIndex));
                fee.WasteFee += (kulutus * config.WasteFee(confIndex));
            }

            return fee;
        }

        private Int32 PrevLukema(string user, Int32 newConsumption, ref DataTable lukemat)
        {
            Int32 prevLukema = 0;

            if (lukemat.Columns.Count == 0)
            {
                lukemat.Columns.Add("username", typeof(string));
                lukemat.Columns.Add("lukema", typeof(Int32));
            }

            try
            {
                string query = "username = '" + user + "'";
                DataRow[] userRow = lukemat.Select(query);
                prevLukema = Convert.ToInt32(userRow[0]["lukema"]);
                userRow[0]["lukema"] = newConsumption;
            }
            catch
            {
                prevLukema = GetStartConsumption(user);

                DataRow newRow = lukemat.NewRow();
                newRow["username"] = user;
                newRow["lukema"] = newConsumption;
                lukemat.Rows.Add(newRow);
            }

            return prevLukema;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                ShowAllData();
            }
            catch { }
            CalculateSumOfSelectedRows();
        }

        private void ShowAllData()
        {
            Int32 prevLukema = config.StartConsumption();
            DataTable userPrevLukema = new DataTable();

            DataRow[] rows = InvoicesTable.Select("", "enddate ASC");
            foreach (DataRow row in rows)
            {
                int rowNr = InvoiceView.Rows.Add();

                ShowInvoiceRow(rowNr, row["id"], row["balanced"],
                    row["startdate"], row["enddate"],
                    row["consumption"], Convert.ToInt32(row["consumption"]) - prevLukema, row["estimation"],
                    row["basicfee"], row["waterfee"], row["wastefee"]);

                prevLukema = Convert.ToInt32(row["consumption"]);

                DataRow[] users = UsersTable.Select("id = " + row["Id"]);
                foreach (DataRow urow in users)
                {
                    int urowNr = InvoiceView.Rows.Add();

                    ShowUserRow(urowNr, urow["id"], urow["balanced"], urow["user"],
                        row["enddate"], urow["consumption"],
                        Convert.ToInt32(urow["consumption"]) - PrevLukema(urow["user"].ToString(), Convert.ToInt32(urow["consumption"]), ref userPrevLukema),
                        row["estimation"],
                        urow["basicfee"], urow["waterfee"], urow["wastefee"]);
                }
            }
        }

        private void ShowInvoiceRow(int rowNr, Int32 id)
        {
            DataRow[] invoiceRow = InvoicesTable.Select("id = " + id);
            if (invoiceRow.Length >= 1)
            {
                bool balanced = IsRowBalanced (invoiceRow[0]);
                ShowInvoiceRow(rowNr, id, balanced,
                    invoiceRow[0]["startdate"], invoiceRow[0]["enddate"],
                    invoiceRow[0]["consumption"],
                    GetConsumption(balanced, Convert.ToDateTime(invoiceRow[0]["enddate"]), Convert.ToInt32(invoiceRow[0]["consumption"])),
                    invoiceRow[0]["estimation"],
                    invoiceRow[0]["basicfee"], invoiceRow[0]["waterfee"], invoiceRow[0]["wastefee"]);
            }
        }

        private void ShowInvoiceRow(int rowNr, Object id, Object balanced,
            Object startDate, Object endDate,
            Object consumption, Object lukema, Object estimation,
            Object basicFee, Object waterFee, Object wasteFee)
        {
            InvoiceView.Rows[rowNr].DefaultCellStyle.BackColor = Color.LightCyan;
            InvoiceView.Rows[rowNr].DefaultCellStyle.Font = new Font(
                InvoiceView.DefaultCellStyle.Font.FontFamily,
                InvoiceView.DefaultCellStyle.Font.Size,
                FontStyle.Bold);

            Double totalFee = Convert.ToDouble(basicFee) + Convert.ToDouble(waterFee) + Convert.ToDouble(wasteFee);

            InvoiceView.Rows[rowNr].Cells[0].Value = id;
            InvoiceView.Rows[rowNr].Cells[1].Value = startDate;
            InvoiceView.Rows[rowNr].Cells[2].Value = Convert.ToDateTime(endDate).ToShortDateString();
            InvoiceView.Rows[rowNr].Cells[3].Value =
                String.Format("{0} ({1}) m3", lukema, consumption);
            InvoiceView.Rows[rowNr].Cells[4].Value = basicFee;
            InvoiceView.Rows[rowNr].Cells[5].Value = waterFee;
            InvoiceView.Rows[rowNr].Cells[6].Value = wasteFee;
            InvoiceView.Rows[rowNr].Cells[7].Value = balanced;
            InvoiceView.Rows[rowNr].Cells[8].Value = totalFee;
            InvoiceView.Rows[rowNr].Cells[9].Value = estimation;
            if (IsRowBalanced(InvoiceView.Rows[rowNr]))
            {
                InvoiceView.Rows[rowNr].Cells[10].Value = CalculateVAT(totalFee, Convert.ToDateTime(endDate)) - CalculateNonBalancedFee (rowNr);
            }
            else
            {
                InvoiceView.Rows[rowNr].Cells[10].Value = CalculateVAT(totalFee, Convert.ToDateTime(endDate));
            }

            CheckTotalFee(rowNr);
        }

        private void ShowUserRow(int rowNr, Int32 id, string user)
        {
            string query = String.Format("id = {0} and user = '{1}'", id, user);
            DataRow[] userRow = UsersTable.Select(query);
            if (userRow.Length >= 1)
            {
                DateTime endDate = new DateTime();
                Object estimation = new Int32();

                bool balanced = IsRowBalanced (userRow[0]);

                DataRow[] invoiceRow = InvoicesTable.Select("id = " + id);
                if (invoiceRow.Length >= 1)
                {
                    endDate = Convert.ToDateTime(invoiceRow[0]["enddate"]);
                    estimation = invoiceRow[0]["estimation"];
                }

                ShowUserRow(rowNr, id, balanced, user, endDate,
                    userRow[0]["consumption"],
                    GetConsumption(user, balanced, endDate, Convert.ToInt32(userRow[0]["consumption"])),
                    estimation,
                    userRow[0]["basicfee"], userRow[0]["waterfee"], userRow[0]["wastefee"]);
            }
        }

        private void ShowUserRow(int rowNr, Object id, Object balanced,
            Object username, Object endDate, 
            Object consumption, Object lukema, Object estimation,
            Object basicFee, Object waterFee, Object wasteFee)
        {
            Double totalFee = Convert.ToDouble(basicFee) + Convert.ToDouble(waterFee) + Convert.ToDouble(wasteFee);

            InvoiceView.Rows[rowNr].Cells[0].Value = id;
            InvoiceView.Rows[rowNr].Cells[2].Value = username;
            InvoiceView.Rows[rowNr].Cells[3].Value =
                String.Format("{0} ({1}) m3", lukema, consumption);
            InvoiceView.Rows[rowNr].Cells[4].Value = basicFee;
            InvoiceView.Rows[rowNr].Cells[5].Value = waterFee;
            InvoiceView.Rows[rowNr].Cells[6].Value = wasteFee;
            InvoiceView.Rows[rowNr].Cells[7].Value = balanced;
            InvoiceView.Rows[rowNr].Cells[8].Value = totalFee;
            InvoiceView.Rows[rowNr].Cells[9].Value = estimation;
            if (IsRowBalanced(InvoiceView.Rows[rowNr]))
            {
                InvoiceView.Rows[rowNr].Cells[10].Value = CalculateVAT(totalFee, Convert.ToDateTime(endDate)) - CalculateNonBalancedFee(rowNr);
            }
            else
            {
                InvoiceView.Rows[rowNr].Cells[10].Value = CalculateVAT(totalFee, Convert.ToDateTime (endDate));
            }

            CheckTotalFee(rowNr);
        }

        private Double CalculateNonBalancedFee(int rowNr)
        {
            Double nonBalancedFee = 0;
            rowNr -= (config.GetUserCount() + 1);

            if (rowNr >= 0)
            {
                if (!IsRowBalanced (InvoiceView.Rows[rowNr]))
                {
                    nonBalancedFee = GetRowTotalVATFee (InvoiceView.Rows[rowNr]);
                    nonBalancedFee += CalculateNonBalancedFee(rowNr);
                }
            }

            return nonBalancedFee;
        }

        private void CheckTotalFee(int rowNr)
        {
            if (rowNr % (config.GetUserCount() + 1) > 0)
            {
                rowNr -= rowNr % (config.GetUserCount() + 1);
            }

            if (InvoiceView.Rows.Count >= rowNr + config.GetUserCount() + 1)
            {
                Double totalFee = GetRowTotalFee (InvoiceView.Rows[rowNr]);
                Double usersFee = 0;

                for (int i = rowNr + 1; i < config.GetUserCount() + rowNr + 1; i++)
                {
                    usersFee += Convert.ToDouble(InvoiceView.Rows[i].Cells[8].Value);
                }

                Color attention = Color.White;
                if (Math.Round(totalFee, 2) != Math.Round(usersFee, 2))
                {
                    attention = Color.Tomato;
                    InvoiceView.Rows[rowNr].Cells[8].Value = String.Format("{0:0.00} ({1:0.00})", totalFee, usersFee);
                }
                else
                {
                    InvoiceView.Rows[rowNr].Cells[8].Value = String.Format("{0:0.00}", totalFee);
                }

                for (int i = rowNr + 1; i < config.GetUserCount() + rowNr + 1; i++)
                {
                    InvoiceView.Rows[i].Cells[8].Style.BackColor = attention;
                }
            }
        }

        private void config_Click(object sender, EventArgs e)
        {
            ConfigForm confForm = new ConfigForm();
            confForm.ShowDialog(this);
        }

        private void InvoiceView_SelectionChanged(object sender, EventArgs e)
        {
            CalculateSumOfSelectedRows();
        }

        private void CalculateSumOfSelectedRows()
        {
            Double selSum = 0;
            Double noAlvSum = 0;

            foreach (DataGridViewRow row in InvoiceView.SelectedRows)
            {
                try
                {
                    noAlvSum += GetRowTotalFee (row);
                    selSum += GetRowTotalVATFee (row);
                }
                catch { }
            }

            SelectedSum.Text = String.Format("{0:0.00} + {1:0.00}(alv) = {2:0.00}",
                noAlvSum, selSum - noAlvSum, selSum);
        }

        private void DeleteSelectedRows()
        {
            if (MessageBox.Show("Poistetaanko valitut laskut?", "Posto", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in InvoiceView.SelectedRows)
                {
                    Int32 invoiceId = Convert.ToInt32 (row.Cells[0].Value);

                    if (row.Index % (config.GetUserCount() + 1) == 0)
                    {

                        DataRow[] users = UsersTable.Select("id = " + invoiceId);
                        foreach (DataRow user in users)
                        {
                            user.Delete();
                            InvoiceView.Rows.RemoveAt(row.Index + 1);
                        }

                        DataRow[] invoices = InvoicesTable.Select("id = " + invoiceId);
                        if (invoices.Length > 0)
                        {
                            invoices[0].Delete();
                            InvoiceView.Rows.RemoveAt(row.Index);
                        }
                    }
                    else
                    {
                        string username = row.Cells[2].Value.ToString();
                        string query = String.Format("id = {0} and user = '{1}'", invoiceId, username);
                        DataRow[] users = UsersTable.Select(query);
                        if (users.Length > 0)
                        {
                            users[0].Delete();
                            InvoiceView.Rows.RemoveAt(row.Index);
                        }
                    }
                }
            }
        }

        public Double CalculateVAT(Double sum, DateTime date)
        {
            int index = config.GetIndex(date);
            return sum * ((100 + config.VAT(index)) / 100);
        }

        public Double CalculateEstimation(double totalConsumption, double totalEstimation, double userConsumption)
        {
            return (totalEstimation / totalConsumption) * userConsumption;
        }

        private void NewTasaus_Click(object sender, EventArgs e)
        {
            InvoiceForm form = new InvoiceForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                int rowNr = InvoiceView.Rows.Add();
                ShowInvoiceRow(rowNr, form.InvoiceId);

                DataRow[] users = UserNames.Select();
                foreach (DataRow user in users)
                {
                    UserTasaus userForm = new UserTasaus();
                    userForm.InvoiceId = form.InvoiceId;
                    userForm.Username = user["name"].ToString();

                    if (userForm.ShowDialog(this) == DialogResult.OK)
                    {
                        int urowNr = InvoiceView.Rows.Add();
                        ShowUserRow(urowNr, form.InvoiceId, userForm.Username);
                    }
                }
            }
        }
        private void NewArvio_Click(object sender, EventArgs e)
        {
            ArvioInvoice form = new ArvioInvoice();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                int rowNr = InvoiceView.Rows.Add();
                ShowInvoiceRow(rowNr, form.InvoiceId);

                DataRow[] users = UserNames.Select();
                foreach (DataRow user in users)
                {
                    UserArvio userForm = new UserArvio();
                    userForm.InvoiceId = form.InvoiceId;
                    userForm.Username = user["name"].ToString();

                    if (userForm.ShowDialog(this) == DialogResult.OK)
                    {
                        int urowNr = InvoiceView.Rows.Add();
                        ShowUserRow(urowNr, form.InvoiceId, userForm.Username);
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg,
                                       Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Delete:
                {
                    DeleteSelectedRows();
                    return true;
                }

                case Keys.Escape:
                {
                    Close();
                    return true;
                }

                default:
                return false;
            }
        }

        private bool IsRowBalanced(DataGridViewRow row)
        {
            try
            {
                return Convert.ToBoolean(row.Cells[7].Value);
            }
            catch
            {
                return false;
            }
        }
        public bool IsRowBalanced(DataRow invoiceRow)
        {
            if (DBNull.Value.Equals(invoiceRow["balanced"]) ||
                Convert.ToBoolean(invoiceRow["balanced"]) == false)
            {
                return false;
            }
            return true;
        }

        private Double GetRowTotalFee(DataGridViewRow row)
        {
            return Convert.ToDouble(row.Cells[8].Value.ToString().Split(' ')[0]);
        }
        private Double GetRowTotalVATFee(DataGridViewRow row)
        {
            return Convert.ToDouble(row.Cells[10].Value.ToString().Split(' ')[0]);
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.WindowState = FormWindowState.Maximized;

            // Set the UseAntiAlias property to true, which will allow the 
            // operating system to smooth fonts.
            dlg.UseAntiAlias = true;

            dlg.Document = printDoc;
            prv = new Printing(this);

            dlg.ShowDialog();
        }

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            prv.InvoiceCount = InvoiceView.SelectedRows.Count;
            int InvoiceOffSet = (prv.CurrentBalancedInvoiceIndex > 0) ? 1 : 0;

            prv.PrintHeader(e.Graphics);

            for (int invIndex = prv.CurrentInvoiceIndex - InvoiceOffSet; invIndex < prv.InvoiceCount; invIndex++)
            {
                e.HasMorePages = prv.HasMoreToPrint();
                if (!prv.DoesInvoiceFitPage())
                {
                    return;
                }

                DataGridViewRow row = InvoiceView.SelectedRows[invIndex];
                Int32 invoiceId = Convert.ToInt32(row.Cells[0].Value);

                if (prv.CurrentBalancedInvoiceIndex == 0)
                {
                    prv.PrintInvoice(invoiceId, 0);
                }

                if (IsRowBalanced(row))
                {
                    bool done = false;
                    int index = 0;

                    DatePeriod period = GetInvoiceDatePeriod(invoiceId);
                    string beforeT = period.End.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
                    DataRow[] invoices = InvoicesTable.Select("endDate < #" + beforeT + "#", "endDate DESC");

                    for (index = 0; index < invoices.Length && !done; index++)
                    {
                        if (IsRowBalanced(invoices[index]))
                        {
                            done = true;
                            index--;
                        }
                    }

                    prv.BalancedInvoiceCount = index;

                    for (int i = prv.CurrentBalancedInvoiceIndex - 1; i >= 0; i--)
                    {
                        e.HasMorePages = prv.HasMoreToPrint(); 
                        if (!prv.DoesInvoiceFitPage())
                        {
                            return;
                        }

                        Int32 arvioInvoiceId = Convert.ToInt32(invoices[i]["id"]);
                        prv.PrintInvoice(arvioInvoiceId, 1);
                    }

                    if (prv.BalancedInvoiceCount > 0)
                    {
                        prv.PrintTasausSummary(invoiceId);
                    }
                }
            }

            if (prv.InvoiceCount > 1)
            {
                e.HasMorePages = prv.HasMoreToPrint();
                if (e.HasMorePages && !prv.DoesSummaryFitPage())
                {
                    return;
                }
                else if (e.HasMorePages)
                {
                    prv.PrintTotalSummary();
                }
            }

            e.HasMorePages = prv.HasMoreToPrint();
            prv = new Printing(this);   // Reseting counters for real printing
        }

        public DatePeriod GetInvoiceDatePeriod(Int32 invoiceId)
        {
            DataRow[] invoices = InvoicesTable.Select("id = " + invoiceId);
            if (invoices.Length > 0)
            {
                DatePeriod period = new DatePeriod ();
                period.Begin  = Convert.ToDateTime(invoices[0]["startdate"]);
                period.End  = Convert.ToDateTime(invoices[0]["enddate"]);
                return period;
            }
            throw new Exception();
        }

        public Fee GetInvoiceFee(Int32 invoiceId)
        {
            Fee fee = new Fee();
            DataRow[] invoices = InvoicesTable.Select("id = " + invoiceId);
            if (invoices.Length > 0)
            {
                fee.BasicFee = Convert.ToDouble(invoices[0]["basicfee"]);
                fee.WaterFee = Convert.ToDouble(invoices[0]["waterfee"]);
                fee.WasteFee = Convert.ToDouble(invoices[0]["wastefee"]);
            }

            return fee;
        }

        public Fee GetInvoiceFee(string user, Int32 invoiceId)
        {
            Fee fee = new Fee();

            string query = String.Format("id = {0} and user = '{1}'", invoiceId, user);
            DataRow[] userRow = UsersTable.Select(query);
            if (userRow.Length >= 1)
            {
                fee.BasicFee = Convert.ToDouble(userRow[0]["basicfee"]);
                fee.WaterFee = Convert.ToDouble(userRow[0]["waterfee"]);
                fee.WasteFee = Convert.ToDouble(userRow[0]["wastefee"]);
            }

            return fee;
        }
    }
}
