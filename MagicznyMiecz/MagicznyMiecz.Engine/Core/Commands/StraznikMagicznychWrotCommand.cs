using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class StraznikMagicznychWrotCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            ISpecialEventResult result = SpecialEventResult.Create();

            if (player.Character.Gold > 0)
            {
                CommandHelper.RemoveOnePointOfGold(player);
                result.Success = true;
            }
            else
            {
                CommandHelper.RemoveOnePointOfLife(player);
                result.Success = false;
            }

            result.Message = "Aby przej�� przez Wrota musisz si� wykupi� 1 Sztuk� Z�ota. W przeciwnym wypadku tracisz 1 �ycie.";

            return result;
        }

        public string Name
        {
            get { return "Stra�nik Magicznych Wr�t"; }
        }

        #endregion
    }
}
