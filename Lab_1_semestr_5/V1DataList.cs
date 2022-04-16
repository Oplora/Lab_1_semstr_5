using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab_1_semestr_5
{
    class V1DataList:V1Data
    {
        public List<DataItem> points { get; }
        public V1DataList(string identification, DateTime date_of_change) : base(identification, date_of_change)
        {
            points = new List<DataItem>();
        }

        public override int Count { get { return points.Count; } }
        public override double AverageValue 
        { 
            get 
            {
                double modulo = 0;
                foreach (var point in points) {
                    modulo += Complex.Abs(point.value);
                }
                return modulo / points.Count;
                
            }   
        }
        public override string ToLongString(string format)
        {
            string str= Convert.ToString(this.GetType()) + " " + base.id + " " + base.period + " " + points.Count;
            foreach (var point in points)
            {
                str += point.ToLongString(format)+"\n";
            }
            return str;
        }
        public bool Add(DataItem newItem)
        {
            if (points.Exists(elem => ((elem.x==newItem.x)&&(elem.y == newItem.y))))
            {
                return false;
            }
            else
            {
                points.Add(newItem);
                return true;
            }
        }

        public int AddDefaults(int nItems, FdblComplex F)
        {
            int amount = 0;
            Random generate = new Random();
            for (int i = 0; i < nItems; i++)
            {
                DataItem point = new DataItem();
                
                point.x = generate.Next();
                point.y = generate.Next();
                point.value = F(point.x, point.y);
                //Console.WriteLine("{0} {1}",point.x, point.y);

                amount += Add(point) ? 1 : 0;
            }
            return amount;
        }

        public override string ToString()
        {
            return Convert.ToString(this.GetType()) + " " + base.id + " " + base.period + " " + points.Count;
        }
    }
}
