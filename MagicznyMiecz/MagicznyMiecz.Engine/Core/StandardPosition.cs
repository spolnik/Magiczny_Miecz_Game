using System.Collections.Generic;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Engine.Core
{
    internal class StandardPosition : IPosition
    {
        private readonly IList<IPosition> _actualCircle;
        private readonly bool _canSkip;
        private readonly IList<ICard> _cards;
        private readonly ISpecialCommand _command;
        private readonly int _id;
        private readonly int _newCardsCount;
        private readonly BoardState _state;

        private StandardPosition(IList<IPosition> circle, int id, BoardState state, int newCardsCount, ISpecialCommand command, bool canSkip)
        {
            this._actualCircle = circle;
            this._id = id;
            this._state = state;
            this._newCardsCount = newCardsCount;
            this._cards = new List<ICard>();
            this._command = command;
            this._canSkip = canSkip;
        }

        #region IPosition Members

        public bool CanSkip
        {
            get { return this._canSkip; }
        }

        public IList<IPosition> ActualCircle
        {
            get { return this._actualCircle; }
        }

        public int Id
        {
            get { return this._id; }
        }

        public BoardState State
        {
            get { return this._state; }
        }

        public IList<ICard> Cards
        {
            get { return this._cards; }
        }

        public int NewCardsCount
        {
            get { return this._newCardsCount; }
        }

        public ISpecialCommand Command
        {
            get { return this._command; }
        }

        #endregion

        internal static IPosition New(IList<IPosition> circle, int id, BoardState state, int newCardsCount, ISpecialCommand command = null,
                                      bool canSkip = false)
        {
            return new StandardPosition(circle, id, state, newCardsCount, command, canSkip);
        }

        #region Implementation of IEqualityComparer<IPosition>

        public bool Equals(IPosition x, IPosition y)
        {
            return x.Id == y.Id && x.ActualCircle == y.ActualCircle;
        }

        public int GetHashCode(IPosition obj)
        {
            return obj.Id * (obj.ActualCircle.Count + 1) + 37;
        }

        #endregion

        #region Implementation of IEquatable<IPosition>

        public bool Equals(IPosition other)
        {
            return this.Equals(this, other);
        }

        #endregion
    }
}
