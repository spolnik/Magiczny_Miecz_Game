using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class KurhanCommandTest
    {
        private ISpecialCommand _command;
        private IGame _game;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetBadCharacter());

            this._command = new KurhanCommand();
        }

        [Test]
        public void TestExecute()
        {
            var result = this._command.Execute(this._player);

            Assert.That(result.Dices, Has.Count.GreaterThanOrEqualTo(1).And.Count.LessThanOrEqualTo(3));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            switch (result.Dices[0])
            {
                case 1:
                case 4:
                case 5:
                    Assert.That(this._player.Character,
                        Has.Property("Might").EqualTo(PostacTestHelper.DefaultValue + 1)
                        .Or.Property("SkipTurn").EqualTo(1));
                    break;
                case 6:
                    Assert.That(this._player.Character.Life,
                                result.Success ? Is.EqualTo(GameConstants.LifeOnStart) : Is.EqualTo(GameConstants.LifeOnStart - 1));
                    break;
            }
        }
    }
}