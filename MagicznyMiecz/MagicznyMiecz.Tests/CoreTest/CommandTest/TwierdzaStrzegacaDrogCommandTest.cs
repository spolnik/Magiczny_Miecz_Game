using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using MagicznyMiecz.Engine.Data;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class TwierdzaStrzegacaDrogCommandTest
    {
        private ISpecialCommand _command;
        private IGame _game;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetBadCharacter());

            this._command = new TwierdzaStrzegacaDrogCommand();
        }

        [Test]
        public void TestExecute()
        {
            ((IEditableCharacter)this._player.Character).AddGold(2);

            var result = this._command.Execute(this._player);

            Assert.That(result.Dices, Has.Count.AtLeast(1));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            switch (result.Dices[0])
            {
                case 1:
                case 2:
                case 3:
                    if (result.Success)
                    {
                        Assert.That(this._player.Character.Items[0].Name, Is.EqualTo(ItemRepository.TarczaBogaTolimana));
                    }
                    else
                    {
                        Assert.That(this._player.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));
                    }
                    break;
                case 4:
                case 5:
                case 6:
                    Assert.That(this._player.Character.Items[0].Name, Is.EqualTo(ItemRepository.TarczaBogaTolimana));
                    break;
            }
        }
    }
}