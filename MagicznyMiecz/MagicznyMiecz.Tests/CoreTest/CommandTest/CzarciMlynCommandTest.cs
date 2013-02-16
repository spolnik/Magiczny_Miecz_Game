using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class CzarciMlynCommandTest
    {
        private ISpecialCommand _czarciMlynCommand;
        private IGame _game;

        private IPlayer _badPlayer;
        private IPlayer _chaoticPlayer;
        private IPlayer _goodPlayer;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._badPlayer = this._game.Register("Bad Player").SetCharacter(PostacTestHelper.GetBadCharacter());
            this._chaoticPlayer = this._game.Register("Chaotic Player").SetCharacter(PostacTestHelper.GetChaoticCharacter());
            this._goodPlayer = this._game.Register("Good Player").SetCharacter(PostacTestHelper.GetGoodCharacter());
            
            this._czarciMlynCommand = new CzarciMlynCommand();
        }

        [Test]
        public void TestExecuteForGoodPlayer()
        {
            var result = this._czarciMlynCommand.Execute(this._goodPlayer);

            Assert.That(result.Dices, Has.Count.EqualTo(0));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            Assert.That(this._goodPlayer.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));
        }

        [Test]
        public void TestExecuteForChaoticPlayer()
        {
            var result = this._czarciMlynCommand.Execute(this._chaoticPlayer);

            Assert.That(result.Dices, Has.Count.EqualTo(1));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            Assert.That(this._chaoticPlayer.Character.Life, 
                Is.EqualTo(GameConstants.LifeOnStart - 1).
                Or.EqualTo(GameConstants.LifeOnStart + 1));
        }

        [Test]
        public void TestExecuteForBadPlayer()
        {
            var result = this._czarciMlynCommand.Execute(this._badPlayer);

            Assert.That(result.Dices, Has.Count.EqualTo(1));
            Assert.That(result.Message, Has.Length.AtLeast(1));
            
            Assert.That(this._badPlayer.Character,
                Has.Property("Life").EqualTo(GameConstants.LifeOnStart - 1)
                .Or.Property("Might").EqualTo(PostacTestHelper.DefaultValue + 1)
                .Or.Property("Magic").EqualTo(PostacTestHelper.DefaultValue + 1)
                .Or.Property("Gold").EqualTo(GameConstants.GoldOnStart + 1)
                .Or.Property("SkipTurn").EqualTo(1)
                .Or.Property("SkipTurn").EqualTo(-1));
        }
    }
}