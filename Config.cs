using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Globalization;

namespace Wendy
{
    public class Config
    {
        private MainForm m_owner = null;
        private DataRow[] confRow;
        private CultureInfo m_culture;
        
        public Config(Form owner)
        {
            m_owner = (MainForm)owner;
            confRow = m_owner.ConfigFee.Select();
            m_culture = new CultureInfo("en-IE");
        }

        public int AddIndex()
        {
            DataRow newRow = m_owner.ConfigFee.NewRow();
            m_owner.ConfigFee.Rows.Add(newRow);
            confRow = m_owner.ConfigFee.Select();

            return confRow.Length - 1;
        }

        public int GetIndex(DateTime date)
        {
            int index = -1;
            for (int i = 0; i < confRow.Length && index < 0; i++)
            {
                DatePeriod period = Period (i);
                if (period.Voimassa(date))
                {
                    index = i;
                }
            }
            return index;
        }

        public int GetNextIndex(DateTime date)
        {
            int currIndex = GetIndex(date);
            DatePeriod period = Period (currIndex);

            if (period.End != DateTime.MaxValue)
            {
                return GetIndex(period.End.AddDays(1));
            }
            return -1;
        }
        public int GetPrevIndex(DateTime date)
        {
            int currIndex = GetIndex(date);
            DatePeriod period = Period(currIndex);

            if (period.Begin != DateTime.MinValue)
            {
                return GetIndex(period.Begin.AddDays(-1));
            }
            return -1;
        }

        public String PeriodBeginsDisplay(int index)
        {
            if (index >= 0 && index < confRow.Length)
            {
                try
                {
                    String ret = ((DateTime)confRow[index]["begin"]).ToString("d", m_culture);
                    return ret;
                }
                catch {}
            }
            return "";
        }
        public void SetPeriod(int index, String begin, String end)
        {
            if (index >= 0 && index < confRow.Length)
            {
                try
                {
                    confRow[index]["begin"] = Convert.ToDateTime(begin);
                }
                catch
                {
                    confRow[index]["begin"] = DBNull.Value;
                }
                try
                {
                    confRow[index]["end"] = Convert.ToDateTime(end);
                }
                catch
                {
                    confRow[index]["end"] = DBNull.Value;
                }

            }
        }
        public String PeriodEndsDisplay(int index)
        {
            if (index >= 0 && index < confRow.Length)
            {
                try
                {
                    String ret = ((DateTime)confRow[index]["end"]).ToString("d", m_culture);
                    return ret;
                }
                catch { }
            }
            return "";
        }
        public DatePeriod Period(int index)
        {
            return new DatePeriod(PeriodBeginsDisplay(index), PeriodEndsDisplay(index)); ;
        }


        public String WaterFeeDisplay(int index)
        {
            if (index >= 0 && index < confRow.Length)
            {
                return confRow[index]["waterfee"].ToString();
            }
            return "";
        }
        public void SetWaterFee(int index, String fee)
        {
            if (index >= 0 && index < confRow.Length)
            {
                try
                {
                    confRow[index]["waterfee"] = Convert.ToDouble(fee);
                }
                catch
                {
                    confRow[index]["waterfee"] = 0;
                }
            }
        }

        public Double WaterFee(int index)
        {
            if (index >= 0 && index < confRow.Length)
            {
                return Convert.ToDouble (confRow[index]["waterfee"]);
            }
            return 0;
        }
        public void SetWasteFee(int index, String fee)
        {
            if (index >= 0 && index < confRow.Length)
            {
                try
                {
                    confRow[index]["wastefee"] = Convert.ToDouble(fee);
                }
                catch
                {
                    confRow[index]["wastefee"] = 0;
                }
            }
        }
        public String WasteFeeDisplay(int index)
        {
            if (index >= 0 && index < confRow.Length)
            {
                return confRow[index]["wastefee"].ToString();
            }
            return "";
        }
        public Double WasteFee(int index)
        {
            if (index >= 0 && index < confRow.Length)
            {
                return Convert.ToDouble(confRow[index]["wastefee"]);
            }
            return 0;
        }
        public void SetVAT(int index, String vat)
        {
            if (index >= 0 && index < confRow.Length)
            {
                try
                {
                    confRow[index]["vat"] = Convert.ToDouble(vat);
                }
                catch
                {
                    confRow[index]["vat"] = 0;
                }
            }
        }
        public String VATDisplay(int index)
        {
            if (index >= 0 && index < confRow.Length)
            {
                return confRow[index]["vat"].ToString();
            }
            return "";
        }
        public Double VAT(int index)
        {
            if (index >= 0 && index < confRow.Length)
            {
                return Convert.ToDouble(confRow[index]["vat"]);
            }
            return 0;
        }

        public String StartConsumptionDisplay()
        {
            DataRow[] genConfRow = m_owner.Config.Select();
            if (genConfRow.Length > 0)
            {
                return genConfRow[0]["startconsumption"].ToString();
            }
            return "";
        }
        public Int32 StartConsumption()
        {
            Int32 startLukema = 0;

            try
            {
                DataRow[] genConfRow = m_owner.Config.Select();
                startLukema = Convert.ToInt32(genConfRow[0]["startConsumption"]);
            }
            catch { }

            return startLukema;
        }
        public void SetStartConsumption(String data)
        {
            DataRow[] genConfRow = m_owner.Config.Select();
            if (genConfRow.Length == 0)
            {
                DataRow newRow = m_owner.Config.NewRow ();
                m_owner.Config.Rows.Add(newRow);
                genConfRow = m_owner.Config.Select();
            }

            genConfRow[0]["startconsumption"] = data;
        }

        public int GetUserCount()
        {
            return m_owner.UserNames.Rows.Count;
        }

    }
}
