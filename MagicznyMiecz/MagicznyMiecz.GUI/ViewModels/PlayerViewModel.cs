using System;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.GUI.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        public IPlayer Player { get; private set; }
        private double _width;
        private double _height;

        public const double DefaultPlayerControlWidth = 800;
        public const double DefaultPlayerControlHeight = 160;

        public PlayerViewModel(IPlayer player)
        {
            this.Player = player;

            this.Width = DefaultPlayerControlWidth;
            this.Height = DefaultPlayerControlHeight;

            this.Bag = new ItemsBagViewModel(this);

        }

        public ItemsBagViewModel Bag { get; private set; }

        public ICharacter Character
        {
            get { return this.Player.Character; }
            set
            {
                this.Player = this.Player.SetCharacter(value);
                this.OnPropertyChanged("Character");
            }
        }

        public IGame Game
        {
            get { return this.Player.Game; }
        }

        public int Id
        {
            get { return this.Player.Id; }
        }

        public string Name
        {
            get { return this.Player.Name; }
        }

        public IPosition Position
        {
            get { return this.Player.Position; }
        }

        public int SkipTurn
        {
            get { return this.Player.Character.SkipTurn; }
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

        public void Update()
        {
            this.OnPropertyChanged("Position");
            this.OnPropertyChanged("SkipTurn");
            this.OnPropertyChanged("Character");
        }
    }
}