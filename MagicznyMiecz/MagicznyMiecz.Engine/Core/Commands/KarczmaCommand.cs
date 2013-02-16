using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class KarczmaCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();
            var dice = Dice.Throw();
            result.Dices.Add(dice);
            result.Success = true;

            switch (dice)
            {
                case 1:
                    CommandHelper.RemoveOnePointOfGold(player);
                    break;
                case 2:
                    CommandHelper.AddOnePointOfGold(player);
                    break;
                case 3:
                    CommandHelper.WaitOneTurn(player);
                    break;
                case 4:
                    var osilek = StandardCreature.New("Miejscowy Osi�ek", 4);
                    
                    var fightResult = osilek.Fight(player);
                    result.Success = fightResult.Success;

                    result.Dices.Add(fightResult.PlayerDice);
                    result.Dices.Add(fightResult.CreatureDice);
                    break;
                case 5:
                    CommandHelper.AddOnePointOfMagic(player);
                    break;
                case 6:
                    CommandHelper.GoToSwiatyniaNemed(player);
                    break;
            }

            result.Message =
                "Musisz Rzuci� Kostk�: 1 - przegra�e� w ko�ci 1 Szt. Z�ota; 2 - wygra�e� 1 Szt. Z�ota; 3 - musisz tu nocowa�, tracisz 1 tur�; " +
                "4 - musisz stawi� czo�a miejscowemu osi�kowi (Miecz 4); 5 - pocz�stowano Ci� eliksirem, dzi�ki kt�remu zyskujesz 1 punkt Magii; " +
                "6 - eliksir kt�ry Ci podano mo�e przenie�� Ci� do �wi�tyni Nemed.";

            return result;
        }

        public string Name
        {
            get { return "Karczma"; }
        }

        #endregion
    }
}