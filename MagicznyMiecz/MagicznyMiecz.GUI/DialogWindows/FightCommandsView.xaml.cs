using System.Collections.Generic;
using System.Windows.Input;

namespace MagicznyMiecz.GUI.DialogWindows
{
    /// <summary>
    /// Interaction logic for SpecialCommandsView.xaml
    /// </summary>
    public partial class FightCommandsView
    {
        public FightCommandsView()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private ICommand _nothingCommand;
        public ICommand NothingCommand
        {
            get { return this._nothingCommand ?? (this._nothingCommand = new RelayCommand(o => this.Close())); }
        }
    }
}
