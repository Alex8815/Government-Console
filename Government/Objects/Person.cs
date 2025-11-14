using Government.Objects.EconomicConcepts;
using Government.Objects.Government;
using Government.Objects.SocietyConcepts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Objects
{
    public class Person
    {
        //overlord
        private Gov _gov;

        //identifiers
        //public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; } //nobody is living to 2 billion
        //perhaps we set a LifeExpectancy, which can be +/- with various interactions?

        //life
        public Job Job { get; private set; } 

        //assets
        public Wallet Money { get; private set; }

        public List<Object> Assets { get; private set; }
        //
        

        public Person(Gov gov, string name) {
            _gov = gov;

            Name = name;
            Age = 0;
            Money = new Wallet(0);

            gov.RegisterCitizen(this);
        }


     //career
        //eventually this will be through the organisation that performes the hire?
        public void Hire(Job job)
        {
            Job = job;
        }

        //this would maybe take in a corporation, who owns the job to reduce their funds?
        public void PaySalary()
        {
            if (Job != null)
            {
                long income = Job.Salary;
                long taxToPay = _gov.IncomeTax.CalculateTaxToPay(income);
                long afterTax = income - taxToPay;
                Money.AddFunds(afterTax);
                _gov.PayIncomeTax(this, taxToPay);
            }
        } 

    }
}
