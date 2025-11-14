using Government.Objects;
using Government.Objects.Government;
using Government.Objects.SocietyConcepts;
using Government.Objects.SocietyConcepts.Corporations;

namespace Government
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Government";
            Console.WriteLine("It is 1777 ... ");


            Gov gov = new Gov();

            //example
            Shop s = new Shop(gov);
            Job labourer = new Job("Labourer", 13);
            Person p = new Person(gov, "Peter P.");
            Person q = new Person(gov, "Quill N.");
            
            p.Hire(labourer);
            q.Hire(labourer);

            Console.WriteLine(gov.Citizens[0].Name);

            //Seed the population at first with 30 people?
            //1 will own the first company
            //1 person as each minister e.g. health, education, transportation, water, energy

            //gameplay loop here
            while (true)
            {
                p.PaySalary();
                q.PaySalary();

                if(p.Money.Money > 20)
                {
                    s.PurchaseGoods(p, 20);
                }

                Console.WriteLine(p.Money.Money + " " + gov.Money.Money);

                var end = Console.ReadKey()!.Key;
                if (end.Equals(ConsoleKey.E)) {
                    Console.WriteLine("\n...Game Ended.");
                    break; }
            }
            Console.ReadKey();
        }
    }
}
