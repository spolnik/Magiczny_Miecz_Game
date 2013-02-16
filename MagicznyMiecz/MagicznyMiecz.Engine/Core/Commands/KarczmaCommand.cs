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
                    var osilek = StandardCreature.New("Miejscowy Osi³ek", 4);
                    
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
                "Musisz Rzuciæ Kostk¹: 1 - przegra³eœ w koœci 1 Szt. Z³ota; 2 - wygra³eœ 1 Szt. Z³ota; 3 - musisz tu nocowaæ, tracisz 1 turê; " +
                "4 - musisz stawiæ czo³a miejscowemu osi³kowi (Miecz 4); 5 - poczêstowano Ciê eliksirem, dziêki któremu zyskujesz 1 punkt Magii; " +
                "6 - eliksir który Ci podano mo¿e przenieœæ Ciê do Œwi¹tyni Nemed.";

            return result;
        }

        public string Name
        {
            get { return "Karczma"; }
        }

        #endregion
    }
}