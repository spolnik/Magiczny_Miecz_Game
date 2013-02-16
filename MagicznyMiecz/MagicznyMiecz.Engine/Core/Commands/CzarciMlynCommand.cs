using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class CzarciMlynCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();
            result.Success = true;

            switch (player.Character.Nature)
            {
                case Nature.Good:
                    CommandHelper.RemoveOnePointOfLife(player);
                    break;
                case Nature.Chaotic:
                    var diceChaotic = Dice.Throw();
                    result.Dices.Add(diceChaotic);

                    if (diceChaotic < 4)
                        CommandHelper.AddOnePointOfLife(player);
                    else
                        CommandHelper.RemoveOnePointOfLife(player);

                    break;
                case Nature.Bad:
                    var diceBad = Dice.Throw();
                    result.Dices.Add(diceBad);
                    EvalBadCharacter(player, diceBad);
                    break;
            }
            
            result.Message =
                "Je�eli jeste� Dobry - tracisz 1 �ycie; Chaotyczny - rzu� kostk�: 1, 2, 3 - zyskujesz 1 �ycie; 4, 5, 6 - tracisz 1 �ycie; " +
                "Z�y - mo�esz wezwa� Si�y Ciemno�ci: 1 - zyskujesz punkt Miecza; 2 - zyskujesz 1 punkt Magii; 3 - otrzymujesz 1 Sztuk� Z�ota; 4 - zyskujesz dodatkowy ruch; 5 - tracisz 1 tur�; 6 - tracisz 1 �ycie.";

            return result;
        }

        public string Name
        {
            get { return "Czarci M�yn"; }
        }

        private static void EvalBadCharacter(IPlayer player, int diceBad)
        {
            switch (diceBad)
            {
                case 1:
                    CommandHelper.AddOnePointOfMight(player);
                    break;
                case 2:
                    CommandHelper.AddOnePointOfMagic(player);
                    break;
                case 3:
                    CommandHelper.AddOnePointOfGold(player);
                    break;
                case 4:
                    CommandHelper.AddAnotherTurn(player);
                    break;
                case 5:
                    CommandHelper.WaitOneTurn(player);
                    break;
                default:
                    CommandHelper.RemoveOnePointOfLife(player);
                    break;
            }
        }

        #endregion
    }
}