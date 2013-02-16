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
                "Pustelnik mo�e z pomoc� zi� przywr�ci� Ci punkty �ycia z pocz�tku w�dr�wki pod warunkiem, �e wyrzekniesz si� bogactwa. " +
                "Musisz odrzuci� 1 Sztuk� Z�ota za ka�d� wyleczon� ran�.";

            return result;
        }

        public string Name
        {
            get { return "Pustelnia"; }
        }

        #endregion
    }
}