using System.Collections.Generic;
using System.Windows.Input;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;

namespace MagicznyMiecz.GUI.ViewModels
{
    public class SpecialCommandsViewModel : ViewModelBase
    {
        private int _commandIndex;
        public int CommandIndex
        {
            get { return this._commandIndex++; }
        }

        public ISpecialEventResult Result { get; private set; }
        private List<ISpecialCommand> _specialCommands;
        public List<ISpecialCommand> SpecialCommands
        {
            get { return this._specialCommands; }
            set 
            {
                this._specialCommands = new List<ISpecialCommand>(value);
                this._command = null;
                this._commandIndex = 0;
                this.Result = null;
            }
        }

        private ICommand _command;
        public ICommand Command
        {
            get
            {
                if (this._command == null)
                    this._command = new RelayCommand(this.ExecuteSpecialCommand);
                
                UICommandsRepository.Instance.RegisterCommand(
                    "SpecialCommand", this._command);

                return this._command;
            }
        }

        private void ExecuteSpecialCommand(object obj)
        {
            var cmd = (int) obj;

            this.Result = this.SpecialCommands[cmd].Execute(this.Player);
        }

        public IPlayer Player { get; set; }
    }
}