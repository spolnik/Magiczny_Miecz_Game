using System.ComponentModel;
using System.Windows.Input;
using MagicznyMiecz.GUI.ViewModels;

namespace MagicznyMiecz.GUI.DialogWindows
{
    /// <summary>
    /// Interaction logic for AddNewPlayerWindow.xaml
    /// </summary>
    public partial class AddNewPlayerWindow
    {
        //private ShellViewModel _shellViewModel;

        public static AddNewPlayerWindow Instance
        {
            get { return SingletonCreator.Inst; }
        }

        private AddNewPlayerWindow()
        {
            //this.DataContext = this;
            InitializeComponent();
            this.DataContext = this;
            //this.CharacterCount = this._game.CharacterRepository.Count - 1;
        }

        private CharacterPickerViewModel _characterPicker;
        public CharacterPickerViewModel CharacterPicker
        {
            get { return this._characterPicker; }
            internal set
            {
                this._characterPicker = value;
            }
        }

        private ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get { return this._cancelCommand ?? (this._cancelCommand = new RelayCommand(o => this.Hide())); }
        }

        #region Nested type: SingletonCreator

        private static class SingletonCreator
        {
            internal static readonly AddNewPlayerWindow Inst;

            static SingletonCreator()
            {
                Inst = new AddNewPlayerWindow();
            }
        }

        #endregion

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (string.IsNullOrEmpty(this.textBox1.Text)) return;
        //    this.Result = this._game.Register(this.textBox1.Text);
        //    this._game.CharacterRepository.Assign(this.Result, this._game.CharacterRepository.Names[(int) (this.charSlider.Value - 1)]);
        //    this.Close();
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}

        //public string CharacterName
        //{
        //    get { return (string)GetValue(CharacterNameProperty); }
        //    set { SetValue(CharacterNameProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for CharacterName.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CharacterNameProperty =
        //    DependencyProperty.Register("CharacterName", typeof(string), typeof(AddNewPlayerWindow), new UIPropertyMetadata(string.Empty));



        //public int CharacterCount
        //{
        //    get { return (int)GetValue(CharacterCountProperty); }
        //    set { SetValue(CharacterCountProperty, value); }
        //}

        //public IPlayer Result
        //{
        //    get { return this._result; }
        //    set { this._result = value; }
        //}

        //// Using a DependencyProperty as the backing store for CharacterCount.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty CharacterCountProperty =
        //    DependencyProperty.Register("CharacterCount", typeof(int), typeof(AddNewPlayerWindow), new UIPropertyMetadata(0));

        //private void charSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    if (this._game != null)
        //        this.CharacterName = this._game.CharacterRepository.Names[(int) e.NewValue - 1];
        //}

        //public static IPlayer Show(IGame game)
        //{
        //    var window = new AddNewPlayerWindow(game);
        //    window.ShowDialog();
        //    return window.Result;
        //}


        //private IPlayer _result;
    }
}
