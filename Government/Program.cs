using GovernmentMain;
using GovernmentMain.Helpers;
using GovernmentMain.Objects;
using GovernmentMain.Objects.Government;
using GovernmentMain.Objects.SocietyConcepts;
using GovernmentMain.Objects.SocietyConcepts.Corporations;
using Microsoft.VisualBasic;

namespace Government
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            const int startYear = 1777;
            World world = new World(startYear);

            world.Run();

            Console.WriteLine("\n...Game Ended.");
            Console.ReadKey();
        }
    }
}
