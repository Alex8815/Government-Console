using Government.Helpers;
using Government.Objects;
using Government.Objects.Government;
using Government.Objects.SocietyConcepts;
using Government.Objects.SocietyConcepts.Corporations;
using Microsoft.VisualBasic;

namespace Government
{
    internal class Program
    {
        private static int year = 1777;
        static void Main(string[] args)
        {
            Console.Title = "Government";
            //TODO: concept to track year
            //Once some stuff is simulating, can set up before 1777, and run until 1777


            Gov gov = new Gov();

            //example
            Shop s = new Shop(gov);
            School school = new School(gov);

            Job labourer = new Job("Labourer", 13);
            Person p = new Person(gov, Namer.GeneratePersonName());
            Person q = new Person(gov, Namer.GeneratePersonName());
            Person child = new Person(gov, Namer.GeneratePersonName());

            school.Enroll(child);

            p.Hire(labourer);
            q.Hire(labourer);

            Console.WriteLine(gov.Citizens[0].Name);

            //Seed the population at first with 30 people?
            //1 will own the first company
            //1 person as each minister e.g. health, education, transportation, water, energy, prison

            //

            //gameplay loop here
            while (true)
            {
                Console.WriteLine($"It is {year} ... ");

                p.PaySalary();
                q.PaySalary();

                if(p.Money.Money > 20)
                {
                    s.PurchaseGoods(p, 20);
                }


                //gov actions
                gov.FundPublicSchools();
                gov.AllSchools_Do();
                gov.AllCitizens_Do();
                year++;//maybe create a World object to hold this
               // Console.WriteLine(p.Money.Money + " " + gov.Money.Money);

                var end = Console.ReadKey()!.Key;
                if (end.Equals(ConsoleKey.E)) {
                    Console.WriteLine("\n...Game Ended.");
                    break; }
                Console.Clear();
            }
            Console.ReadKey();
        }
    }
}
