using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class StudniaWiecznosciCommandTest
    {
        private ISpecialCommand _command;
        private IGame _game;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetGoodCharacter());

            this._command = new StudniaWiecznosciCommand();
        }

        [Test]
        public void TestExecuteWithFirstOption()
        {
            var result = this._command.Execute(this._player);

            Assert.That(result.Dices, Has.Count.EqualTo(0));
            Assert.That(result.Message, Has.Length.AtLeast(1));
            Assert.That(result.OptionalCommands, Is.Not.Null);

            ((IEditableCharacter)this._player.Character).RemoveLife(1);
            Assert.That(this._player.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));

            var firstOptionResult = result.OptionalCommands[0].Execute(this._player);

            Assert.That(firstOptionResult.Dices, Has.Count.EqualTo(0));
            Assert.That(firstOptionResult.Message, Has.Length.AtLeast(1));

            Assert.That(this._player.Character.Life, Is.EqualTo(GameConstants.LifeOnStart));
        }

        [Test]
        public void TestExecuteWithSecondOption()
        {
            var result = this._command.Execute(this._player);

            var secondOptionResult = result.OptionalCommands[1].Execute(this._player);

            Assert.That(secondOptionResult.Dices, Has.Count.EqualTo(1));
            Assert.That(secondOptionResult.Message, Has.Length.AtLeast(1));

            if (secondOptionResult.Dices[0] > 3)
            {
                Assert.That(this._player.Character, 
                    Has.Property("Magic").EqualTo(PostacTestHelper.DefaultValue + 1)
                    .Or.Property("Life").EqualTo(GameConstants.LifeOnStart + 1)
                    .Or.Property("SkipTurn").EqualTo(-1));   
            }
        }
    }
}