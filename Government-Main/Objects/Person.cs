using GovernmentMain.Helpers;
using GovernmentMain.Objects.EconomicConcepts;
using GovernmentMain.Objects.Government;
using GovernmentMain.Objects.SocietyConcepts;
using GovernmentMain.Objects.SocietyConcepts.Corporations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentMain.Objects
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

        //stats
        public double Education { get; private set; } = 0;

        //life
        public School School { get; private set; }
        public List<Job> Job { get; private set; } = new List<Job>();

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
            Job.Add(job);
        }

        //this would maybe take in a corporation, who owns the job to reduce their funds?
        public void CollectSalary()
        {
            foreach (Job job in Job)
            {
                long income = job.Salary;
               
                Money.AddFunds(income);
            }
        }
    //Economics
        public void PayTaxes()
        {
            //by having the person responsible for their taxes, we can allow for person objects to falsify or dodge taxes
            //we can also allow for the Gov obj to spend some resources collecting tax, or checking proper taxes are paid
            //for now, everyone is law-abiding, so just calc & pay
            long taxToPay = _gov.IncomeTax.CalculateTaxToPay(Money.AnnualIncome);
            Money.RemoveFunds(taxToPay);
            _gov.PayIncomeTax(this, taxToPay);
            Console.WriteLine($"{Name} has paid ${taxToPay} this year");
        }
    //Education
        public void Enroll(School school)
        {
            School = school;
            Console.WriteLine($"{Name} enrolled in {School.Name}");
        }

        public void Disenroll(School school)
        {
            if(School == school)
            {
                Console.WriteLine($"{Name} finished {School.Name} with Education: {Education}");
                School = null;
            }
        }


    //stats
        public void Educate()
        {
            Education += 1;
            Console.WriteLine($"{Name}'s education has risen to {Education}");
        }

    //do
        public void Person_Do() //Annual cycle
        {
            //age up
            Age += 1;

            //have they finished school?
            if (Age > 16 && School != null && Education > 6) //would be from legal age from gov?
            {
                if (RNG.OutOf(40 + Age, 100))
                {
                    School.Disenroll(this);
                    Console.WriteLine($"{Name} has decided to finish school at {Age}");
                }
            }

            //end of year
            PayTaxes();
            Money.AnnualCycle();
        }

        
    }
}
