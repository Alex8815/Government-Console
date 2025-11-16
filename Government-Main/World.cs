using GovernmentMain.Helpers;
using GovernmentMain.Objects.Government;
using GovernmentMain.Objects.SocietyConcepts.Corporations;
using GovernmentMain.Objects.SocietyConcepts;
using GovernmentMain.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentMain
{
    public class World
    {
        public int Year { get; private set; }

        public World(int startYear)
        {
            Year = startYear;
        }

        public void Run()
        {
            Console.Title = "Government";
            //TODO: concept to track year
            //Once some stuff is simulating, can set up before 1777, and run until 1777


            Gov gov = new Gov();

            //example
            Shop s = new Shop(gov);
            School school = new School(gov);

            Job labourer = new Job("Labourer", 13);
            Job bartender = new Job("Bartender", 11);
            Person p = new Person(gov, Namer.GeneratePersonName());
            Person q = new Person(gov, Namer.GeneratePersonName());
            Person child = new Person(gov, Namer.GeneratePersonName());

            school.Enroll(child);

            p.Hire(labourer);
            p.Hire(bartender);
            q.Hire(labourer);

            Console.WriteLine(gov.Citizens[0].Name);

            //Seed the population at first with 30 people?
            //1 will own the first company
            //1 person as each minister e.g. health, education, transportation, water, energy, prison

            //

            //gameplay loop here
            while (true)
            {
                Console.WriteLine($"It is {Year} ... ");

                p.CollectSalary();
                q.CollectSalary();

                if (p.Money.Money > 20)
                {
                    s.PurchaseGoods(p, 20);
                }


                //gov actions
                //collect taxes first, by letting the citizens live
                gov.AllCitizens_Do();

                //distribute money
                gov.FundPublicSchools();

                //perform government tasks
                gov.AllSchools_Do();
                
                long govIncome = gov.Money.AnnualIncome;
                long govExpenses = gov.Money.AnnualExpenses;
                gov.Money.AnnualCycle();
                Year++;//maybe create a World object to hold this
                Console.WriteLine($"Total: {gov.Money.Money}, Annual:{govIncome}, Expenses:{govExpenses}");
                Console.WriteLine(school.Funds.Money);
                var end = Console.ReadKey()!.Key;
                if (end.Equals(ConsoleKey.E))
                {
                    
                    break;
                }
               // Console.Clear();
            }
            //end
        }
    }
}
