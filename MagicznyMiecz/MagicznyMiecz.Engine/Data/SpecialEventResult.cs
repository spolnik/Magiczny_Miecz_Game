using System.Collections.Generic;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;

namespace MagicznyMiecz.Engine.Data
{
    public class SpecialEventResult : ISpecialEventResult
    {
        private SpecialEventResult()
        {
            this.Dices = new List<int>();
        }

        #region ISpecialEventResult Members

        public bool Success { get; set; }

        public string Message { get; set; }

        public List<int> Dices { get; private set; }

        public List<ISpecialCommand> OptionalCommands { get; set; }

        public IPlayer Player { get; set; }

        #endregion

        public static ISpecialEventResult Create()
        {
            return new SpecialEventResult();
        }
    }
}
