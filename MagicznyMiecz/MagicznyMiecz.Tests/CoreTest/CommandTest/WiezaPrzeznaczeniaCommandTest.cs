using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class WiezaPrzeznaczeniaCommandTest
    {
        private ISpecialCommand _command;
        private IGame _game;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetBadCharacter());

            this._command = new WiezaPrzeznaczeniaCommand();
        }

        [Test]
        public void TestExecute()
        {
            var result = this._command.Execute(this._player);

            Assert.That(result.Dices, Has.Count.EqualTo(1));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            if (result.Dices[0] == 6)
                return;

            Assert.That(this._player.Character,
                        Has.Property("Life").EqualTo(GameConstants.LifeOnStart - 1)
                            .Or.Property("SkipTurn").EqualTo(1)
                            .Or.Property("SkipTurn").EqualTo(-1));
        }
    }
}