using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Utility;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.Utility
{
    [TestFixture]
    public class BagTest
    {
        private const int FirstBagItem = 1;
        private const int SecondBagItem = 2;
        private const int ThirdBagItem = 3;
        private const int OtherBagItem = 4;

        private const int BagCountOnStart = 3;

        private const int IndexOfFirstBagItem = 0;
        private const int IndexOfSecondBagItem = 1;
        private const int IndexOfThirdBagItem = 2;

        private IBag<int> _bag;

        [SetUp]
        public void SetUp()
        {
            this._bag = Bag<int>.Create();
            this._bag.Add(FirstBagItem);
            this._bag.Add(SecondBagItem);
            this._bag.Add(ThirdBagItem);
        }

        [Test]
        public void TestBagAfterStart()
        {
            Assert.That(this._bag, Has.Count.EqualTo(BagCountOnStart));
            Assert.That(this._bag[IndexOfFirstBagItem], Is.EqualTo(FirstBagItem));
            Assert.That(this._bag[IndexOfSecondBagItem], Is.EqualTo(SecondBagItem));
            Assert.That(this._bag[IndexOfThirdBagItem], Is.EqualTo(ThirdBagItem));
        }

        [Test]
        public void TestAddItem()
        {
            this._bag.Add(OtherBagItem);
            Assert.That(this._bag, Has.Count.EqualTo(BagCountOnStart + 1));
        }

        [Test]
        public void TestRemoveItem()
        {
            this._bag.Remove(FirstBagItem);
            Assert.That(this._bag, Has.Count.EqualTo(BagCountOnStart - 1));
        }
    }
}