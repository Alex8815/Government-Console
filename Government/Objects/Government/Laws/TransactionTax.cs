using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Objects.Government.Laws
{
    //this is a tax to be applied on things like a Purchase method, which moves a product into ownership of a Person or Business at a cost of Money.
    public class TransactionTax
    {
        public double TaxRate { get; private set; }

        public TransactionTax(double rate) {
            TaxRate = rate;
        }

        public long CalculateTax(long totalCost)
        {
            double taxRate = TaxRate;
            long toGov = (long)((double)totalCost / 100 * taxRate);
            return toGov;
        }
    }
}
