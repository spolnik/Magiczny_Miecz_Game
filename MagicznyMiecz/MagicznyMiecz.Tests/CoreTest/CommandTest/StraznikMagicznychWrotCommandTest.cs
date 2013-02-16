using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class StraznikMagicznychWrotCommandTest
    {
        private ISpecialCommand _command;
        private IGame _game;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetBadCharacter());

            this._command = new StraznikMagicznychWrotCommand();
        }

        [Test]
        public void TestExecute()
        {
            var result = this._command.Execute(this._player);

            Assert.That(result.Success, Is.True);
            Assert.That(this._player.Character.Gold, Is.EqualTo(0));

            result = this._command.Execute(this._player);

            Assert.That(result.Success, Is.False);
            Assert.That(this._player.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));
        }
    }
}