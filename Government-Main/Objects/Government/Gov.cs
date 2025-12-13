using GovernmentMain.Objects.EconomicConcepts;
using GovernmentMain.Objects.Government.Departments;
using GovernmentMain.Objects.Government.Laws;
using GovernmentMain.Objects.SocietyConcepts.Corporations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentMain.Objects.Government
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

        //departments
        public DepartmentOfEducation Education { get; private set; }
     

        public Gov() {

            Money = new Wallet(10); //start the government off with $10, to fund things

            //build departments
            Education = new DepartmentOfEducation(this, 0);

            IncomeTax = new IncomeTax(5,20);
            IncomeTax.AddTaxBracket(15, 50);
            IncomeTax.AddTaxBracket(25, 100);

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
        //shops and schools should become implementations of Organisations or something?
        public void PayTransactionTax(Shop s, long taxMoney)
        {
            Money.AddFunds(taxMoney);
            Console.WriteLine($"{s.Name} paid ${taxMoney} in sales tax");
        }
        public void PayTransactionTax(School s, long taxMoney)
        {
            Money.AddFunds(taxMoney);
            Console.WriteLine($"{s.Name} paid ${taxMoney} in sales tax");
        }

        //Education
        public void RegisterPublicSchool(School school)
        {
            Education.RegisterPublicSchool(school);
        }
        public void DeregisterPublicSchool(School school)
        {
            Education.DeregisterPublicSchool(school);
        }
        public void DestroySchool(School school)
        {
            Education.DestroySchool(school);
        }

        public void FundDepartmentOfEducation()
        {
            //need to call a fund DoE first

            long configuredEducationBudget = 4;
            if (Money.AttemptRemoveFunds(configuredEducationBudget))
            {
                Education.Fund(configuredEducationBudget);
            }
        }


        //actions

        public void GovernmentAnnualTasks()
        {
            //Fund Departments:
            FundDepartmentOfEducation();


            //perform tasks
            Education.DepartmentOfEducation_Do();


            //citizens go last to take advantage of changes this year, e.g. tax changes, policy changes
            AllCitizens_Do();

            //end of year stats
            long govIncome = Money.AnnualIncome;
            long govExpenses = Money.AnnualExpenses;
            Money.AnnualCycle();

            Console.WriteLine($"Total: {Money.Money}, Annual:{govIncome}, Expenses:{govExpenses}");
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
