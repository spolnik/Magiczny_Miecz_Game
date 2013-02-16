using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Data;
using MagicznyMiecz.GUI.DialogWindows;

namespace MagicznyMiecz.GUI.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private Window _currentDialog;

        private readonly IGame _game;
        private DiceResult _lastDiceResult;

        public List<PlayerViewModel> Players { get; private set; }
        public ObservableCollection<CardViewModel> Cards { get; private set; }

        private bool _gameStarted;
        private bool _waitingForMovementDecision;

        private readonly CharacterPickerViewModel _characterPicker;
        private bool _playerHasNothingToDo;
        private bool _throwDicePhase;

        private PlayerViewModel _currentPlayer;
        public PlayerViewModel CurrentPlayer
        {
            get { return this._currentPlayer; }
            private set
            {
                this._currentPlayer = value;
                this.OnPropertyChanged("CurrentPlayer");
            }
        }

        public ObservableCollection<DiceResult> DiceResults { get; private set; }

        public BoardViewModel Board { get; private set; }

        public ShellViewModel()
        {
            this.RegisterCommands();

            this._game = GameFactory.Create();
            new SimpleCardsRepositoryInitialzier().Init(new CardRepository());

            this.Players = new List<PlayerViewModel>();

            this.Board = new BoardViewModel(this._game.Board);

            this._characterPicker = new CharacterPickerViewModel(this._game);

            this.Cards = new ObservableCollection<CardViewModel>();

            this.DiceResults = new ObservableCollection<DiceResult>();

            this._gameStarted = false;

            this._playerHasNothingToDo = false;

            this._throwDicePhase = false;
        }

        private void RegisterCommands()
        {

            UICommandsRepository.Instance.RegisterCommand("AddNewPlayerCommand",
                                         new RelayCommand(this.ExecuteAddNewPlayerCommand,
                                                          this.CanExecuteAddNewPlayerCommand));
            UICommandsRepository.Instance.RegisterCommand("BeginGameCommand",
                                                          new RelayCommand(this.ExecuteBeginGameCommand,
                                                                           this.CanExecuteBeginGameCommand));
            UICommandsRepository.Instance.RegisterCommand("ThrowDiceCommand",
                                                          new RelayCommand(this.ExecuteThrowDiceCommand,
                                                                           this.CanExecuteThrowDiceCommand));
            UICommandsRepository.Instance.RegisterCommand("GoClockwiseCommand",
                                                          new RelayCommand(this.ExecuteGoClockwiseCommand,
                                                                           this.CanExecuteGoClockwiseCommand));
            UICommandsRepository.Instance.RegisterCommand("GoCounterclockwiseCommand",
                                                          new RelayCommand(this.ExecuteGoCounterclockwiseCommand,
                                                                           this.CanExecuteGoCounterclockwiseCommand));
            UICommandsRepository.Instance.RegisterCommand("EndTurnCommand",
                                                          new RelayCommand(this.ExecuteEndTurnCommand,
                                                                           this.CanExecuteEndTurnCommand));
            UICommandsRepository.Instance.RegisterCommand("PickCharacterCommand",
                                                          new RelayCommand(this.ExecutePickCharacterCommand,
                                                                           this.CanExecutePickCharacterCommand));
            UICommandsRepository.Instance.RegisterCommand("SpecialCommand",
                new RelayCommand(this.ExecuteSpecialCommand));
            UICommandsRepository.Instance.RegisterCommand("FightCommand",
                new RelayCommand(this.ExecuteFightCommand));
        }

        private void ExecuteAddNewPlayerCommand(object obj)
        {
            var dialog = AddNewPlayerWindow.Instance;
            this.ClearCharacterPicker();
            dialog.CharacterPicker = this._characterPicker;
            dialog.ShowDialog();
        }

        private void ExecuteBeginGameCommand(object obj)
        {
            this._gameStarted = true;

            this._game.Start();

            this.CurrentPlayer = this.Players.FirstOrDefault(p => p.Player == this._game.CurrentPlayer);

            foreach (var player in this.Players)
                this.PutPlayerAtPosition(player.Player, player.Position);

            this._throwDicePhase = true;
        }

        private void ExecuteThrowDiceCommand(object obj)
        {
            this._lastDiceResult = new DiceResult(Dice.Throw());

            this.DiceResults.Add(this._lastDiceResult);

            this._waitingForMovementDecision = true;
            this._playerHasNothingToDo = false;
            this._throwDicePhase = false;
        }

        private void ExecuteGoClockwiseCommand(object obj)
        {
            this.RemovePlayerFromPosition(this._game.CurrentPlayer, this._game.CurrentPlayer.Position);

            //this._game.Board.GoClockwise(this._game.CurrentPlayer.Position, this._lastDiceResult.Dice);
            var newPosition = this._game.Rules.GoClockwise(this._lastDiceResult.Dice);

            this.PutPlayerAtPosition(this._game.CurrentPlayer, newPosition);

            this.EvalPosition(newPosition);


            this._waitingForMovementDecision = false;
            this._playerHasNothingToDo = true;
        }

        private void EvalPosition(IPosition newPosition)
        {
            this.CheckOpponent();

            var beforeEvalosition = newPosition;

            IEvalCardsResult cardsResult = null;
            ISpecialEventResult eventResult = null;

            try
            {
                if (newPosition.State == BoardState.Special)
                    eventResult = this._game.Rules.EvalSpecial();
                else if (newPosition.State == BoardState.Cards)
                    cardsResult = this._game.Rules.EvalCards();
                else
                {
                    cardsResult = this._game.Rules.EvalCards();
                    eventResult = this._game.Rules.EvalSpecial();
                }

                if (cardsResult != null)
                {
                    foreach (ICard card in cardsResult.Cards)
                        this.Cards.Add(new CardViewModel(card));
                }

                if (eventResult != null )
                {
                    MessageBox.Show(eventResult.Message, newPosition.Command.Name);

                    this.DiceResults.Clear();

                    foreach (int dice in eventResult.Dices)
                        this.DiceResults.Add(new DiceResult(dice));

                    if (eventResult.OptionalCommands != null)
                    {
                        //MessageBox.Show(eventResult.Message, newPosition.Command.Name);

                        var dialog = new SpecialCommandsView(eventResult.OptionalCommands);
                        this._currentDialog = dialog;
                        dialog.ShowDialog();
                    }
                }

                var afterEvalPosition = this._game.CurrentPlayer.Position;

                if (beforeEvalosition != afterEvalPosition)
                {
                    this.RemovePlayerFromPosition(this._game.CurrentPlayer, beforeEvalosition);
                    this.PutPlayerAtPosition(this._game.CurrentPlayer, afterEvalPosition);
                }

                this.CurrentPlayer.Update();
            }
            catch (PlayerHasNoLifePointsException)
            {
                MessageBox.Show(this._game.CurrentPlayer.Name + " - YOU LOST!");
                this._gameStarted = false;
            }
        }

        private void CheckOpponent()
        {
            if (this._game.GetOpponent() == null) 
                return;
            
            var dialog = new FightCommandsView();
            this._currentDialog = dialog;
            dialog.ShowDialog();
        }

        private void ExecuteGoCounterclockwiseCommand(object obj)
        {
            this.RemovePlayerFromPosition(this._game.CurrentPlayer, this._game.CurrentPlayer.Position);

            //this._game.Board.GoCounterClockwise(this._game.CurrentPlayer.Position, this._lastDiceResult.Dice);
            var newPosition = this._game.Rules.GoCounterClockwise(this._lastDiceResult.Dice);

            this.PutPlayerAtPosition(this._game.CurrentPlayer, newPosition);

            this.EvalPosition(newPosition);

            this._waitingForMovementDecision = false;
            this._playerHasNothingToDo = true;
        }

        private void ExecuteEndTurnCommand(object obj)
        {
            this.DiceResults.Clear();

            this.Cards.Clear();

            this._waitingForMovementDecision = false;

            this._playerHasNothingToDo = false;

            this._game.FinishTurn();

            this.CurrentPlayer = this.Players.FirstOrDefault(p => p.Player == this._game.CurrentPlayer);

            this._throwDicePhase = true;
        }

        private void ExecutePickCharacterCommand(object obj)
        {
            var name = obj as string;

            var player = this._game.Register(name);
            this._game.CharacterRepository.Assign(player, this._characterPicker.SelectedName);

            this.Players.Add(new PlayerViewModel(player));

            //this.CanBeginGame = this._players.Count > 1;

            AddNewPlayerWindow.Instance.Hide();
        }

        private void ExecuteSpecialCommand(object obj)
        {
            var cmdName = obj as string;

            if (string.IsNullOrEmpty(cmdName)) return;

            var cmd =
                ((SpecialCommandsView)this._currentDialog).SpecialCommands.FirstOrDefault(x => x.Name.Equals(cmdName));

            if (cmd == null) throw new Exception("Wrong Command!!!");

            var eventResult = cmd.Execute(this._game.CurrentPlayer);

            if (eventResult != null && eventResult.OptionalCommands != null)
            {
                if (this._currentDialog != null) this._currentDialog.Close();

                var dialog = new SpecialCommandsView(eventResult.OptionalCommands);
                this._currentDialog = dialog;
                dialog.ShowDialog();
            }

            if (this._currentDialog != null)
                this._currentDialog.Close();
            this._currentDialog = null;
        }

        private void ExecuteFightCommand(object obj)
        {
            var isMagic = (obj as string) == "Magic";

            var result = this._game.Rules.Fight(isMagic);

            var title = result.IsMagic ? "Walka Magiczna" : "Walka";

            var msg = "Rzut gracza : " + result.PlayerDice + Environment.NewLine +
                      "Rzut wroga : " + result.CreatureDice;

            MessageBox.Show(msg, title);

            this._currentDialog.Close();
            this._currentDialog = null;
        }

        private bool CanExecuteAddNewPlayerCommand(object obj)
        {
            return !this._gameStarted;
        }

        private bool CanExecuteBeginGameCommand(object obj)
        {
            //return this.CanBeginGame && !this.GameStarted;
            return !this._gameStarted && this.Players.Count > 1;
        }

        private bool CanExecuteThrowDiceCommand(object obj)
        {
            return this._gameStarted && !this._waitingForMovementDecision && this._throwDicePhase;
        }

        private bool CanExecuteGoClockwiseCommand(object obj)
        {
            return this._waitingForMovementDecision;
        }

        private bool CanExecuteGoCounterclockwiseCommand(object obj)
        {
            return this._waitingForMovementDecision;
        }

        private bool CanExecuteEndTurnCommand(object obj)
        {
            return this._playerHasNothingToDo;
        }

        private bool CanExecutePickCharacterCommand(object obj)
        {
            var name = obj as string;
            return !string.IsNullOrEmpty(name) && this._characterPicker.SelectedName != CharacterPickerViewModel.UnknownCharacter;
        }

        private void ClearCharacterPicker()
        {
            AddNewPlayerWindow.Instance.playerNameTextBox.Clear();
            this._characterPicker.SelectedIndex = 0;
            this._characterPicker.SelectedName = CharacterPickerViewModel.UnknownCharacter;
        }

        private void RemovePlayerFromPosition(IPlayer player, IPosition position)
        {
            var fielViewModel = this.Board.GetField(position);

            fielViewModel.StandingPlayers.Remove(player);
        }

        private void PutPlayerAtPosition(IPlayer player, IPosition position)
        {
            var fieldViewModel = this.Board.GetField(position);

            fieldViewModel.StandingPlayers.Add(player);
        }
    }
}