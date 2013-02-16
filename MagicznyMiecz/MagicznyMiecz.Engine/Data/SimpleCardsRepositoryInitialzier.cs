using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Core;

namespace MagicznyMiecz.Engine.Data
{
    public class SimpleCardsRepositoryInitialzier : IRepositoryInitializer<ICard>
    {
        #region Implementation of IRepositoryInitializer<out ICard>

        public void Init(IEditableRepository<ICard> repository)
        {
            InitializeCardsWithGold(repository);

            InitializeCardsWithItems(repository);

            InitializeCardsWithCreatures(repository);

            repository.Init();
        }

        private static void InitializeCardsWithCreatures(IEditableRepository<ICard> repository)
        {
            string description = "W okolicy pojawi�o si� straszliwe Widmo. Pozostanie tu, a� kto� je pokona";
            ICard newCard = StandardCard.NewWithCreature("Widmo - Demon", description, x => FightWithMagicCreature(x, "Widmo", 3));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            description = "Mroczna Zjawa budzi przera�enie i pop�och w�r�d mieszka�c�w tej okolicy. Pozostanie tu, a� kto� j� pokona.";
            newCard = StandardCard.NewWithCreature("Zjawa - Demon", description, x => FightWithMagicCreature(x, "Zjawa", 5));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            description = "Wampir b�dzie zamieszkiwa� t� okolic� a� zostanie pokonany.";
            newCard = StandardCard.NewWithCreature("Wampir - Demon", description, x => FightWithMagicCreature(x, "Wampir", 4));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            description = "Okrutny Nobbin zaw�adn�� t� okolic�. Pozostanie tu, a� kto� go pokona.";
            newCard = StandardCard.NewWithCreature("Nobbin - Wr�g", description, x => FightWithMightCreature(x, "Nobbin", 2));
            for (var i = 0; i < 3; i++)
                repository.Add(newCard);

            description = "Potworny przybysz z krainy cieni b�dzie wyniszcza� ten Obszar, dop�ki kto� go nie pokona.";
            newCard = StandardCard.NewWithCreature("Przybysz z Krainy Cieni - Wr�g", description, x => FightWithMightCreature(x, "Przybysz z Krainy Cieni", 5));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            description = "Pot�ny Wilko�ak sieje spustoszenie w tej okolicy. Pozostanie tu, a� kto� go pokona.";
            newCard = StandardCard.NewWithCreature("Wilko�ak - Wr�g", description, x => FightWithMightCreature(x, "Wilko�ak", 10));
            repository.Add(newCard);
        }

        private static void InitializeCardsWithItems(IEditableRepository<ICard> repository)
        {
            var sztylet = Item.New("Sztylet").SetMight(1);

            string description = "Sztylet podczas walki dodaje w�a�cicielowi 1 punkt Miecza.";
            ICard newCard = StandardCard.NewWithItem("Sztylet", description, x => x.Character.Items.Add(sztylet));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            var miecz = Item.New("Miecz").SetMight(2);

            description = "Miecz podczas walki dodaje w�a�cicielowi 2 punkty Miecza.";
            newCard = StandardCard.NewWithItem("Miecz", description, x => x.Character.Items.Add(miecz));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            var mieczChaosu = Item.New("Miecz Chaosu").SetMight(3);
            
            description = "U�yty w walce dodaje 3 punkty miecza.";
            newCard = StandardCard.NewWithItem("Miecz Chaosu", description, x => x.Character.Items.Add(mieczChaosu));
            repository.Add(newCard);

            var pierscienMocy = Item.New("Pier�cie� Mocy").SetMagic(2);
            
            description = "Pier�cie� dodaje w�a�cicielowi 2 punkty magii.";
            newCard = StandardCard.NewWithItem("Pier�cie� Mocy", description, x => x.Character.Items.Add(pierscienMocy));
            repository.Add(newCard);

            var magicznyTalizman = Item.New("Magiczny Talizman").SetMagic(1);
            
            description = "Talizman dodaje w�a�cicielowi 1 punkt magii.";
            newCard = StandardCard.NewWithItem("Magiczny Talizman", description, x => x.Character.Items.Add(magicznyTalizman));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);
        }

        private static void InitializeCardsWithGold(IEditableRepository<ICard> repository)
        {
            string description = "Zamie� kart� na 1 sztuk� z�ota, a nast�pnie j� od��.";
            var newCard = StandardCard.NewWithGold("1 Sztuka Z�ota", description, x => ((IEditableCharacter)x.Character).AddGold(1));
            for (var i = 0; i < 15; i++)
                repository.Add(newCard);

            description = "Zamie� kart� na 2 sztuki z�ota, a nast�pnie j� od��.";
            newCard = StandardCard.NewWithGold("2 Sztuki Z�ota", description, x => ((IEditableCharacter)x.Character).AddGold(2));
            for (var i = 0; i < 3; i++)
                repository.Add(newCard);
        }

        private static IFightResult FightWithMagicCreature(IPlayer player, string creatureName, int value)
        {
            return StandardMagicCreature.New(creatureName, value).Fight(player);
        }

        private static IFightResult FightWithMightCreature(IPlayer player, string creatureName, int value)
        {
            return StandardCreature.New(creatureName, value).Fight(player);
        }

        #endregion
    }
}