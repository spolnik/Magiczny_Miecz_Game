using System;
using System.Collections.Generic;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.GUI.ViewModels
{
    public class CharacterPickerViewModel : ViewModelBase
    {
        private readonly IGame _game;
        private readonly List<string> _characters;
        private readonly Dictionary<int, string> _indexToImagePath;
        
        public const string UnknownCharacter = "Unknown";

        private int _selectedIndex;
        public int SelectedIndex
        {
            get { return this._selectedIndex; }
            set
            {
                this._selectedIndex = value;
                this.OnPropertyChanged("SelectedIndex");
                this.OnPropertyChanged("SelectedImage");
                this.OnPropertyChanged("SelectedName");
            }
        }

        private string _selectedName;
        public string SelectedName
        {
            get { return this._selectedName; }
            set
            {
                this._selectedName = value;
                this.OnPropertyChanged("SelectedName");
            }
        }

        public string SelectedImage
        {
            get { return this._indexToImagePath[0]; }
            //get { return this._indexToImagePath[this._selectedIndex]; }
            //set
            //{
            //    this._selectedImage = value;
            //    this.OnPropertyChanged("SelectedImage");
            //}
        }

        public CharacterPickerViewModel(IGame game)
        {
            this._game = game;

            this._characters = new List<string>(this._game.CharacterRepository.Names);
            this._indexToImagePath = new Dictionary<int, string>();

            this._selectedIndex = 0;
            this._selectedName = UnknownCharacter;

            this.RegisterImages();

            this.RegisterCommands();
        }

        private void RegisterImages()
        {
            this._indexToImagePath.Add(0, "../Images/unknown.jpg");
        }

        private void RegisterCommands()
        {
            UICommandsRepository.Instance.RegisterCommand(
                "LeftChangeCharacterCommand",
                new RelayCommand(this.ExecuteLeftChangeCharacterCommand, this.CanExecuteLeftChangeCharacterCommand));
            UICommandsRepository.Instance.RegisterCommand(
                "RightChangeCharacterCommand",
                new RelayCommand(this.ExecuteRightChangeCharacterCommand, this.CanExecuteRightChangeCharacterCommand));
        }

        private void ExecuteLeftChangeCharacterCommand(object obj)
        {
            this.SelectedIndex--;
            this.SelectedName = this.SelectedIndex == 0 ? UnknownCharacter : this._characters[this.SelectedIndex];
        }

        private bool CanExecuteLeftChangeCharacterCommand(object obj)
        {
            return this._selectedIndex > 0;
        }

        private void ExecuteRightChangeCharacterCommand(object obj)
        {
            this.SelectedIndex++;
            this.SelectedName = this._characters[this.SelectedIndex - 1];
        }

        private bool CanExecuteRightChangeCharacterCommand(object obj)
        {
            return this._selectedIndex < this._characters.Count;
        }
    }
}