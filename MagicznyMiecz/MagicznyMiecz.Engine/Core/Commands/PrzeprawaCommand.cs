using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class PrzeprawaCommand : ISpecialCommand
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

            result.Message = "Musisz przeprawiæ siê przez rzekê p³ac¹c przewoŸnikowi 1 Sztuk¹ Z³ota. W przeciwnym wypadku tracisz 1 ¯ycie.";

            return result;
        }

        public string Name
        {
            get { return "Przeprawa"; }
        }

        #endregion
    }
}