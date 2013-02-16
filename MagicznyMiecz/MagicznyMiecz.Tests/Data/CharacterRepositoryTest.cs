using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Data;
using Moq;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class CharacterRepositoryTest
    {
        private const string PlayerName = "MyPlayer";
        private IRepository _repository;
        private IPlayer _player;
        private Mock<ICharacter> _characterMock;

        [SetUp]
        public void SetUp()
        {
            this._repository = new CharacterRepository();

            var game = GameFactory.Create();
            this._player = game.Register(PlayerName);

            this._characterMock = new Mock<ICharacter>();
            this._characterMock.Setup(character => character.Name).Returns(PlayerName);
        }

        [Test]
        public void CheckEditableRepositoryWithTwoTheSameCharacters()
        {
            var editableRepository = (IEditableRepository<ICharacter>)this._repository;
            editableRepository.Add(this._characterMock.Object);
            editableRepository.Init();

            var charactersRepositoryForDisplay = (IDisplayElement<ICharacter>)this._repository;

            Assert.That(() => editableRepository.Add(charactersRepositoryForDisplay[this._repository.Names[0]]),
                        Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void AttachDetachCharacterToPlayer()
        {
            ((IEditableRepository<ICharacter>)this._repository).Add(this._characterMock.Object);
            ((IEditableRepository<ICharacter>)this._repository).Init();

            var player = this._repository.Assign(this._player, PlayerName);
            Assert.That(player.Character.Name, Is.EqualTo(PlayerName));

            var playerWithoutCharacter = this._repository.Detach(player, player.Character.Name);
            Assert.That(playerWithoutCharacter.Character, Is.Null);
        }

        [Test]
        public void CheckErrorIfDetachNotExistingCharacter()
        {
            ((IEditableRepository<ICharacter>)this._repository).Add(this._characterMock.Object);
            ((IEditableRepository<ICharacter>)this._repository).Init();

            var player = this._repository.Assign(this._player, PlayerName);

            Assert.That(() => this._repository.Detach(player, "NotExistedName"),
                        Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void CheckIfRepositoryCountIfAttachDetachCharacter()
        {
            const int RepositoryCountOnStart = 0;

            ((IEditableRepository<ICharacter>)this._repository).Add(this._characterMock.Object);
            ((IEditableRepository<ICharacter>)this._repository).Init();

            Assert.That(this._repository, Has.Count.EqualTo(RepositoryCountOnStart + 1));

            this._repository.Assign(this._player, PlayerName);

            Assert.That(this._repository, Has.Count.EqualTo(RepositoryCountOnStart));
        }
    }
}
