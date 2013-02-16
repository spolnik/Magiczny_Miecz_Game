using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class KurhanCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();
            result.Success = true;
            var dice = Dice.Throw();
            result.Dices.Add(dice);

            switch (dice)
            {
                case 1:
                    CommandHelper.AddOnePointOfMight(player);
                    break;
                case 4:
                case 5:
                    CommandHelper.WaitOneTurn(player);
                    break;
                case 6:
                    var duch = StandardMagicCreature.New("Duch", 4);
                    var fightResult = duch.Fight(player);
                    result.Success = fightResult.Success;

                    result.Dices.Add(fightResult.PlayerDice);
                    result.Dices.Add(fightResult.CreatureDice);
                    break;
            }

            result.Message =
                "Musisz rzuciæ kostk¹: 1 - zyskujesz 1 punkt Miecza; 2-3 nic siê nie dzieje; 4-5 zosta³eœ opêtany przez duchy, tracisz 1 turê; " +
                "6 - zosta³eœ zaatakowany przez Ducha (Magia 4)";

            return result;
        }

        public string Name
        {
            get { return "Kurchan"; }
        }

        #endregion
    }
}