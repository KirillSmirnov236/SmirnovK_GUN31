using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public struct Interval
    {
        public int Min;
        public int Max;
        public Random random;

        public int Get() 
        {
            return random.Next(Min, Max);
        }

        public Interval(int minValue , int maxValue)
        {
            if (minValue < 0) 
            {
                minValue = 0;
                Console.WriteLine("minValue less than 0!");
            }
            if (maxValue < 0)
            {
                maxValue = 0;
                Console.WriteLine("maxValue less than 0!");
            }
            if (minValue == maxValue)
            {
                maxValue += 10;
                Console.WriteLine("minValue = maxValue!");
            }
            if (minValue > maxValue)
            {
                var x = maxValue;
                maxValue = minValue;
                minValue = x;
                Console.WriteLine("minValue bigger then maxValue!");
            }
            Min = minValue;
            Max = maxValue;
        }
    }
}
