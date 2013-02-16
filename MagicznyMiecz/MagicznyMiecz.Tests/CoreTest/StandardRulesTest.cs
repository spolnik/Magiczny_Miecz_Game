using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class StandardRulesTest
    {
        private IGame _game;
        private IPlayer _playerOne;
        private IPlayer _playerTwo;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._playerOne = this._game.Register("Madzia");
            this._playerTwo = this._game.Register("Julia");

            this._playerOne = this._game.CharacterRepository.Assign(this._playerOne, this._game.CharacterRepository.Names[0]);
            this._game.UpdatePlayer(this._playerOne);

            this._playerTwo = this._game.CharacterRepository.Assign(this._playerTwo, this._game.CharacterRepository.Names[0]);
            this._game.UpdatePlayer(this._playerTwo);

            this._game.Start();
        }

        [Test]
        public void PlayersGoToMiddleCircle()
        {
            //START POSITION -> GROD
            this._game.Rules.GoClockwise(3);

            Assert.That(this._game.CurrentPlayer.Position.State, Is.EqualTo(BoardState.CardsOrSpecial));

            var result = this._game.Rules.EvalSpecial();

            Assert.That(result.Dices, Has.Count.EqualTo(2));
            Assert.That(result.Message, Has.Length.GreaterThan(0));

            if (result.Success)
            {
                Assert.That(this._playerOne.Position.ActualCircle, Is.EqualTo(StandardBoardDefinition.MiddleCircle));
            }
            else
            {
                Assert.That(this._playerOne.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));    
            }

            this._game.FinishTurn();
            Assert.That(this._playerTwo, Is.EqualTo(this._game.CurrentPlayer));
        }

        [Test]
        public void FirstDiceOfPlayers()
        {
            int dice = Dice.Throw();
            IPosition startPosition = this._playerOne.Position;
            IPosition newPosition = this._game.Board.GoClockwise(startPosition, dice);

            this._game.Rules.GoClockwise(dice);
            var currentPlayer = this._game.CurrentPlayer;
            this._game.FinishTurn();
            Assert.That(this._playerTwo, Is.EqualTo(this._game.CurrentPlayer));
            Assert.That(newPosition, Is.EqualTo(currentPlayer.Position));

            dice = Dice.Throw();
            startPosition = this._playerTwo.Position;
            newPosition = this._game.Board.GoCounterClockwise(startPosition, dice);

            this._game.Rules.GoCounterClockwise(dice);
            currentPlayer = this._game.CurrentPlayer;
            this._game.FinishTurn();
            Assert.That(this._playerOne, Is.EqualTo(this._game.CurrentPlayer));
            Assert.That(newPosition, Is.EqualTo(currentPlayer.Position));
        }

        [Test]
        public void CheckStateAndGetGameEventCard()
        {
            const int DiceToGoOnGetEventCardsField = 5;

            var position = this._game.Rules.GoClockwise(DiceToGoOnGetEventCardsField);
            
            Assert.That(position.State, Is.EqualTo(BoardState.Cards));

            var cardsCount = position.NewCardsCount;
            var evalCardsResult = this._game.Rules.EvalCards();

            Assert.That(evalCardsResult.Cards, Has.Count.EqualTo(cardsCount));

            this._game.FinishTurn();
            
            Assert.That(this._playerTwo, Is.SameAs(this._game.CurrentPlayer));
        }

        [Test]
        public void CheckStateAndFightWithOpponentMight()
        {
            const int Dice = 5;

            this._game.Rules.GoClockwise(Dice);

            this._game.FinishTurn();

            var position = this._game.Rules.GoCounterClockwise(2);

            Assert.That(this._game.GetOpponent(), Is.Not.Null);

            var result = this._game.Rules.Fight(false);

            Assert.That(result.Success ? this._game.GetOpponent().Character.Life : this._game.CurrentPlayer.Character.Life,
                        Is.EqualTo(GameConstants.LifeOnStart - 1));

            this._game.FinishTurn();
            
            Assert.That(this._playerOne, Is.SameAs(this._game.CurrentPlayer));
        }

        [Test]
        public void CheckStateAndFightWithOpponentMagic()
        {
            const int Dice = 3;

            this._game.Rules.GoClockwise(Dice);

            this._game.FinishTurn();

            var position = this._game.Rules.GoCounterClockwise(2);

            Assert.That(this._game.GetOpponent(), Is.Not.Null);

            var result = this._game.Rules.Fight(true);

            Assert.That(result.Success ? this._game.GetOpponent().Character.Life : this._game.CurrentPlayer.Character.Life,
                        Is.EqualTo(GameConstants.LifeOnStart - 1));

            this._game.FinishTurn();

            Assert.That(this._playerOne, Is.SameAs(this._game.CurrentPlayer));
        }
    }
}
