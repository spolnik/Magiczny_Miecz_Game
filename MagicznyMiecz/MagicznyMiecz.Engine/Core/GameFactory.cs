using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;
using Microsoft.Practices.Unity;

namespace MagicznyMiecz.Engine.Core
{
    public static class GameFactory
    {
        public static IGame Create()
        {
            var unityContainer =
                new UnityContainer().RegisterType<IRepository, CharacterRepository>(GameConstants.CharacterRepositoryName)
                        .RegisterType<IRepositoryInitializer<ICharacter>, SimpleCharacterRepositoryInitializer>()
                        .RegisterType<IRepository, ItemRepository>(GameConstants.ItemRepositoryName)
                        .RegisterType<IRepositoryInitializer<IItem>, SimpleItemsRepositoryInitializer>()
                        .RegisterType<ICardRepository, CardRepository>(GameConstants.CardRepositoryName)
                        .RegisterType<IRepositoryInitializer<ICard>, SimpleCardsRepositoryInitialzier>()
                        .RegisterType<IRules, StandardRules>()
                        .RegisterType<IBoard, StandardBoard>();

            var game = unityContainer.Resolve<MagicznyMieczGame>();
            
            game.Init();
            return game;
        }
    }
}
