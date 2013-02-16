using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.GUI.ViewModels
{
    public class BoardFieldViewModel : ViewModelBase
    {
        private readonly IPosition _position;

        public BoardFieldViewModel(IPosition position)
        {
            this._position = position;

            StandingPlayers = new ObservableCollection<IPlayer>();

            this.Width = DefaultFiledWidth;
            this.Height = DefaultFieldHeight;
        }

        public ObservableCollection<IPlayer> StandingPlayers
        {
            get; private set;
        }

        public bool CanSkip
        {
            get { return this.Position.CanSkip; }
        }

        public IList<ICard> Cards
        {
            get { return this.Position.Cards; }
        }

        public ISpecialCommand Command
        {
            get { return this.Position.Command; }
        }

        public int Id
        {
            get { return this.Position.Id; }
        }

        public IList<IPosition> ActualCircle
        {
            get { return this.Position.ActualCircle; }
        }

        public int NewCarsdsCount
        {
            get { return this.Position.NewCardsCount; }
        }

//        public IPlayer Opponent
//        {
//            get { return this..Opponent; }
//        }

        public BoardState State
        {
            get { return this.Position.State; }
        }

        public double Width
        {
            get { return this._width; }
            set
            {
                this._width = value;
                this.OnPropertyChanged("Width");
            }
        }

        public double Height
        {
            get { return this._height; }
            set
            {
                this._height = value;
                this.OnPropertyChanged("Height");
            }
        }

        public bool PlayerOneStanding
        {
            get { return this._playerOneStanding; }
            set
            {
                this._playerOneStanding = value;
                this.OnPropertyChanged("PlayerOneStanding");
            }
        }

        public bool PlayerTwoStanding
        {
            get { return this._playerTwoStanding; }
            set
            {
                this._playerTwoStanding = value;
                this.OnPropertyChanged("PlayerTwoStanding");
            }
        }

        public bool PlayerThreeStanding
        {
            get { return this._playerThreeStanding; }
            set
            {
                this._playerThreeStanding = value;
                this.OnPropertyChanged("PlayerThreeStanding");
            }
        }

        public bool PlayerFourStanding
        {
            get { return this._playerFourStanding; }
            set
            {
                this._playerFourStanding = value;
                this.OnPropertyChanged("PlayerFourStanding");
            }
        }

        public IPosition Position
        {
            get { return this._position; }
        }

        private double _width;
        private double _height;

        private const double DefaultFiledWidth = 90;
        private const double DefaultFieldHeight = 90;

        private bool _playerOneStanding;
        private bool _playerTwoStanding;
        private bool _playerThreeStanding;
        private bool _playerFourStanding;

    }
}