using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using Moq;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class CardTest
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            var position = new Mock<IPosition>();

            ICharacter character = Character.Create(MyCharacterName, position.Object, Nature.Chaotic, 3, 3);

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetGoodCharacter());
        }

        #endregion

        private const string MyCharacterName = "MyCharacter";

        private IPlayer _player;
        private IGame _game;

        private ICard GetCardOfType(CardType cardType)
        {
            ICard card;
            do
            {
                card = this._game.CardRepository.NextCard();
            } while (card.CardType != cardType);

            return card;
        }

        [Test]
        public void TestCardWithAddingNewItem()
        {
            var itemCard = this.GetCardOfType(CardType.Item);
            
            var result = itemCard.Eval(this._player);

            Assert.That(result, Is.Null);

            Assert.That(this._player.Character.Items, Has.Count.EqualTo(1));
        }

        [Test]
        public void TestCardWithGold()
        {
            var goldCard = this.GetCardOfType(CardType.Gold);

            var result = goldCard.Eval(this._player);

            Assert.That(result, Is.Null);

            Assert.That(this._player.Character.Gold, Is.GreaterThan(GameConstants.GoldOnStart));
        }

        [Test]
        public void TestCardWithCreature()
        {
            var creatureCard = this.GetCardOfType(CardType.Creature);

            var result = creatureCard.Eval(this._player);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.CreatureDice, Is.GreaterThanOrEqualTo(1).And.LessThanOrEqualTo(6));
            Assert.That(result.PlayerDice, Is.GreaterThanOrEqualTo(1).And.LessThanOrEqualTo(6));

            if (!result.Success)
                Assert.That(this._player.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));
        }
    }
}
