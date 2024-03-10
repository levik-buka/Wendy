using System;
using System.Collections.Generic;
using System.Text;

namespace Wendy
{
    public class Fee
    {
        private Double basicFee = 0;
        public Double BasicFee { get { return basicFee; } set { basicFee = value; } }
        private Double waterFee = 0;
        public Double WaterFee { get { return waterFee; } set { waterFee = value; } }
        private Double wasteFee = 0;
        public Double WasteFee { get { return wasteFee; } set { wasteFee = value; } }
        private Int32 consumption = 0;
        public Int32 Consumption { get { return consumption; } set { consumption = value; } }

        public Double GetSum()
        {
            return BasicFee + WaterFee + WasteFee;
        }

        public static Fee operator - (Fee fee1, Fee fee2)
        {
            Fee newFee = new Fee();
            newFee.BasicFee = fee1.BasicFee - fee2.BasicFee;
            newFee.WaterFee = fee1.WaterFee - fee2.WaterFee;
            newFee.WasteFee = fee1.WasteFee - fee2.WasteFee;
            return newFee;
        }
        public static Fee operator +(Fee fee1, Fee fee2)
        {
            Fee newFee = new Fee();
            newFee.BasicFee = fee1.BasicFee + fee2.BasicFee;
            newFee.WaterFee = fee1.WaterFee + fee2.WaterFee;
            newFee.WasteFee = fee1.WasteFee + fee2.WasteFee;
            return newFee;
        }
    }

    public class Consumption
    {
        private Int32 lukema = 0;
        public Int32 Lukema { get { return lukema; } set { lukema = value; } }
        private DateTime date;
        public DateTime Date { get { return date; } set { date = value; } }
    }
}
