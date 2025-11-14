using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Government.Objects.Government.Laws
{
    /// <summary>
    /// for describing the Marginal tax brackets for salary income.
    /// to make a flat tax you just set the bracket to 0
    /// </summary>
    public class IncomeTax
    {
        // there actually can be configured multiple different brackets, so should be a collection to check
        public OrderedDictionary IncomeBrackets { get; private set; }

        public IncomeTax(KeyValuePair<long, double> initialBracket) {
            IncomeBrackets = new OrderedDictionary();
            IncomeBrackets.Add(initialBracket.Key, initialBracket.Value);
        }

        
        public void AddTaxBracket(KeyValuePair<long, double> newBracket)
        {
            IncomeBrackets.Add(newBracket.Key, newBracket.Value);
        }
        public void RemoveTaxBracket(long key)
        {
            IncomeBrackets.Remove(key);
        }

        //salary of 13
        // 5, 20%
        // 10, 30%
        public long CalculateTaxToPay(long salary)
        {
            long result = 0;

            long hold = salary; //we want to take everything from over the bracket from the hold, then do maths on it

            //get the data from the income tax boundaries and percents
            var bracketsT = new long[IncomeBrackets.Keys.Count];
            IncomeBrackets.Keys.CopyTo(bracketsT, 0);
            List<long> brackets = bracketsT.Reverse().ToList();


            var percentsT = new double[IncomeBrackets.Values.Count];
            IncomeBrackets.Values.CopyTo(percentsT, 0);
            List<double> percents = percentsT.Reverse().ToList();                        

            for(int i = 0; i < brackets.Count; i++)
            {
                long bracket = brackets[i]; //10, then 5
                double percent = percents[i]; // 30%, then 20%

                long amountToTax = hold - bracket; //find the difference over the bracket
                if (amountToTax > 0)
                {
                    hold = bracket; //set the hold now to the bracket, it's the upper bound
                    long toPayInThisBracket = (long)(((double)amountToTax / 100) * percent);
                    result += toPayInThisBracket;
                }

            }

            return result;
        }
    }
}
