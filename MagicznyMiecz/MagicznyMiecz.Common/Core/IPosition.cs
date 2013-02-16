using System;
using System.Collections.Generic;

namespace MagicznyMiecz.Common.Core
{
    public interface IPosition : IEqualityComparer<IPosition>, IEquatable<IPosition>
    {
        IList<IPosition> ActualCircle { get; }
        int Id { get; }
        BoardState State { get; }
        IList<ICard> Cards { get; }
        int NewCardsCount { get; }
        ISpecialCommand Command { get; }
        bool CanSkip { get; }
    }
}
