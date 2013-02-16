using System;
using System.Linq;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Data;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class CardRepositoryInitializerTest
    {
        private ICardRepository _repository;
        private IRepositoryInitializer<ICard> _initializer;

        [SetUp]
        public void SetUp()
        {
            this._repository = new CardRepository();
            this._initializer = new SimpleCardsRepositoryInitialzier();
            this._initializer.Init((IEditableRepository<ICard>)this._repository);
        }

        [Test]
        public void CheckCardsInitialization()
        {
            for (var i = 0; i < this._repository.Count; i++)
            {
                var item = this._repository.NextCard();
                Assert.That(string.IsNullOrEmpty(item.Name), Is.False);
                Assert.That(string.IsNullOrEmpty(item.Description), Is.False);
            }
        }

        [Test]
        public void CheckIfGoldCardsIsMoreThanTwo()
        {
            Assert.That(this._repository.Where(card => card.Name.Contains("Z³ota")).Count(), Is.GreaterThan(2));
        }

        [Test]
        public void CheckIfInitializedCardsRepositoryIsRandom()
        {
            ICardRepository repositoryOne = new CardRepository();
            this._initializer.Init((IEditableRepository<ICard>)repositoryOne);

            ICardRepository repositoryTwo = new CardRepository();
            this._initializer.Init((IEditableRepository<ICard>)repositoryTwo);

            Assert.That(repositoryOne, Has.Count.EqualTo(repositoryTwo.Count));

            bool areDifferent = false;
            for (int i = 0; i < repositoryOne.Count; i++)
            {
                var cardOne = repositoryOne.NextCard();
                var cardTwo = repositoryTwo.NextCard();

                if (string.Equals(cardOne.Name, cardTwo.Name))
                    continue;

                areDifferent = true;
                break;
            }

            Assert.That(areDifferent, Is.True);
        }

        [Test]
        public void ThrowErrorIfInitWithNoItems()
        {
            var repository = new CardRepository();
            Assert.That(() => ((IEditableRepository<ICard>)repository).Init(), Throws.Exception.TypeOf<ApplicationException>());
        }
    }
}