using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentMain.Helpers
{
    public static class Maths
    {
        public static double GetPercentOfPointBetweenAandB(double point, double upperBound, double lowerBound)
        {
            double p = (upperBound - point) / (upperBound - lowerBound);
            return p;
        }

        public static long GrabMoneyPercent(double percentOf, long total)
        {
            long result = (long)(((double)total)/100 * percentOf);
            return result;
        }
    }
}
