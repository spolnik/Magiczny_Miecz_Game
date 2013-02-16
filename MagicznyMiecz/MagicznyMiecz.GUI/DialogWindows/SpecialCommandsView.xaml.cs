using System.Collections.Generic;
using System.Windows.Input;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.GUI.DialogWindows
{
    /// <summary>
    /// Interaction logic for SpecialCommandsView.xaml
    /// </summary>
    public partial class SpecialCommandsView
    {
        public List<ISpecialCommand> SpecialCommands { get; private set;}

        public SpecialCommandsView(IEnumerable<ISpecialCommand> specialCommands)
        {
            this.SpecialCommands = new List<ISpecialCommand>(specialCommands);

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
