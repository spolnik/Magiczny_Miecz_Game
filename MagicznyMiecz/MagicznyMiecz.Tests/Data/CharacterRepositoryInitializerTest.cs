using System.Linq;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;
using NUnit.Framework;

namespace MagicznyMiecz.Tests.CoreTest
{
    [TestFixture]
    public class CharacterRepositoryInitializerTest
    {
        private const int AllCharactersCount = 16;
        private IRepository _repository;
        private IRepositoryInitializer<ICharacter> _initializer;

        [SetUp]
        public void SetUp()
        {
            this._repository = new CharacterRepository();
            this._initializer = new SimpleCharacterRepositoryInitializer();
            this._initializer.Init((IEditableRepository<ICharacter>)this._repository);
        }

        [Test]
        public void CheckCharactersInitialization()
        {
            var charactersRepositoryForDisplay = (IDisplayElement<ICharacter>)this._repository;

            foreach (var character in
                this._repository.Names.Select(characterName => charactersRepositoryForDisplay[characterName]))
            {
                Assert.That(string.IsNullOrEmpty(character.Name), Is.False);
                Assert.That(character.Might, Is.GreaterThan(0));
                Assert.That(character.Magic, Is.GreaterThan(0));
                Assert.That(character.Gold, Is.AtLeast(GameConstants.GoldOnStart));
                Assert.That(character.Life, Is.EqualTo(GameConstants.LifeOnStart));
                Assert.That(character.Items.Count, Is.AtLeast(0));
            }
        }

        [Test]
        public void CheckNumberOfCharacters()
        {
            Assert.That(this._repository.Count, Is.AtLeast(AllCharactersCount));
        }

        [Test]
        public void CheckIfEqualsCharactersAndCharactersNames()
        {
            Assert.That(this._repository, Has.Count.EqualTo(this._repository.Names.Count));
        }
    }
}