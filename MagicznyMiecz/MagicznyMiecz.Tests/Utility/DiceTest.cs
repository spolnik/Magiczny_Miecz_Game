using System.Collections.Generic;
using MagicznyMiecz.Common.Utility;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.Utility
{
    [TestFixture]
    public class DiceTest
    {
        private const int Count = 100;

        [Test]
        public void TestSimpleRandomDices()
        {
            int firstDice = Dice.Throw();
            int counter = 0;

            for (int i = 0; i < Count; i++)
            {
                int dice = Dice.Throw();
                if (dice == firstDice)
                    counter++;
            }

            Assert.That(counter, Is.LessThan(Count));
        }

        [Test]
        public void TestDicesRange()
        {
            for (int i = 0; i < Count; i++)
            {
                int dice = Dice.Throw();
                Assert.That(dice, Is.LessThanOrEqualTo(GameConstants.CubeSize));
                Assert.That(dice, Is.GreaterThan(0));
            }
        }

        [Test] 
        public void TestAdvacedRandomDices()
        {
            var results = new Dictionary<int, int>();
            const int AdvancedCount = Count * 10;

            for (int i = 0; i < AdvancedCount; i++)
            {
                int dice = Dice.Throw();

                if (results.ContainsKey(dice))
                    results[dice]++;
                else
                    results.Add(dice, 1);
            }

            foreach (var key in results.Keys)
            {
                Assert.That(results[key], Is.AtLeast(AdvancedCount/20));
                Assert.That(results[key], Is.AtMost(AdvancedCount/4));
            }
        }
    }
}