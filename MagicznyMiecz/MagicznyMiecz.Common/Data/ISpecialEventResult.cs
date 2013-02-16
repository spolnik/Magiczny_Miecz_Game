using System.Collections.Generic;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Common.Data
{
    public interface ISpecialEventResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        List<int> Dices { get; }
        List<ISpecialCommand> OptionalCommands { get; set; }
        IPlayer Player { get; set; }
    }
}