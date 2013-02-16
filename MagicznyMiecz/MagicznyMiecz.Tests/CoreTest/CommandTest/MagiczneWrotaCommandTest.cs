using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class MagiczneWrotaCommandTest
    {
        private ISpecialCommand _command;
        private IGame _game;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetBadCharacter());

            this._command = new MagiczneWrotaCommand();
        }

        [Test]
        public void TestExecuteWithFirstOption()
        {
            var result = this._command.Execute(this._player);

            Assert.That(result.Dices, Has.Count.EqualTo(0));
            Assert.That(result.Message, Has.Length.AtLeast(1));
            Assert.That(result.OptionalCommands, Is.Not.Null);

            var firstOptionResult = result.OptionalCommands[0].Execute(this._player);

            Assert.That(firstOptionResult.Dices, Has.Count.EqualTo(0));
            Assert.That(firstOptionResult.Message, Has.Length.AtLeast(1));

            Assert.That(this._player.Character.Might, Is.EqualTo(PostacTestHelper.DefaultValue + 1));
        }

        [Test]
        public void TestExecuteWithSecondOption()
        {
            var result = this._command.Execute(this._player);

            var secondOptionResult = result.OptionalCommands[1].Execute(this._player);

            Assert.That(secondOptionResult.Dices, Has.Count.EqualTo(0));
            Assert.That(secondOptionResult.Message, Has.Length.AtLeast(1));

            Assert.That(this._player.Character.Magic, Is.EqualTo(PostacTestHelper.DefaultValue + 1));
        }

        [Test]
        public void TestExecuteWithThirdOption()
        {
            var result = this._command.Execute(this._player);

            var thirdOptionResult = result.OptionalCommands[2].Execute(this._player);

            Assert.That(thirdOptionResult.Dices, Has.Count.EqualTo(0));
            Assert.That(thirdOptionResult.Message, Has.Length.AtLeast(1));

            Assert.That(this._player.Character.Gold, Is.EqualTo(GameConstants.GoldOnStart + 1));
        }
    }
}
