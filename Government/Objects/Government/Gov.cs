using Government.Objects.EconomicConcepts;
using Government.Objects.Government.Laws;
using Government.Objects.SocietyConcepts.Corporations;
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
        
        //utils

        //Education
        public List<School> PublicSchools { get; private set; } = new List<School>();
        public List<School> AllSchools { get; private set; } = new List<School>();

        public Gov() {

            Money = new Wallet(0);

            IncomeTax = new IncomeTax(new KeyValuePair<long, double>(5,20));
            IncomeTax.AddTaxBracket(new KeyValuePair<long, double>(10, 30));

            TransactionTax = new TransactionTax(10);
        }

        public void RegisterCitizen(Person citizen)
        {
            Citizens.Add(citizen);
            Console.WriteLine($"{citizen.Name} has been born");
        }

        //tax
        public void PayIncomeTax(Person citizen, long taxMoney)
        {
            Money.AddFunds(taxMoney);
            //Console.WriteLine($"IncomeTax: {citizen.Name} has paid ${taxMoney} this year");
        }
        public void PayTransactionTax(long taxMoney)
        {
            Money.AddFunds(taxMoney);
        }

    //Education
        public void RegisterPublicSchool(School school)
        {
            AllSchools.Add(school);
            PublicSchools.Add(school);
        }
        public void DeregisterPublicSchool(School school)
        {
            PublicSchools.Remove(school);
        }
        public void DestroySchool(School school)
        {
            AllSchools.Remove(school);
            if (PublicSchools.Contains(school))
            {
                PublicSchools.Remove(school);
            }
        }

        public void FundPublicSchools()
        {
            if (PublicSchools.Count == 0) return;
            long fundsForSchools = 4;
            long fundsPer = (long)(fundsForSchools / PublicSchools.Count);
            foreach (School school in PublicSchools)
            {
                if (Money.AttemptRemoveFunds(fundsForSchools))
                {
                    school.Fund(fundsPer);
                }
            }
        }

        public void AllSchools_Do()
        {
            foreach(School school in AllSchools)
            {
                school.Educate();
            }
        }
        public void AllCitizens_Do()
        {
            foreach(Person person in Citizens)
            {
                person.Person_Do();
            }
        }
    }
}
