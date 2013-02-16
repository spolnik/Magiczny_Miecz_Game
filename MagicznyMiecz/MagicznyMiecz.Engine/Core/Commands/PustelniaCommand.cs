using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class PustelniaCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();
            result.Success = true;

            while (player.Character.Life < 4)
            {
                if (player.Character.Gold == 0)
                    continue;

                CommandHelper.RemoveOnePointOfGold(player);
                CommandHelper.AddOnePointOfLife(player);
            }

            result.Message =
                "Pustelnik mo¿e z pomoc¹ zió³ przywróciæ Ci punkty ¯ycia z pocz¹tku wêdrówki pod warunkiem, ¿e wyrzekniesz siê bogactwa. " +
                "Musisz odrzuciæ 1 Sztukê Z³ota za ka¿d¹ wyleczon¹ ranê.";

            return result;
        }

        public string Name
        {
            get { return "Pustelnia"; }
        }

        #endregion
    }
}