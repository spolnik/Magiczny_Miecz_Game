using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Engine.Core;

namespace MagicznyMiecz.GUI.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        private IBoard _board;

        private List<BoardFieldViewModel> _innerRingFields;
        public ObservableCollection<BoardFieldViewModel> InnerRingFields
        {
            get { return new ObservableCollection<BoardFieldViewModel>(this._innerRingFields); }
        }

        private List<BoardFieldViewModel> _middleRingFields;
        public ObservableCollection<BoardFieldViewModel> MiddleRingFields
        {
            get { return new ObservableCollection<BoardFieldViewModel>(this._middleRingFields); }
        }

        private List<BoardFieldViewModel> _outerRingFields;
        public ObservableCollection<BoardFieldViewModel> OuterRingFields
        {
            get { return new ObservableCollection<BoardFieldViewModel>(this._outerRingFields); }
        }


        public BoardViewModel(IBoard board)
        {
            this._board = board;

            this.InintializeRings();
        }

        private void InintializeRings()
        {
            this._outerRingFields = new List<BoardFieldViewModel>();
            this._middleRingFields = new List<BoardFieldViewModel>();
            this._innerRingFields = new List<BoardFieldViewModel>();

            this._outerRingFields.AddRange(StandardBoardDefinition.OuterCircle.Select(x => new BoardFieldViewModel(x)));
            this._middleRingFields.AddRange(StandardBoardDefinition.MiddleCircle.Select(x => new BoardFieldViewModel(x)));
            this._innerRingFields.AddRange(StandardBoardDefinition.InnerCircle.Select(x => new BoardFieldViewModel(x)));
        }

        //internal BoardFieldViewModel GetField(int position, Ring ring)
        //{
        //    switch (ring)
        //    {
        //        case Ring.Inner:
        //            return this._innerRingFields.FirstOrDefault(x => x.Id == position);
        //        case Ring.Middle:
        //            return this._innerRingFields.FirstOrDefault(x => x.Id == position);
        //        case Ring.Outer:
        //            return this._innerRingFields.FirstOrDefault(x => x.Id == position);
        //    }

        //    return null;
        //}

        internal BoardFieldViewModel GetField(IPosition position)
        {
            var result = this._innerRingFields.FirstOrDefault(x => x.Position.Equals(position));

            if (result == null)
                result = this._middleRingFields.FirstOrDefault(x => x.Position.Equals(position));

            if (result == null)
                result = this._outerRingFields.FirstOrDefault(x => x.Position.Equals(position));

            return result;
        }
    }
}