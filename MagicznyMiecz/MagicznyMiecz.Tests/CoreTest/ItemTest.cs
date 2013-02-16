using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Engine.Core;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class ItemTest
    {
        private const int DefaultValue = 3;
        private IItem _item;

        [SetUp]
        public void SetUp()
        {
            this._item = Item.New("Miecz");
        }

        [Test]
        public void CheckAfterInit()
        {
            Assert.That(this._item.Might, Is.EqualTo(0));
            Assert.That(this._item.Magic, Is.EqualTo(0));
            Assert.That(this._item.Defense, Is.EqualTo(0));
        }

        [Test]
        public void CheckMight()
        {
            this._item = this._item.SetMight(DefaultValue);
            Assert.That(this._item.Might, Is.EqualTo(DefaultValue));
        }

        [Test]
        public void CheckMagic()
        {
            this._item = this._item.SetMagic(DefaultValue);
            Assert.That(this._item.Magic, Is.EqualTo(DefaultValue));
        }

        [Test]
        public void CheckDefense()
        {
            this._item = this._item.SetDefense(DefaultValue);
            Assert.That(this._item.Defense, Is.EqualTo(DefaultValue));
        }
    }
}