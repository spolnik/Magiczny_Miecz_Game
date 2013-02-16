using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;

namespace MagicznyMiecz.Engine.Core
{
    public class StandardCreature : ICreature
    {
        private StandardCreature(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }

        #region Implementation of ICreature

        public int Value { get; private set; }

        public IFightResult Fight(IPlayer player)
        {
            var playerDice = Dice.Throw();
            var creatureDice = Dice.Throw();

            var success = this.DoesPlayerWin(player, playerDice, creatureDice) ? true : false;

            if (!success)
                ((IEditableCharacter)player.Character).RemoveLife(1);

            return FightResult.Create(success, playerDice, creatureDice, false);
        }

        private bool DoesPlayerWin(IPlayer player, int playerDice, int creatureDice)
        {
            return player.Character.Might + playerDice >= this.Value + creatureDice;
        }

        public string Name { get; private set; }

        #endregion

        public static ICreature New(string name, int value)
        {
            return new StandardCreature(name, value);
        }
    }
}
