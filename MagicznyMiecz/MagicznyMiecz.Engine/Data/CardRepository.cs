using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;

namespace MagicznyMiecz.Engine.Data
{
    public class CardRepository : IEditableRepository<ICard>, ICardRepository
    {
        private readonly Queue<ICard> _cards;

        public CardRepository()
        {
            this._cards = new Queue<ICard>();
        }

        #region ICardRepository Members

        public int Count
        {
            get { return this._cards.Count; }
        }

        public ICard NextCard()
        {
            ICard card = this._cards.Dequeue();
            this._cards.Enqueue(card);
            return card;
        }

        #endregion

        #region Implementation of IEditableRepository<in ICard>

        public void Add(ICard card)
        {
            this._cards.Enqueue(card);
        }

        public void Init()
        {
            if (this._cards.Count == 0)
                throw new ApplicationException("Repository is not initialized.");

            var array = new ICard[this._cards.Count];
            this._cards.CopyTo(array, 0);
            this._cards.Clear();

            var random = new Random();
            var list = new List<ICard>(array);
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(length - i);
                this._cards.Enqueue(list[index]);
                list.RemoveAt(index);
                Thread.Sleep(11);
            }

            Trace.Assert(array.Length == this._cards.Count);
        }

        #endregion

        #region Implementation of IEnumerable

        public IEnumerator<ICard> GetEnumerator()
        {
            return this._cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
