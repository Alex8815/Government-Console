using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Objects.EconomicConcepts
{
    public class Wallet
    {
        public long LifetimeIncome { get; private set; }

        public long Money { get; private set; }

        public Wallet(long initialCash) {
            Money = initialCash;
        }

        public void AddFunds(long moreMoney)
        {
            Money += moreMoney;
            LifetimeIncome += moreMoney;
        }

        public void RemoveFunds(long lessMoney)
        {
            Money -= lessMoney;
        }
    }
}
