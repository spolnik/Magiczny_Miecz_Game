using MagicznyMiecz.Common.Data;

namespace MagicznyMiecz.Common.Core
{
    public interface IGame
    {
        IRepository CharacterRepository { get; set; }
        IRepositoryInitializer<ICharacter> CharacterRepositoryInitializer { get; set; }
        
        IRepository ItemRepository { get; set; }
        IRepositoryInitializer<IItem> ItemRepositoryInitializer { get; set; }

        ICardRepository CardRepository { get; set; }
        IRepositoryInitializer<ICard> CardRepositoryInitializer { get; set; }

        IRules Rules { get; set; }
        IBoard Board { get; set; }

        IPlayer CurrentPlayer { get; }

        IPlayer Register(string playerName);
        void Start();
        void FinishTurn();

        void UpdatePlayer(IPlayer player);

        IPlayer GetOpponent();
    }
}