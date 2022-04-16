using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab_1_semestr_5
{
    public struct DataItem
    {
        // Auto-implemented properties for trivial get and set
        public double x { get; set; }
        public double y { get; set; }
        public Complex value { get; set; }

        public DataItem(double X, double Y , Complex Value)
        {
            x = X;
            y = Y;
            value = Value;
        }

        public string ToLongString(String format)
        {
            return String.Format(format, x) + " " + String.Format(format, y) + " " + String.Format(format, value) + " " + String.Format(format, Complex.Abs(value));

        }

        public override string ToString()
        {
            //return "123!!!";
            return base.ToString();
        }

    }
}
