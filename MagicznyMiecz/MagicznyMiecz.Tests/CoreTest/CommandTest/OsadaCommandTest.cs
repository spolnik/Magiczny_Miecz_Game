using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using MagicznyMiecz.Engine.Data;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class OsadaCommandTest
    {
        private ISpecialCommand _command;
        private IGame _game;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetGoodCharacter());

            this._command = new OsadaCommand();
        }

        [Test]
        public void TestExecuteWithFirstOption()
        {
            var result = this._command.Execute(this._player);

            Assert.That(result.Dices, Has.Count.EqualTo(0));
            Assert.That(result.Message, Has.Length.AtLeast(1));
            Assert.That(result.OptionalCommands, Is.Not.Null);

            var firstOptionResult = result.OptionalCommands[0].Execute(this._player);

            Assert.That(firstOptionResult.Dices, Has.Count.EqualTo(1));
            Assert.That(firstOptionResult.Message, Has.Length.AtLeast(1));

            if (firstOptionResult.Dices[0] == 6)
                return;

            Assert.That(this._player.Character,
                        Has.Property("Might").EqualTo(PostacTestHelper.DefaultValue)
                            .Or.Property("Might").EqualTo(PostacTestHelper.DefaultValue + 1)
                            .Or.Property("Magic").EqualTo(PostacTestHelper.DefaultValue + 1));
        }

        [Test]
        public void TestExecuteWithSecondOptionBuyMiecz()
        {
            ((IEditableCharacter)this._player.Character).AddGold(1);
            var result = this._command.Execute(this._player);

            var secondOptionResult = result.OptionalCommands[1].Execute(this._player);

            Assert.That(secondOptionResult.Dices, Has.Count.EqualTo(0));
            Assert.That(secondOptionResult.Message, Has.Length.AtLeast(1));
            Assert.That(secondOptionResult.OptionalCommands, Is.Not.Null);

            var finalResult = secondOptionResult.OptionalCommands[0].Execute(this._player);

            Assert.That(finalResult.Dices, Has.Count.EqualTo(0));
            Assert.That(finalResult.Message, Has.Length.AtLeast(1));

            Assert.That(this._player.Character.Items[0].Name, Is.EqualTo(ItemRepository.Miecz));
            Assert.That(this._player.Character.Gold, Is.EqualTo(0));
        }

        [Test]
        public void TestExecuteWithSecondOptionBuySztylet()
        {
            ((IEditableCharacter)this._player.Character).AddGold(2);
            var result = this._command.Execute(this._player);

            var secondOptionResult = result.OptionalCommands[1].Execute(this._player);

            var finalResult = secondOptionResult.OptionalCommands[1].Execute(this._player);

            Assert.That(finalResult.Dices, Has.Count.EqualTo(0));
            Assert.That(finalResult.Message, Has.Length.AtLeast(1));

            Assert.That(this._player.Character.Items[0].Name, Is.EqualTo(ItemRepository.Sztylet));
            Assert.That(this._player.Character.Gold, Is.EqualTo(0));
        }

        [Test]
        public void TestExecuteWithSecondOptionBuyHelm()
        {
            var result = this._command.Execute(this._player);

            var secondOptionResult = result.OptionalCommands[1].Execute(this._player);
            
            var finalResult = secondOptionResult.OptionalCommands[2].Execute(this._player);

            Assert.That(finalResult.Dices, Has.Count.EqualTo(0));
            Assert.That(finalResult.Message, Has.Length.AtLeast(1));

            Assert.That(this._player.Character.Items[0].Name, Is.EqualTo(ItemRepository.Helm));
            Assert.That(this._player.Character.Gold, Is.EqualTo(0));
        }

        [Test]
        public void TestExecuteWithThirdOption()
        {
            ((IEditableCharacter)this._player.Character).RemoveLife(1);
            Assert.That(this._player.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));

            var result = this._command.Execute(this._player);

            Assert.That(result.Dices, Has.Count.EqualTo(0));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            var thirdOptionResult = result.OptionalCommands[2].Execute(this._player);

            Assert.That(thirdOptionResult.Dices, Has.Count.EqualTo(0));
            Assert.That(thirdOptionResult.Message, Has.Length.AtLeast(1));

            Assert.That(this._player.Character.Gold, Is.EqualTo(0));
            Assert.That(this._player.Character.Life, Is.EqualTo(GameConstants.LifeOnStart));
        }
    }
}