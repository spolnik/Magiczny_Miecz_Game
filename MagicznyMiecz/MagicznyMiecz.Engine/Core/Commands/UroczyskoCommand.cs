using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class UroczyskoCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();

            var firstDice = Dice.Throw();
            var secondDice = Dice.Throw();

            result.Dices.Add(firstDice);
            result.Dices.Add(secondDice);

            result.Success = IsMagicLessThanTwoDices(firstDice, secondDice, player);

            if (result.Success)
            {
                var position = player.Game.Board.GoFromInnerToMiddle();
                result.Player = player.SetPosition(position);
            }
            else
            {
                CommandHelper.RemoveOnePointOfLife(player);
            }

            result.Message =
                "Aby przebyæ Trzêsawiska musisz u¿yæ Magii. Rzuæ dwoma kostkami: wynik mniejszy lub równy twojej Magii - przeprawi³eœ siê na drug¹ stronê." +
                " Wiêkszy wynik oznacza pora¿kê (tracisz 1 ¯ycie). Nie mo¿esz kontynuowaæ podró¿y dopóki nie przejdziesz przez Trzêsawiska.";

            return result;
        }

        public string Name
        {
            get { return "Uroczysko"; }
        }

        private static bool IsMagicLessThanTwoDices(int firstDice, int secondDice, IPlayer player)
        {
            return firstDice + secondDice <= player.Character.PureMagic;
        }

        #endregion
    }
}