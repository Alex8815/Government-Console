using Government.Objects.EconomicConcepts;
using Government.Objects.Government.Laws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Objects.Government
{
    //remember the government has its hands in everything
    public class Gov
    {
        public Wallet Money { get; private set; }
        public List<Person> Citizens { get; private set; } = new List<Person>();

        //tax
        public IncomeTax IncomeTax { get; private set; }
        public TransactionTax TransactionTax { get; private set; }

        public Gov() {

            Money = new Wallet(0);

            IncomeTax = new IncomeTax(new KeyValuePair<long, double>(5,20));
            IncomeTax.AddTaxBracket(new KeyValuePair<long, double>(10, 30));

            TransactionTax = new TransactionTax(10);
        }

        public void RegisterCitizen(Person citizen)
        {
            Citizens.Add(citizen);
        }

        public void PayIncomeTax(Person citizen, long taxMoney)
        {
            Money.AddFunds(taxMoney);
            //Console.WriteLine($"IncomeTax: {citizen.Name} has paid ${taxMoney} this year");
        }
        public void PayTransactionTax(long taxMoney)
        {
            Money.AddFunds(taxMoney);
        }
    }
}
