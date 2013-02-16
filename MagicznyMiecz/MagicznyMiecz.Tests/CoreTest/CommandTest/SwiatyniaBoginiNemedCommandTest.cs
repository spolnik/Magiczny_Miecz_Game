using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using MagicznyMiecz.Engine.Data;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class SwiatyniaBoginiNemedCommandTest
    {
        private ISpecialCommand _command;
        private IGame _game;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetBadCharacter());

            this._command = new SwiatyniaBoginiNemedCommand();
        }

        [Test]
        public void TestExecute()
        {
            var result = this._command.Execute(this._player);

            Assert.That(result.Dices, Has.Count.EqualTo(2));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            switch (result.Dices[0])
            {
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 12:
                    Assert.That(this._player.Character,
                        Has.Property("Life").EqualTo(GameConstants.LifeOnStart + 2)
                        .Or.Property("Life").EqualTo(GameConstants.LifeOnStart - 1)
                        .Or.Property("Life").EqualTo(GameConstants.LifeOnStart + 1)
                        .Or.Property("Life").EqualTo(GameConstants.LifeOnStart - 2)
                        .Or.Property("Magic").EqualTo(PostacTestHelper.DefaultValue + 1)
                        .Or.Property("Might").EqualTo(PostacTestHelper.DefaultValue + 1)
                        .Or.Property("Might").EqualTo(PostacTestHelper.DefaultValue)
                        .Or.Property("SkipTurn").EqualTo(1));
                    break;
                case 11:
                    Assert.That(this._player.Character.Items[0].Name, Is.EqualTo(ItemRepository.MagicznyMiecz));
                    break;
            }
        }
    }
}