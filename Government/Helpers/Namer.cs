using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Government.Helpers
{
    public static class Namer
    {
        private static string[] _firstnames_1 = ["adam", "alex", "andy", "andrew", "ben", "chris", "charles", "charlie", "dom", "dominic", "daniel", "eric", "frankie", "geoffrey", "hal", "harry", "ian", "isaac", "joey", "james", "jack", "kieran", "liam", "matthew", "nathan", "oliver", "peter", "quill", "ryan", "sam", "shaun", "terry", "taric", "uther", "vladimir", "warwick", "xavier", "yusuf", "zane"];
        private static string[] _firstnames_2 = ["amy", "bianca", "charlotte", "danielle", "emma", "francis", "gemma", "haley", "isabelle", "jessica", "jessie", "kimiko", "karen", "laura", "lauren", "mary", "megan", "nami", "nicole", "orianna", "poppy", "paige", "rose", "sara", "tammy", "ursula", "vanessa", "violet", "wiktoria", "xandra", "yvonne", "zara"];
        private static string[] _lastnames = ["atlantic", "baseball", "milk", "football", "north", "fleet", "hill", "eyes", "champs", "dance", "throw", "mulligan", "mac", "fighters", "friends", "royale", "garden", "park", "undead", "talent", "sabbath", "maiden", "zeppelin", "crimson", "deep", "absence", "manor", "truly", "omens", "day", "boat", "length", "school", "theory", "angel", "luck", "parade", "halen", "jovi", "sevenfold", "charlotte", "cooper", "roach", "doctors", "zombie", "crue", "pool", "plan", "kill"];
    
        public static string GeneratePersonName()
        {
            int g = RNG.Either(1,2);
            string[] forenames = (g < 2) ? _firstnames_1 : _firstnames_2;

            int f = RNG.UpTo(forenames.Length-1);
            string first = forenames[f];

            int s = RNG.UpTo(_lastnames.Length-1);
            string last = _lastnames[s];

            string result = $"{first} {last}";
            return result;
        }
    }
}
