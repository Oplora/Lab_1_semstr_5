using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_semestr_5
{
    abstract class V1Data
    {
        public string id { get; }
        public DateTime period { get; }

        public V1Data(string identification, DateTime date_of_change)
        {
            id = identification;
            period = date_of_change;
        }

        public abstract int Count { get;}
        public abstract double AverageValue { get;}
        public abstract string ToLongString(string format);

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
