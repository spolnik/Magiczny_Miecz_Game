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
                "Aby przeby� Trz�sawiska musisz u�y� Magii. Rzu� dwoma kostkami: wynik mniejszy lub r�wny twojej Magii - przeprawi�e� si� na drug� stron�." +
                " Wi�kszy wynik oznacza pora�k� (tracisz 1 �ycie). Nie mo�esz kontynuowa� podr�y dop�ki nie przejdziesz przez Trz�sawiska.";

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