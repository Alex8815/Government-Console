using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentMain.Objects.EconomicConcepts
{
    /// <summary>
    /// use this to determine how to sort and manage money coming in
    /// </summary>
    public enum FundsType
    {
        Income,
        CapitalGains,
        Loan,
        Gift,
        Funding //e.g. distribution between internal authorities
    }

    public class Wallet //wallet is the instantly accessible money
    {
        public long LifetimeIncome { get; private set; } = 0;

        public long AnnualIncome { get; private set; } = 0;

        public long AnnualExpenses { get; private set; } = 0;

        public long Money { get; private set; } = 0;

        public Wallet(long initialCash) {
            Money = initialCash;
        }

        public void AddFunds(long moreMoney, FundsType type = FundsType.Income)
        {
            Money += moreMoney;

            if (type.Equals(FundsType.Income))
            {
                AnnualIncome += moreMoney;
            }

            LifetimeIncome += moreMoney;
        }

        public void AnnualCycle()
        {
            //reset trackings for things
            AnnualIncome = 0;
            AnnualExpenses = 0;
        }

        public void RemoveFunds(long lessMoney)
        {
            Money -= lessMoney;
            AnnualExpenses += lessMoney; 
        }

        public bool AttemptRemoveFunds(long lessMoney)
        {
            bool result = false;
            if (Money > lessMoney)
            {
                RemoveFunds(lessMoney);
                result = true;
            }    
            return result;
        }
    }
}
