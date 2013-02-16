using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class WiezaPrzeznaczeniaCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            ISpecialEventResult result = SpecialEventResult.Create();
            int dice = Dice.Throw();
            result.Success = true;

            switch (dice)
            {
                case 1:
                    CommandHelper.WaitOneTurn(player);
                    break;
                case 2:
                case 3:
                    CommandHelper.RemoveOnePointOfLife(player);
                    break;
                case 4:
                case 5:
                    CommandHelper.AddAnotherTurn(player);
                    break;
            }

            result.Dices.Add(dice);
            result.Message = "Znalaz�e� si� pod wp�ywem pot�nych si� Wie�y." +
                             "Rzu� kostk�: 1 - tracisz 1 Tur�; 2, 3 - tracisz 1 �ycie; 4, 5 - zyskujesz dodatkowy ruch; " +
                             "6 - zosta�e� zignorowany.";

            return result;
        }

        public string Name
        {
            get { return "Wie�a przeznaczenia"; }
        }

        #endregion
    }
}
