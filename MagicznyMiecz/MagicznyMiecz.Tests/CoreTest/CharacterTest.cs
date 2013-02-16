using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using Moq;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class CharacterTest
    {
        private const string MyCharacterName = "MyCharacter";
        private const string MyItemName = "MyItem";
        private const int AttributeValue = 3;
        private const int OnePoint = 1;

        private ICharacter _character;

        [SetUp]
        public void SetUp()
        {
            var positionMock = new Mock<IPosition>();
            positionMock.Setup(position => position.ActualCircle).Returns(StandardBoardDefinition.InnerCircle);
            positionMock.Setup(position => position.Id).Returns(StandardBoardDefinition.UroczyskoId);

            this._character = Character.Create(MyCharacterName, positionMock.Object, Nature.Chaotic, AttributeValue, AttributeValue);
        }

        [Test]
        public void CheckCharacterNameAndNature()
        {
            Assert.That(this._character.Name, Is.EqualTo(MyCharacterName));
            Assert.That(this._character.Nature, Is.EqualTo(Nature.Chaotic));
        }

        [Test]
        public void CheckCharacterStartPosition()
        {
            Assert.That(this._character.StartPosition.ActualCircle, Is.EqualTo(StandardBoardDefinition.InnerCircle));
            Assert.That(this._character.StartPosition.Id, Is.EqualTo(StandardBoardDefinition.UroczyskoId));
        }

        [Test]
        public void CheckIfItemsBagIsEmpty()
        {
            Assert.That(this._character.Items, Has.Count.EqualTo(0));
        }

        [Test]
        public void CheckPropertiesAfterCreating()
        {
            Assert.That(this._character.Life, Is.EqualTo(GameConstants.LifeOnStart));
            Assert.That(this._character.Gold, Is.EqualTo(GameConstants.GoldOnStart));
            Assert.That(this._character.Might, Is.EqualTo(AttributeValue));
            Assert.That(this._character.Magic, Is.EqualTo(AttributeValue));
        }

        [Test]
        public void PlayerWithItem()
        {
            const int MagicValue = OnePoint;
            const int MightValue = 2 * OnePoint;

            var itemMock = new Mock<IItem>();
            itemMock.Setup(item => item.Name).Returns(MyItemName);
            itemMock.Setup(item => item.Magic).Returns(MagicValue);
            itemMock.Setup(item => item.Might).Returns(MightValue);

            this._character.Items.Add(itemMock.Object);

            Assert.That(AttributeValue + MightValue, Is.EqualTo(this._character.Might));
            Assert.That(AttributeValue + MagicValue, Is.EqualTo(this._character.Magic));
        }

        [Test]
        public void AddMoreThanWeCanMagicPoints()
        {
            Assert.That(() => ((IEditableCharacter)this._character).AddMagic(GameConstants.MaxAttributePointsToAdd + OnePoint),
                        Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void AddMoreThanWeCanMightPoints()
        {
            Assert.That(() => ((IEditableCharacter)this._character).AddMight(GameConstants.MaxAttributePointsToAdd + OnePoint),
                        Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void AddMagicPoints()
        {
            ((IEditableCharacter)this._character).AddMagic(OnePoint);
            Assert.That(this._character.Magic, Is.EqualTo(AttributeValue + OnePoint));
        }
        
        [Test]
        public void AddMightPoints()
        {
            ((IEditableCharacter)this._character).AddMight(OnePoint);
            Assert.That(this._character.Might, Is.EqualTo(AttributeValue + OnePoint));
        }

        [Test]
        public void RemoveMagicPointsWhenEqualsToDefault()
        {
            ((IEditableCharacter)this._character).RemoveMagic(OnePoint);
            Assert.That(this._character.Magic, Is.EqualTo(AttributeValue));
        }

        [Test]
        public void RemoveMightPointsWhenEqualsToDefault()
        {
            ((IEditableCharacter)this._character).RemoveMight(OnePoint);
            Assert.That(this._character.Might, Is.EqualTo(AttributeValue));
        }

        [Test]
        public void RemoveMagicPoints()
        {
            ((IEditableCharacter)this._character).AddMagic(2 * OnePoint);
            ((IEditableCharacter)this._character).RemoveMagic(OnePoint);
            Assert.That(this._character.Magic, Is.EqualTo(AttributeValue + OnePoint));
        }

        [Test]
        public void RemoveMightPoints()
        {
            ((IEditableCharacter)this._character).AddMight(2 * OnePoint);
            ((IEditableCharacter)this._character).RemoveMight(OnePoint);
            Assert.That(this._character.Might, Is.EqualTo(AttributeValue + OnePoint));
        }

        [Test]
        public void RemoveGoldPointsMoreThanPlayerHas()
        {
            Assert.That(() => ((IEditableCharacter)this._character).RemoveGold(2 * OnePoint),
                        Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void RemoveGold()
        {
            ((IEditableCharacter)this._character).RemoveGold(OnePoint);
            Assert.That(this._character.Gold, Is.EqualTo(GameConstants.GoldOnStart - 1));
        }

        [Test]
        public void AddGold()
        {
            ((IEditableCharacter)this._character).AddGold(OnePoint);
            Assert.That(this._character.Gold, Is.EqualTo(GameConstants.GoldOnStart + 1));
        }

        [Test]
        public void AddMoreThanWeCanLifePoints()
        {
            Assert.That(() => ((IEditableCharacter)this._character).AddLife(GameConstants.MaxAttributePointsToAdd + OnePoint),
                        Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void AddLifePoints()
        {
            ((IEditableCharacter)this._character).AddLife(OnePoint);
            Assert.That(this._character.Life, Is.EqualTo(GameConstants.LifeOnStart + OnePoint));
        }

        [Test]
        public void RemoveAllLifePoints()
        {
            Assert.That(() => ((IEditableCharacter)this._character).RemoveLife(GameConstants.LifeOnStart),
                        Throws.Exception.TypeOf<PlayerHasNoLifePointsException>());
        }

        [Test]
        public void ChangeNature()
        {
            Assert.That(this._character.Nature, Is.EqualTo(Nature.Chaotic));
            ((IEditableCharacter)this._character).ChangeNature(Nature.Bad);
            Assert.That(this._character.Nature, Is.EqualTo(Nature.Bad));
        }
    }
}