using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_semestr_5
{
    class V1MainCollection
    {
        private List<V1Data> field = new List<V1Data>();

        public int Count { get { return field.Count(); } }
        public V1Data this[int index]
        {
            get
            {
                return field[index];
            }
        }
        public bool Contains(string ID)
        {
            foreach (var elem in field)
            {
                if (elem.id == ID)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Add(V1Data v1Data)
        {
            if (this.Contains(v1Data.id))
            {
                return false;
            }
            else
            {
               field.Add(v1Data);
                return true;
            }
        }
        public string ToLongString(string format)
        {
            string str = "";
            foreach (var elem in field)
            {
                str += elem.ToLongString(format) + "\n";
            }
            return str;
        }
        public override string ToString()
        {
            string str = "";
            foreach (var elem in field)
            {
                str += elem.ToString() + "\n";
            }
            return str;
        }
    }
}
  
