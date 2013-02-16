using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using Moq;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class StandardPlayerTest
    {
        private const string MyPlayerName = "Me";
        private const string MyCharacterName = "MyCharacter";
        private const int PlayerId = 1;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            var positionMock = new Mock<IPosition>();
            positionMock.Setup(position => position.ActualCircle).Returns(StandardBoardDefinition.InnerCircle);
            positionMock.Setup(position => position.Id).Returns(StandardBoardDefinition.StepId);

            var characterMock = new Mock<ICharacter>();
            characterMock.Setup(character => character.Name).Returns(MyCharacterName);
            characterMock.Setup(character => character.StartPosition).Returns(positionMock.Object);

            this._player = StandardPlayer.New(MyPlayerName, PlayerId, null).SetCharacter(characterMock.Object);
        }

        [Test]
        public void CheckPlayerNameAndId()
        {
            Assert.That(this._player.Name, Is.EqualTo(MyPlayerName));
            Assert.That(this._player.Id, Is.EqualTo(PlayerId));
        }

        [Test]
        public void CheckStartingPosition()
        {
            Assert.That(this._player.Position.ActualCircle, Is.EqualTo(StandardBoardDefinition.InnerCircle));
            Assert.That(this._player.Position.Id, Is.EqualTo(StandardBoardDefinition.StepId));
        }

        [Test]
        public void CheckPlayerCharacterName()
        {
            Assert.That(this._player.Character.Name, Is.EqualTo(MyCharacterName));
        }
    }
}