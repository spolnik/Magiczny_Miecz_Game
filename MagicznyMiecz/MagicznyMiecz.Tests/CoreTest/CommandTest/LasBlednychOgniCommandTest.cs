using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class LasBlednychOgniCommandTest
    {
        private ISpecialCommand _command;
        private IGame _game;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetBadCharacter());

            this._command = new LasBlednychOgniCommand();
        }

        [Test]
        public void TestExecute()
        {
            var result = this._command.Execute(this._player);

            this._player = result.Player;

            Assert.That(result.Dices, Has.Count.EqualTo(0));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            Assert.That(this._player.Position, Is.EqualTo(this._game.Board.GoFromMiddleToInner()));
        }
    }
}