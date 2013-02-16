using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class KragMocyCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();
            var dice = Dice.Throw();
            result.Success = true;
            result.Dices.Add(dice);

            switch (dice)
            {
                case 1:
                    var straznik = StandardCreature.New("Stra¿nik Krêgu", 5);

                    var fightResult = straznik.Fight(player);
                    result.Success = fightResult.Success;

                    result.Dices.Add(fightResult.PlayerDice);
                    result.Dices.Add(fightResult.CreatureDice);

                    break;
                case 2:
                case 3:
                    CommandHelper.WaitOneTurn(player);
                    break;
                case 6:
                    CommandHelper.AddOnePointOfMagic(player);
                    break;
            }
            
            result.Message =
                "Musisz rzuciæ kostk¹: 1 - zosta³eœ zaatakowany przez Stra¿nika Krêgu (Miecz 5);" + 
                " 2, 3 - tracisz 1 ture; 4, 5 - nic siê nie dzieje; 6 - zyskujesz 1 punkt Magii.";

            return result;
        }

        public string Name
        {
            get { return "Kr¹g Mocy"; }
        }

        #endregion
    }
}