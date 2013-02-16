using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class LasBlednychOgniCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();
            result.Success = true;

            var position = player.Game.Board.GoFromMiddleToInner();
            
            result.Player = player.SetPosition(position);
            result.Message = "Tylko t�dy mo�na przeprawi� si� na uroczysko (nie rzucaj�c kostk�).";
             
            return result;
        }

        public string Name
        {
            get { return "Las B��dnych Ogni"; }
        }

        #endregion
    }
}