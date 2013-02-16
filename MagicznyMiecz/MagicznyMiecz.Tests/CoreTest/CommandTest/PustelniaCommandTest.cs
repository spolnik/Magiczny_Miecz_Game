using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class PustelniaCommandTest
    {
        private ISpecialCommand _command;
        private IGame _game;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetBadCharacter());

            this._command = new PustelniaCommand();
        }

        [Test]
        public void TestExecute()
        {
            ((IEditableCharacter)this._player.Character).RemoveLife(1);
            Assert.That(this._player.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));

            var result = this._command.Execute(this._player);

            Assert.That(result.Dices, Has.Count.EqualTo(0));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            Assert.That(this._player.Character.Gold, Is.EqualTo(0));
            Assert.That(this._player.Character.Life, Is.EqualTo(GameConstants.LifeOnStart));
        }
    }
}