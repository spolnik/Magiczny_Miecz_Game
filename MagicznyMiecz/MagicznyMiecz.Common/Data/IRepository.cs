using System.Collections.Generic;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Common.Data
{
    public interface IRepository
    {
        int Count { get; }
        List<string> Names { get; }

        IPlayer Assign(IPlayer player, string name);
        IPlayer Detach(IPlayer player, string name);
    }
}