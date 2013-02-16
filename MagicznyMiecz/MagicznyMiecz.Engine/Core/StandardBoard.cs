using System.Collections.Generic;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Engine.Core
{
    internal class StandardBoard : IBoard
    {
        private readonly List<IPosition> _innerCircle;
        private readonly List<IPosition> _middleCircle;
        private readonly List<IPosition> _outerCircle;
        
        public StandardBoard()
        {
            this._innerCircle = StandardBoardDefinition.InnerCircle;
            this._middleCircle = StandardBoardDefinition.MiddleCircle;
            this._outerCircle = StandardBoardDefinition.OuterCircle;
        }

        #region IBoard Members

        public IPosition GoFromInnerToMiddle()
        {
            return this._middleCircle[StandardBoardDefinition.LasBlednychOgniId];
        }

        public IPosition GoFromMiddleToOuter()
        {
            return this._outerCircle[StandardBoardDefinition.DolinaCzaszekId];
        }

        public IPosition GoFromMiddleToInner()
        {
            return this._innerCircle[StandardBoardDefinition.UroczyskoId];
        }

        public IPosition GoToSwiatyniaNemed()
        {
            return this._middleCircle[StandardBoardDefinition.SwiatyniaBoginiNemedId];
        }

        public IPosition GoClockwise(IPosition position, int dice)
        {
            int finalPosition = position.Id - dice;

            if (finalPosition < 0)
                finalPosition += position.ActualCircle.Count;

            return position.ActualCircle[finalPosition];
        }

        public IPosition GoCounterClockwise(IPosition position, int dice)
        {
            int finalPosition = (position.Id + dice) % position.ActualCircle.Count;

            return position.ActualCircle[finalPosition];
        }

        #endregion
    }
}
