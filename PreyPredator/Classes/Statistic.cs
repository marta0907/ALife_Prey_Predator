using System;
using System.Collections.Generic;
using System.Linq;

namespace PreyPredatorModel.Classes
{
    public static class Statistic
    {
        public static double Mean(List<double> array)
        {
            if (array is null || array.Count == 0)
            {
                return 0;
            }
            return array.Average();
        }

        public static double VAR(List<double> array)
        {
            var mean = Mean(array);
            List<double> array_2 = new List<double>();
            array.ForEach(x => array_2.Add(x * x));
            var sigma = Mean(array_2);
            return  sigma - mean * mean;
        }

        public static double StandartDerivation(List<double> array)
        {
            return Math.Sqrt(VAR(array)/(array.Count()-1));
        }

        public static double CV(List<double> array)
        {
            return Math.Sqrt(VAR(array)) / Mean(array);
        }
    }
}
