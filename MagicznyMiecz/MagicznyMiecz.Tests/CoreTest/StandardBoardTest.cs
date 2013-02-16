using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Engine.Core;
using Moq;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class StandardBoardTest
    {
        private IBoard _board;
        private Mock<IPosition> _positionMock;
        private Mock<IPosition> _positionMiddleMock;
        private Mock<IPosition> _positionOuterMock;
        private const int Dice = 3;

        [SetUp]
        public void SetUp()
        {
            this._board = new StandardBoard();
            this._positionMock = new Mock<IPosition>();
            this._positionMock.Setup(position => position.ActualCircle).Returns(StandardBoardDefinition.InnerCircle);
            this._positionMock.Setup(position => position.Id).Returns(StandardBoardDefinition.KarczmaId);

            this._positionMiddleMock = new Mock<IPosition>();
            this._positionMiddleMock.Setup(position => position.ActualCircle).Returns(StandardBoardDefinition.MiddleCircle);
            this._positionMiddleMock.Setup(position => position.Id).Returns(StandardBoardDefinition.LasBlednychOgniId);

            this._positionOuterMock = new Mock<IPosition>();
            this._positionOuterMock.Setup(position => position.ActualCircle).Returns(StandardBoardDefinition.OuterCircle);
            this._positionOuterMock.Setup(position => position.Id).Returns(StandardBoardDefinition.KryptaUpiorowId);
        }

        [Test]
        public void CheckGoClockwiseInnerCircle()
        {
            var position = this._board.GoClockwise(this._positionMock.Object, Dice);
            Assert.That(StandardBoardDefinition.Mokradla2Id, Is.EqualTo(position.Id));
        }

        [Test]
        public void CheckGoCounterClockwiseInnerCircle()
        {
            var position = this._board.GoCounterClockwise(this._positionMock.Object, Dice);
            Assert.That(StandardBoardDefinition.BezdrozaId, Is.EqualTo(position.Id));
        }

        [Test]
        public void CheckGoClockwiseMiddleCircle()
        {
            var position = this._board.GoClockwise(this._positionMiddleMock.Object, Dice);
            Assert.That(StandardBoardDefinition.Przeprawa2Id, Is.EqualTo(position.Id));
        }

        [Test]
        public void CheckGoCounterClockwiseMiddleCircle()
        {
            var position = this._board.GoCounterClockwise(this._positionMiddleMock.Object, Dice);
            Assert.That(StandardBoardDefinition.PlaskowyzMgielId, Is.EqualTo(position.Id));
        }

        [Test]
        public void CheckGoClockwiseOuterCircle()
        {
            var position = this._board.GoClockwise(this._positionOuterMock.Object, Dice);
            Assert.That(StandardBoardDefinition.KamiennyLasId, Is.EqualTo(position.Id));
        }

        [Test]
        public void CheckGoCounterClockwiseOuterCircle()
        {
            var position = this._board.GoCounterClockwise(this._positionOuterMock.Object, Dice);
            Assert.That(StandardBoardDefinition.WymarleMiastoId, Is.EqualTo(position.Id));
        }

        [Test]
        public void CheckPositionAfterGoFromInnerToMiddleCircle()
        {
            var position = this._board.GoFromInnerToMiddle();

            Assert.That(position.State, Is.EqualTo(BoardState.CardsOrSpecial));
            Assert.That(position.ActualCircle, Is.EqualTo(StandardBoardDefinition.MiddleCircle));
            Assert.That(position.Id, Is.EqualTo(StandardBoardDefinition.LasBlednychOgniId));
        }

        [Test]
        public void CheckPositionAfterGoFromMiddleToOuterCircle()
        {
            var position = this._board.GoFromMiddleToOuter();

            Assert.That(position.State, Is.EqualTo(BoardState.CardsOrSpecial));
            Assert.That(position.ActualCircle, Is.EqualTo(StandardBoardDefinition.OuterCircle));
            Assert.That(position.Id, Is.EqualTo(StandardBoardDefinition.DolinaCzaszekId));
        }

        [Test]
        public void CheckPositionAfterGoToSwiatyniaNemed()
        {
            var position = this._board.GoToSwiatyniaNemed();

            Assert.That(position.State, Is.EqualTo(BoardState.Special));
            Assert.That(position.CanSkip, Is.True);
            Assert.That(position.ActualCircle, Is.EqualTo(StandardBoardDefinition.MiddleCircle));
            Assert.That(position.Id, Is.EqualTo(StandardBoardDefinition.SwiatyniaBoginiNemedId));
        }

        [Test]
        public void CheckPositionAfterGoFromMiddleToInnerCircle()
        {
            var position = this._board.GoFromMiddleToInner();

            Assert.That(position.State, Is.EqualTo(BoardState.CardsOrSpecial));
            Assert.That(position.ActualCircle, Is.EqualTo(StandardBoardDefinition.InnerCircle));
            Assert.That(position.Id, Is.EqualTo(StandardBoardDefinition.UroczyskoId));
        }
    }
}