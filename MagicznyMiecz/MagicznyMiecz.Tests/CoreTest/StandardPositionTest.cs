using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Engine.Core;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class StandardPositionTest
    {
        private const int NewCardsCount = 1;
        private const int SampleId = 3;

        private IPosition _position;

        [SetUp]
        public void SetUp()
        {
            this._position = StandardPosition.New(StandardBoardDefinition.InnerCircle, SampleId, BoardState.Cards, NewCardsCount);
        }

        [Test]
        public void PositionAfterCreation()
        {
            Assert.That(this._position.NewCardsCount, Is.EqualTo(NewCardsCount));
            Assert.That(this._position.State, Is.EqualTo(BoardState.Cards));
            Assert.That(this._position.Id, Is.EqualTo(SampleId));
        }
    }
}