using Government.Objects.EconomicConcepts;
using Government.Objects.Government;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Objects.SocietyConcepts.Corporations
{
    public class Shop
    {
        //overload
        private Gov _gov;

        public Wallet Revenue { get; private set; }
        

        public Shop(Gov gov) { 
            _gov = gov;

            Revenue = new Wallet(0);
        }

        //price of goods is value+transactiontax

        //example of transaction, wouldn't likely be just p and cost
        public Object PurchaseGoods(Person p, long totalCost)
        {
            //purchasing needs to reduce the money of the purchaser, send money to shop Register and 

            //take off the tax immediately, send to gov
            double taxRate = _gov.TransactionTax.TaxRate;
            long toGov = (long)((double)totalCost / 100 * taxRate);


            p.Money.RemoveFunds(totalCost);
            _gov.PayTransactionTax(toGov);
            
            Revenue.AddFunds(totalCost - toGov);
            

            return "item";
        }
    }
}
