using System.Collections.Generic;

namespace MagicznyMiecz.Common.Core
{
    public interface IEvalCardsResult
    {
        ICollection<ICard> Cards { get; }
        ICollection<IFightResult> FightResults { get; }
    }
}