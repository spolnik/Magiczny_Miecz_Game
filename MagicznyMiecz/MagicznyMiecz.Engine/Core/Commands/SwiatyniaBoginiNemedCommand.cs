using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class SwiatyniaBoginiNemedCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();
            result.Success = true;
            var firstDice = Dice.Throw();
            var secondDice = Dice.Throw();

            result.Dices.Add(firstDice);
            result.Dices.Add(secondDice);

            switch (firstDice + secondDice)
            {
                case 2:
                    CommandHelper.AddManyPointsOfLife(player, 2);
                    break;
                case 3:
                case 4:
                    CommandHelper.RemoveOnePointOfLife(player);
                    break;
                case 5:
                case 6:
                    CommandHelper.AddOnePointOfMight(player);
                    break;
                case 7:
                    CommandHelper.AddOnePointOfMagic(player);
                    break;
                case 8:
                    CommandHelper.AddOnePointOfLife(player);
                    break;
                case 9:
                    CommandHelper.WaitOneTurn(player);
                    break;
                case 10:
                    CommandHelper.RemoveOnePointOfMight(player);
                    break;
                case 11:
                    player.Game.ItemRepository.Assign(player, ItemRepository.MagicznyMiecz);
                    break;
                case 12:
                    CommandHelper.RemoveManyPointsOfLife(player, 2);
                    break;
            }

            result.Message =
                "Mo¿esz modliæ siê rzucaj¹c dwiema kostkami: 2 - zyskujesz 2 punkty ¯ycia; 3,4 - Tracisz 1 Punkt ¯ycia; 5,6 - Zyskujesz 1 punkt Miecza; " +
                "7 - zyskujesz 1 punkt Magii; 8 - zyskujesz 1 punkt ¯ycia; 9 - zosta³eœ opêtany, tracisz jedn¹ turê; 10 - tracisz jeden punkt miecza; " +
                "11 - otrzymujesz Magiczny miecz; 12 - tracisz 2 punkty ¯ycia";

            return result;
        }

        public string Name
        {
            get { return "Œwi¹tynia Bogini Nemed"; }
        }

        #endregion
    }
}