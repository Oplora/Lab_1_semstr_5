using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab_1_semestr_5
{
    public delegate Complex FdblComplex(double x, double y);
    static class Program
    {
        static Complex Field_value(double x, double y)
        {
            Random generate = new Random();
            Complex value = generate.Next();
            return value;
        }
        static void Main(string[] args)
        {
            V1DataArray example = new V1DataArray(" ", DateTime.Now, 12, 4, 1.5, 0.5, Field_value);
            Console.WriteLine(example.ToLongString("{0:F2}"));
            V1DataList converted = (V1DataList)example;
            Console.WriteLine(converted.ToLongString("{0:F4}"));
            Console.WriteLine(example.Count + " " + example.AverageValue);
            Console.WriteLine(converted.Count + " " + converted.AverageValue);

            V1MainCollection Example = new V1MainCollection();
            V1DataArray example_1 = new V1DataArray("Testing", DateTime.Now, 6, 6, 0.5, 0.5, Field_value);
            V1DataList converted_1 = (V1DataList)example_1;
            Example.Add(example);
            Example.Add(example_1);
            Example.Add(converted);
            Example.Add(converted_1);
            Example.ToLongString("{0:F2}");

            for(int i = 0; i < Example.Count; ++i)
            {
                var elem = Example[i];
                Console.WriteLine(elem.Count);
                Console.WriteLine(elem.AverageValue);

            }
            Console.ReadLine();

            /*
            DataItem test = new DataItem(42.0, 2.0, new Complex(2.6, 3.2));
            string st = test.ToLongString("{0:F2}");//"my  format {0} {1} {2} {3}");
            Console.WriteLine(st);
            Console.WriteLine(test.ToString());
            V1DataList T1 = new V1DataList("1",DateTime.Now);
            T1.AddDefaults(10);
            Console.WriteLine(T1.ToLongString("{F:2}"));
            Console.ReadLine();
            */
        }
    }
}
