using System.Collections.Generic;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Common.Data
{
    public interface ICardRepository : IEnumerable<ICard>
    {
        int Count { get; }

        ICard NextCard();
    }
}