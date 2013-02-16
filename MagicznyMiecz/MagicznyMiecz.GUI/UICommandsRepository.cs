using System.Collections.Generic;
using System.Windows.Input;

namespace MagicznyMiecz.GUI
{
    public class UICommandsRepository
    {
        private UICommandsRepository()
        {
            this._commands = new Dictionary<string, ICommand>();
        }

        private Dictionary<string, ICommand> _commands;
        public Dictionary<string, ICommand> Commands
        {
            get { return this._commands; }
        }
        
        public static UICommandsRepository Instance
        {
            get { return SingletonCreator.Inst; }
        }

        public void RegisterCommand(string commandName, ICommand command)
        {
            if (this._commands.ContainsKey(commandName))
                this.UnregisterCommand(commandName);

            this._commands.Add(commandName, command);
        }

        public void UnregisterCommand(string commandName)
        {
            this._commands.Remove(commandName);
        }

        #region Nested type: SingletonCreator

        private static class SingletonCreator
        {
            internal static readonly UICommandsRepository Inst;

            static SingletonCreator()
            {
                Inst = new UICommandsRepository();
            }
        }

        #endregion
    }
}