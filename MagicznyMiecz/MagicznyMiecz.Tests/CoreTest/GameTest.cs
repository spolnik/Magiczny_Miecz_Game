using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Core;
using NUnit.Framework;

namespace MagicznyMiecz.Tests
{
    [TestFixture]
    public class GameTest
    {
        private const string PlayerTwoName = "Madzia";
        private const string PlayerOneName = "Julia";
        private IGame _game;
        private IPlayer[] _players;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            var playerOne = this._game.Register(PlayerOneName);
            var playerTwo = this._game.Register(PlayerTwoName);

            this._players = new[] { playerOne, playerTwo };
        }

        [Test]
        public void TestSecondInitRepositoryMethodCall()
        {
            Assert.That(() => ((IEditableRepository<ICharacter>)this._game.CharacterRepository).Init(),
                        Throws.Exception.TypeOf<ApplicationException>());

            Assert.That(() => ((IEditableRepository<IItem>)this._game.ItemRepository).Init(),
                        Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void TestStartingGameWithLessThanTwoPlayers()
        {
            var game = GameFactory.Create();
            game.Register(PlayerTwoName);
            Assert.That(() => game.Start(), Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void TestAddingTwoPlayersWithTheSameName()
        {
            var game = GameFactory.Create();
            game.Register(PlayerOneName);

            Assert.That(() => game.Register(PlayerOneName), Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void TestStartGameWithoutInitialization()
        {
            var game = new MagicznyMieczGame();
            game.Register(PlayerOneName);
            game.Register(PlayerTwoName);

            Assert.That(() => game.Start(), Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void TestCurrentPlayerBeforeStart()
        {
            Assert.That(this._game.CurrentPlayer, Is.Null);
        }

        [Test]
        public void TestIfCharactersExistInRepository()
        {
            Assert.That(this._game.CharacterRepository.Count, Is.GreaterThan(0));
        }

        [Test]
        public void StartGameWithoutCharactersInPlayers()
        {
            Assert.That(() => this._game.Start(), Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void CheckCurrentPlayer()
        {
            this._players[0] = this._game.CharacterRepository.Assign(this._players[0], this._game.CharacterRepository.Names[0]);
            this._game.UpdatePlayer(this._players[0]);

            this._players[1] = this._game.CharacterRepository.Assign(this._players[1], this._game.CharacterRepository.Names[0]);
            this._game.UpdatePlayer(this._players[1]);

            this._game.Start();
            Assert.That(this._game.CurrentPlayer, Is.SameAs(this._players[0]));
        }
    }
}