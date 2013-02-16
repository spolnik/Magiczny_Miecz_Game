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
            string description = "W okolicy pojawi³o siê straszliwe Widmo. Pozostanie tu, a¿ ktoœ je pokona";
            ICard newCard = StandardCard.NewWithCreature("Widmo - Demon", description, x => FightWithMagicCreature(x, "Widmo", 3));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            description = "Mroczna Zjawa budzi przera¿enie i pop³och wœród mieszkañców tej okolicy. Pozostanie tu, a¿ ktoœ j¹ pokona.";
            newCard = StandardCard.NewWithCreature("Zjawa - Demon", description, x => FightWithMagicCreature(x, "Zjawa", 5));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            description = "Wampir bêdzie zamieszkiwa³ tê okolicê a¿ zostanie pokonany.";
            newCard = StandardCard.NewWithCreature("Wampir - Demon", description, x => FightWithMagicCreature(x, "Wampir", 4));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            description = "Okrutny Nobbin zaw³adn¹³ t¹ okolic¹. Pozostanie tu, a¿ ktoœ go pokona.";
            newCard = StandardCard.NewWithCreature("Nobbin - Wróg", description, x => FightWithMightCreature(x, "Nobbin", 2));
            for (var i = 0; i < 3; i++)
                repository.Add(newCard);

            description = "Potworny przybysz z krainy cieni bêdzie wyniszcza³ ten Obszar, dopóki ktoœ go nie pokona.";
            newCard = StandardCard.NewWithCreature("Przybysz z Krainy Cieni - Wróg", description, x => FightWithMightCreature(x, "Przybysz z Krainy Cieni", 5));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            description = "Potê¿ny Wilko³ak sieje spustoszenie w tej okolicy. Pozostanie tu, a¿ ktoœ go pokona.";
            newCard = StandardCard.NewWithCreature("Wilko³ak - Wróg", description, x => FightWithMightCreature(x, "Wilko³ak", 10));
            repository.Add(newCard);
        }

        private static void InitializeCardsWithItems(IEditableRepository<ICard> repository)
        {
            var sztylet = Item.New("Sztylet").SetMight(1);

            string description = "Sztylet podczas walki dodaje w³aœcicielowi 1 punkt Miecza.";
            ICard newCard = StandardCard.NewWithItem("Sztylet", description, x => x.Character.Items.Add(sztylet));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            var miecz = Item.New("Miecz").SetMight(2);

            description = "Miecz podczas walki dodaje w³aœcicielowi 2 punkty Miecza.";
            newCard = StandardCard.NewWithItem("Miecz", description, x => x.Character.Items.Add(miecz));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);

            var mieczChaosu = Item.New("Miecz Chaosu").SetMight(3);
            
            description = "U¿yty w walce dodaje 3 punkty miecza.";
            newCard = StandardCard.NewWithItem("Miecz Chaosu", description, x => x.Character.Items.Add(mieczChaosu));
            repository.Add(newCard);

            var pierscienMocy = Item.New("Pierœcieñ Mocy").SetMagic(2);
            
            description = "Pierœcieñ dodaje w³aœcicielowi 2 punkty magii.";
            newCard = StandardCard.NewWithItem("Pierœcieñ Mocy", description, x => x.Character.Items.Add(pierscienMocy));
            repository.Add(newCard);

            var magicznyTalizman = Item.New("Magiczny Talizman").SetMagic(1);
            
            description = "Talizman dodaje w³aœcicielowi 1 punkt magii.";
            newCard = StandardCard.NewWithItem("Magiczny Talizman", description, x => x.Character.Items.Add(magicznyTalizman));
            for (var i = 0; i < 2; i++)
                repository.Add(newCard);
        }

        private static void InitializeCardsWithGold(IEditableRepository<ICard> repository)
        {
            string description = "Zamieñ kartê na 1 sztukê z³ota, a nastêpnie j¹ od³ó¿.";
            var newCard = StandardCard.NewWithGold("1 Sztuka Z³ota", description, x => ((IEditableCharacter)x.Character).AddGold(1));
            for (var i = 0; i < 15; i++)
                repository.Add(newCard);

            description = "Zamieñ kartê na 2 sztuki z³ota, a nastêpnie j¹ od³ó¿.";
            newCard = StandardCard.NewWithGold("2 Sztuki Z³ota", description, x => ((IEditableCharacter)x.Character).AddGold(2));
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