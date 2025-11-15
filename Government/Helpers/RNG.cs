using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Helpers
{
    //we're wrapping the random functions in case we want to do more to the rng manipulation for things
    public static class RNG
    {
        //for normal distribution, each one is for chunking a standard deviation
        static double zero = GenerateGaussianRandom(0, 1, 0);
        static double normal = GenerateGaussianRandom(1, 1, 0);
        static double good = GenerateGaussianRandom(2, 1, 0);
        static double great = GenerateGaussianRandom(3, 1, 0);
        static double genius = GenerateGaussianRandom(4, 1, 0);
        


        private static Random _rand = new Random();


        public static int Either(int a, int b)
        {
            int result = -1;
            result = (_rand.Next(2) != 0) ? a : b; //can be 0 or 1
            return result;
        }

        public static int Between(int low, int high)
        {
            int result = -1;
            result = _rand.Next(low, high + 1);
            return result;
        }
        public static int UpTo(int limit)
        {
            int result = -1;
            result = _rand.Next(limit + 1);
            return result;
        }

        //50 percentIn outOf 100 range = 50:50 odds.
        public static bool OutOf(int percentIn, int range = 100)
        {
            var n = _rand.Next(range);
            return (n < percentIn);
        }



        //for human stats
        public static double ApplyNormallyDistributedVariance(double input)
        {
            //used for +/- on modifiers
            const double default_percent = 25.0;//%
            double range = input / 100 * default_percent;

            double num = GenerateNormalisedValue(zero, genius); //we use the GaussianRandom to build the bounds
            double additional = Math.Floor(CalcAdditional(num, range));
            double variance = additional * Either(-1, 1);

            double newValue = input + variance;
            return newValue;
        }


        /// <summary>
        ///  ⁠
        /// </summary>
        /// <param name="x">a number from 0-1, the parameter of the function for normal distribution</param>
        /// <param name="variance">(sigma) σ^2, where σ is the standard deviation. e.g. 1.0</param>
        /// <param name="mu">μ mean, expectation of the distribution. Meaning, where we expect the bulk of em on a scale from -5 to +5 e.g. 0.</param>
        /// <returns></returns>
        public static double GenerateGaussianRandom(double x, double variance = 1.0, double mu = 0.0)
        {
            //increase variance value to spread datapoints out across the curve, decrease to focus on the mean.
            //change mu to shift position of the mean along the X-axis towards 5 or -5

            // https://en.wikipedia.org/wiki/Normal_distribution
            const double e = 2.718;
            const double pi = 3.141596;

            double result = 0;

            //read in reverse for an explanation
            var a = Math.Pow(x - mu, 2); //(x - μ)^2
            var ePower = -(a / (2 * variance)); //negative ^ over 2σ^2
            var b = Math.Pow(e, ePower); //e to the power of ^

            //
            var c = 2 * pi * variance; //2πσ^2
            var d = Math.Sqrt(c); //1 over the square root of 2πσ^2

            //normal func
            var fin = (1 / d) * b;
            //Console.WriteLine($"input x:{x}, v:{variance}, mu:{mu}");
            //Console.WriteLine(fin);
            result = fin;
            return result;
        }

        private static double GenerateNormalisedValue(double normal, double genius)
        {
            const double sensitivity = 10000; //higher number == more sensitive
            double result = Between((int)(genius * sensitivity), (int)(normal * sensitivity)) / sensitivity;

            return result;
        }


        private static double CalcAdditional(double gNum, double range)
        {
            double calcPerc = 0;
            double part = range / 4;//4 distributions each side
            if (gNum < great) //genius
            {
                double p = GetPercentOfPointBetweenAandB(gNum, great, genius);
                calcPerc += (0.75 * range) + (p*part);
            }
            else if (gNum < good) //great
            {
                double p = GetPercentOfPointBetweenAandB(gNum, good, great);
                calcPerc += (0.50 * range) + (p * part);
            }
            else if (gNum < normal) //good
            {
                double p = GetPercentOfPointBetweenAandB(gNum, normal, good);
                calcPerc += (0.25 * range) + (p * part);
            }
            else if (gNum <= zero) //normal
            {
                double p = GetPercentOfPointBetweenAandB(gNum, zero, normal);
                calcPerc += (0 * range) + (p * part);
            }
            return calcPerc;
        }

        //TODO: probably a mathshelper thing if I go that far
        public static double GetPercentOfPointBetweenAandB(double point, double upperBound, double lowerBound)
        {
            double p = (upperBound - point) / (upperBound - lowerBound);
            return p;
        }

    }
}
