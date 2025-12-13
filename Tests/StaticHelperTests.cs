using GovernmentMain.Helpers;

namespace Tests
{
    public class StaticHelperTests
    {
        [SetUp]
        public void Setup()
        {
            //statics, who cares
        }

        [Test]
        public void NameGenerator()
        {
            string someName = Namer.GeneratePersonName();

            string[] components = someName.Split(' ');

            Assert.True(someName.Contains(" ") && components.Length > 1);
            Console.WriteLine(someName);
        }

        [Test]
        public void RNG_OutOf()
        {
            bool success = RNG.OutOf(100);
            Assert.True(success);
        }

        [Test]
        public void RNG_ApplyVariance()
        {
            int total = 1000;
            int g = 0;
            int over = 0;
            int under = 0;
            int equal = 0;
            for (int i = 0; i < total; i++)
            {
                double t = RNG.ApplyNormallyDistributedVariance(100);
                if (t > 119) { Console.WriteLine(t); g++; };
                if (t > 100) over++;
                if (t < 100) under++;
                if (t==100) equal++;
            }

            Console.WriteLine($"geniuses: {g}/{total}");
            Console.WriteLine($"o{over} u{under}, e{equal}");
        }


        [TestCase(45,100,45)]
        [TestCase(45, 50, 22)]
        [TestCase(33,15,4)]
        public void Maths_GrabMoneyPercent(double percent, long total, long expected)
        {
            var res = Maths.GrabMoneyPercent(percent, total);
            Console.WriteLine(res);
            Assert.IsTrue(res == expected);
        }

        [Test]
        public void Maths_GetPercentOfPointBetweenAandB()
        {
            double v = Maths.GetPercentOfPointBetweenAandB(0.1, 1, 0.01);
            Console.WriteLine($"{v}%");
        }

        private static double GenerateNormalisedValue(double normal, double genius)
        {
            const double offset = 10000;
            double result = RNG.Between((int)(genius * offset), (int)(normal * offset)) / offset;

            return result;
        }

    }
}