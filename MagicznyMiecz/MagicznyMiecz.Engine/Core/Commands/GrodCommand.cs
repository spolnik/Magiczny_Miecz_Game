using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class GrodCommand : ISpecialCommand
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
                    CommandHelper.AddOnePointOfMagic(player);
                    break;
                case 2:
                    CommandHelper.RemoveOnePointOfLife(player);
                    break;
                case 3:
                    switch (player.Character.Nature)
                    {
                        case Nature.Bad:
                            player.Character.Nature = Nature.Good;
                            break;
                        case Nature.Chaotic:
                            player.Character.Nature = Nature.Bad;
                            break;
                    }
                    break;
            }

            result.Message = "Mo¿esz tu odwiedziæ: Wró¿bitê. Rzuæ kostk¹: 1 - zyskujesz 1 punkt Magii; 2 - tracisz 1 ¯ycie; 3 - jeœli jesteœ Z³y, stajesz siê Dobry," + 
                " je¿eli jesteœ Chaotyczny stajesz siê Z³y; 4-6 - zosta³eœ zignorowany.";

            return result;
        }

        public string Name
        {
            get { return "Gród"; }
        }

        #endregion
    }
}