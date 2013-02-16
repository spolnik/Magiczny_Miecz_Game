using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class PrzeleczWichrowCommandTest
    {
        private ISpecialCommand _command;
        private IGame _game;

        private IPlayer _player;

        [SetUp]
        public void SetUp()
        {
            this._game = GameFactory.Create();

            this._player = this._game.Register("Player").SetCharacter(PostacTestHelper.GetBadCharacter());

            this._command = new PrzeleczWichrowCommand();
        }

        [Test]
        public void TestExecute()
        {
            var result = this._command.Execute(this._player);

            Assert.That(result.Dices, Has.Count.EqualTo(3));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            if (result.Success)
            {
                Assert.That(this._player.Position, Is.EqualTo(this._game.Board.GoFromMiddleToOuter()));
            }
            else
            {
                Assert.That(this._player.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));
            }
        }
    }
}