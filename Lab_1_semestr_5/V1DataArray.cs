using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Lab_1_semestr_5
{
    class V1DataArray : V1Data
    {
        

        public double stepX { get; }
        public double stepY { get; }
        public int jointsX_amount { get; }
        public int jointsY_amount { get; }
        public Complex[,] value_in_grid_joints { get; }

        public V1DataArray(string identification, DateTime date_of_change) : base(identification, date_of_change)
        {
            value_in_grid_joints = new Complex[0,0];
        }
        public V1DataArray(string identification, DateTime date_of_change, int joints_on_X, int joints_on_Y, double stepX_value, double stepY_value, FdblComplex F) : base(identification, date_of_change)
        {
            
            // Have i done this constructor correctly?
            stepX = stepX_value;
            stepY = stepY_value;
            jointsX_amount = joints_on_X;
            jointsY_amount = joints_on_Y;
            value_in_grid_joints = new Complex[jointsY_amount, jointsX_amount];
            for (int i = 0; i < jointsY_amount; ++i)
            {
                for (int j = 0; j < jointsX_amount; ++j)
                {
                    value_in_grid_joints[i, j] = F(j * stepX, i * stepY);
                }
            }
          
        }

        public override int Count { get {return jointsX_amount * jointsY_amount; } }
        public override double AverageValue //Where I can get Field values to get the average value? 
        {
            get
            {
                double modulo = 0;
                foreach (var point in value_in_grid_joints)
                {
                    modulo += Complex.Abs(point);
                }
                return modulo / value_in_grid_joints.Length;

            }
        }
        public override string ToLongString(string format)
        {
            string str = Convert.ToString(this.GetType()) + " " + base.id + " " + base.period + " " + stepX + " " + stepY + " " + jointsX_amount + " " + jointsY_amount;
            for (int i = 0; i < jointsY_amount; ++i)
            {
                for (int j = 0; j < jointsX_amount; ++j)
                {
                    str += String.Format(format, j * stepX) + " " + String.Format(format,i * stepY) + " " + value_in_grid_joints[i,j] + " " + String.Format(format, Complex.Abs(value_in_grid_joints[i, j])) +"\n";
                }
            }
            return str;
        }

        public override string ToString()
        {
            return Convert.ToString(this.GetType()) + " " + base.id + " " + base.period + " " + stepX + " " + stepY + " " + jointsX_amount + " " + jointsY_amount;
        }

        public static explicit operator V1DataList (V1DataArray a)
        {
            V1DataList converted = new V1DataList("Use random here ", DateTime.Now);
            for (int i = 0; i < a.jointsY_amount; ++i)
            {
                for (int j = 0; j < a.jointsX_amount; ++j)
                {
                    DataItem point = new DataItem();
                    point.x = j * a.jointsX_amount;
                    point.y = i * a.jointsY_amount;
                    point.value = a.value_in_grid_joints[i, j];
                    converted.Add(point);
                }
            }
            return converted;
        }
    }
}
