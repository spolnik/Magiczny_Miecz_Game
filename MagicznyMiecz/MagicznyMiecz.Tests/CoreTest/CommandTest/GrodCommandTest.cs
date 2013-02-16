using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Core.Commands;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest.CommandTest
{
    [TestFixture]
    public class GrodCommandTest
    {
        private ISpecialCommand _grodCommand;
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

            this._grodCommand = new GrodCommand();
        }

        [Test]
        public void TestExecuteForGoodPlayer()
        {
            var result = this._grodCommand.Execute(this._goodPlayer);

            Assert.That(result.Dices, Has.Count.EqualTo(1));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            switch (result.Dices[0])
            {
                case 1:
                    Assert.That(this._goodPlayer.Character.Magic, Is.EqualTo(PostacTestHelper.DefaultValue + 1));
                    break;
                case 2:
                    Assert.That(this._goodPlayer.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));
                    break;
            }
            
        }

        [Test]
        public void TestExecuteForChaoticPlayer()
        {
            var result = this._grodCommand.Execute(this._chaoticPlayer);

            Assert.That(result.Dices, Has.Count.EqualTo(1));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            switch (result.Dices[0])
            {
                case 1:
                    Assert.That(this._chaoticPlayer.Character.Magic, Is.EqualTo(PostacTestHelper.DefaultValue + 1));
                    break;
                case 2:
                    Assert.That(this._chaoticPlayer.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));
                    break;
                case 3:
                    Assert.That(this._chaoticPlayer.Character.Nature, Is.EqualTo(Nature.Bad));
                    break;
            }
        }

        [Test]
        public void TestExecuteForBadPlayer()
        {
            var result = this._grodCommand.Execute(this._badPlayer);

            Assert.That(result.Dices, Has.Count.EqualTo(1));
            Assert.That(result.Message, Has.Length.AtLeast(1));

            switch (result.Dices[0])
            {
                case 1:
                    Assert.That(this._badPlayer.Character.Magic, Is.EqualTo(PostacTestHelper.DefaultValue + 1));
                    break;
                case 2:
                    Assert.That(this._badPlayer.Character.Life, Is.EqualTo(GameConstants.LifeOnStart - 1));
                    break;
                case 3:
                    Assert.That(this._badPlayer.Character.Nature, Is.EqualTo(Nature.Good));
                    break;
            }
        }
    }
}