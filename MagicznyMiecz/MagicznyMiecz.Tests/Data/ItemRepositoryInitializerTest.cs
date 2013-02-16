using System.Linq;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Data;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class ItemRepositoryInitializerTest
    {
        private IRepository _repository;
        private IRepositoryInitializer<IItem> _initializer;

        [SetUp]
        public void SetUp()
        {
            this._repository = new ItemRepository();
            this._initializer = new SimpleItemsRepositoryInitializer();
            this._initializer.Init((IEditableRepository<IItem>)this._repository);
        }

        [Test]
        public void CheckItemsInitialization()
        {
            var itemsRepositoryForDisplay = (IDisplayElement<IItem>)this._repository;

            foreach (var item in
                this._repository.Names.Select(itemName => itemsRepositoryForDisplay[itemName]))
            {
                Assert.That(string.IsNullOrEmpty(item.Name), Is.False);
                Assert.That(item.Might, Is.AtLeast(0));
                Assert.That(item.Magic, Is.AtLeast(0));
                Assert.That(item.Defense, Is.AtLeast(0));
            }
        }
    }
}