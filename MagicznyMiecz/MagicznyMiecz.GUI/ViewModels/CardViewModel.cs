using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.GUI.ViewModels
{
    public class CardViewModel : ViewModelBase
    {
        private const double DefaultCardWidth = 140;
        private const double DefaultCardHeight = 240;

        private readonly ICard _card;

        public string Description { get { return this._card.Description; } }
        public string Name { get { return this._card.Name; } }

        public CardViewModel(ICard card)
        {
            this._card = card;

            this.Width = DefaultCardWidth;
            this.Height = DefaultCardHeight;
        }

        public void Eval(IPlayer player)
        {
            this._card.Eval(player);
        }

        private double _width;
        public double Width
        {
            get { return this._width; }
            set
            {
                this._width = value;
                this.OnPropertyChanged("Width");
            }
        }

        private double _height;
        public double Height
        {
            get { return this._height; }
            set
            {
                this._height = value;
                this.OnPropertyChanged("Height");
            }
        }

        private string _imageSource;
        public string ImageSource
        {
            get { return this._imageSource; }
            set
            {
                this._imageSource = value;
                this.OnPropertyChanged("ImageSource");
            }
        }
    }
}