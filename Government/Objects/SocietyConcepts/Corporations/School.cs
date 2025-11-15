using Government.Helpers;
using Government.Objects.EconomicConcepts;
using Government.Objects.Government;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Objects.SocietyConcepts.Corporations
{
    public class School
    {
        private Gov _gov;
        public Wallet Funds { get; private set; }

        //
        public string Name { get; private set; }
        public bool isPublic { get; private set; }

        //function
        public List<Person> Students { get; private set; } = new List<Person>();

        //roles
        public Person Teacher;
        public Person Administrator;

        //This should be configurable somehow
        private Job _teacher = new Job("Teacher", 10);
        private Job _administrator = new Job("Administrator", 35);

        public School(Gov gov) {
            _gov = gov;
            Funds = new Wallet(0);

            Name = Namer.GeneratePersonName() + "'s academy";

            _gov.RegisterPublicSchool(this);
        }

        //governmental
        public void Privatise(bool isPrivate)
        {
            isPublic = !isPrivate;
            _gov.DeregisterPublicSchool(this);
        }

        //economics
        public void Fund(long newFunds)
        {
            Funds.AddFunds(newFunds);
        }

        //function
        public void Educate()
        {
            foreach (Person person in Students)
            {
                //cost to educate per person
                long costs = 4;
                //ask government how much to spend
                if (Funds.AttemptRemoveFunds(costs))
                {
                    long toGov = _gov.TransactionTax.CalculateTax(costs);
                    _gov.PayTransactionTax(toGov);

                    person.Educate();
                }
                else
                {
                    Console.WriteLine($"unable to educate {person.Name}");
                }
            }
        }
        public void Enroll(Person person)
        {
            Students.Add(person);
            person.Enroll(this);
        }
        public void Disenroll(Person person)
        {
            Students.Remove(person);
            
            person.Disenroll(this);
        }
    }
}
