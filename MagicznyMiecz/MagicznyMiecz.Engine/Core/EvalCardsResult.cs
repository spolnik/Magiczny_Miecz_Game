using System.Collections.Generic;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Engine.Core
{
    public class EvalCardsResult : IEvalCardsResult
    {
        private EvalCardsResult()
        {
            this.Cards = new List<ICard>();
            this.FightResults = new List<IFightResult>();
        }

        #region Implementation of IEvalCardsResult

        public ICollection<ICard> Cards { get; private set; }
        public ICollection<IFightResult> FightResults { get; private set; }

        #endregion

        public static IEvalCardsResult Create()
        {
            return new EvalCardsResult();
        }
    }
}
