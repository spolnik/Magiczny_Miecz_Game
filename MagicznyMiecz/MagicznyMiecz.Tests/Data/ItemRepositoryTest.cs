using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Data;
using MagicznyMiecz.Engine.Utility;
using Moq;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class ItemRepositoryTest
    {
        private const string MyItemName = "MyItem";
        private const string MyPlayerName = "MyPlayer";
        private const string MyCharacterName = "MyCharacter";

        private IRepository _repository;

        [SetUp]
        public void SetUp()
        {
            this._repository = new ItemRepository();
        }

        [Test]
        public void CheckEditableRepositoryWithTwoTheSameItems()
        {
            var itemMock = new Mock<IItem>();
            itemMock.Setup(item => item.Name).Returns(MyItemName);

            var editableRepository = (IEditableRepository<IItem>)this._repository;
            editableRepository.Add(itemMock.Object);
            editableRepository.Init();

            var itemsRepositoryForDisplay = (IDisplayElement<IItem>)this._repository;

            Assert.That(() => editableRepository.Add(itemsRepositoryForDisplay[this._repository.Names[0]]),
                        Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void AttachDetachItemToPlayer()
        {
            var itemMock = new Mock<IItem>();
            itemMock.Setup(item => item.Name).Returns(MyItemName);

            var characterMock = new Mock<ICharacter>();
            characterMock.Setup(character => character.Name).Returns(MyCharacterName);
            characterMock.Setup(character => character.Items).Returns(Bag<IItem>.Create());

            var playerMock = new Mock<IPlayer>();
            playerMock.Setup(player => player.Name).Returns(MyPlayerName);
            playerMock.Setup(player => player.Character).Returns(characterMock.Object);

            var editableRepository = (IEditableRepository<IItem>)this._repository;
            editableRepository.Add(itemMock.Object);
            editableRepository.Init();

            this._repository.Assign(playerMock.Object, MyItemName);
            Assert.That(playerMock.Object.Character.Items, Has.Count.EqualTo(1));

            this._repository.Detach(playerMock.Object, MyItemName);
            Assert.That(playerMock.Object.Character.Items, Has.Count.EqualTo(0));
        }

        [Test]
        public void DetachNotExistedItemFromCharacter()
        {
            var characterMock = new Mock<ICharacter>();
            characterMock.Setup(character => character.Name).Returns(MyCharacterName);
            characterMock.Setup(character => character.Items).Returns(Bag<IItem>.Create());

            var playerMock = new Mock<IPlayer>();
            playerMock.Setup(player => player.Name).Returns(MyPlayerName);
            playerMock.Setup(player => player.Character).Returns(characterMock.Object);

            Assert.That(() => this._repository.Detach(playerMock.Object, "NotExistedItem"), Throws.Exception.TypeOf<ApplicationException>());
        }
    }
}
