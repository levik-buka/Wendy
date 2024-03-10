using System;
using System.Collections.Generic;
using System.Text;

namespace Wendy
{
    public class DatePeriod
    {
        private DateTime begin;
        public DateTime Begin { get { return begin; } set { begin = value; } }
        private DateTime end;
        public DateTime End { get { return end; } set { end = value; } }

        public DatePeriod()
        {
            Begin = DateTime.MaxValue;
            End = DateTime.MinValue;
        }

        public DatePeriod(String begin, String end)
        {
            Begin = ToDate(begin, DateTime.MinValue);
            End = ToDate(end, DateTime.MaxValue);
        }

        public static DateTime ToDate(String date, DateTime perus)
        {
            try
            {
                return Convert.ToDateTime(date);
            }
            catch
            {
                return perus;
            }
        }

        public bool Voimassa(DateTime date)
        {
            if (Begin.Date <= date.Date)
            {
                if (date.Date <= End.Date)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Intersection(DatePeriod period)
        {
            if (!Voimassa(period.Begin))
            {
                return period.Voimassa(Begin);
            }
            return true;
        }

    }
}
