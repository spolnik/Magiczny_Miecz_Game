using System;
using System.Collections.Generic;
using System.Windows;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core;
using MagicznyMiecz.Engine.Data;
using MagicznyMiecz.GUI.DialogWindows;
using MagicznyMiecz.GUI.ViewModels;
using MagicznyMiecz.GUI.Views;

namespace MagicznyMiecz.GUI
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell
    {
        //private readonly Dictionary<IPosition, BoardFieldViewModel> _positions;

        //private IGame _game;

        //private int _lastDiceResult;

        //private readonly List<IPlayer> _players;

        public Shell()
        {
            InitializeComponent();

            //this._players = new List<IPlayer>();

            //this.Loaded += TestLoadedMethod;

            //this._positions = new Dictionary<IPosition, BoardFieldViewModel>();
            //InintializeRings();

            //this.goClockwiseButton.IsEnabled = false;
            //this.goCounterClockwiseButton.IsEnabled = false;
            //this.endTurnButton.IsEnabled = false;
            //this.beginGameButton.IsEnabled = false;
            //this.throwDiceButton.IsEnabled = false;
        }

        void TestLoadedMethod(object sender, RoutedEventArgs e)
        {
            //this._game = GameFactory.Create();

            //this._players.Add(this._game.Register("Player1"));
            //this._players.Add(this._game.Register("Player2"));

            //this._currentPlayer = this._game.CurrentPlayer;

            //var player1View = new playerViewModel(this._players[0]);
            //var player2View = new playerViewModel(this._players[1]);

            //var player1ViewUI = new PlayerView(player1View);
            //var player2ViewUI = new PlayerView(player2View);

            //this.currentPlayerContainer.Content = player1ViewUI;

            //ICardRepository repository = new CardRepository();
            //IRepositoryInitializer<ICard> initalizer = new SimpleCardsRepositoryInitialzier();
            //initalizer.Init((IEditableRepository<ICard>) repository);
        }

        //private void InintializeRings()
        //{
            //foreach (IPosition position in StandardBoardDefinition.InnerCircle)
            //{
            //    var boardFieldView = new BoardFieldViewModel(position);
            //    this._positions.Add(position, boardFieldView);
            //    this.innerRing.Children.Add(new BoardFieldView());
            //}

            //foreach (IPosition position in StandardBoardDefinition.MiddleCircle)
            //{
            //    var boardFieldView = new BoardFieldViewModel(position);
            //    this._positions.Add(position, boardFieldView);
            //    this.middleRing.Children.Add(new BoardFieldView());
            //}
        //}

        //private void AddNewPlayerClicked(object sender, RoutedEventArgs e)
        //{
        //    var player = AddNewPlayerWindow.Show(this._game);
        //    if (player != null) this._players.Add(player);

        //    if (this._players.Count > 1) this.beginGameButton.IsEnabled = true;
        //}

        //private void BeginGameClicked(object sender, RoutedEventArgs e)
        //{
        //    this.AddNewPlayerButton.IsEnabled = false;

        //    if (this._players.Count > 0 && this._players[0] != null) this._positions[this._players[0].Position].PlayerOneStanding = true;
        //    if (this._players.Count > 1 && this._players[1] != null) this._positions[this._players[1].Position].PlayerTwoStanding = true;
        //    if (this._players.Count > 2 && this._players[2] != null) this._positions[this._players[2].Position].PlayerThreeStanding = true;
        //    if (this._players.Count > 3 && this._players[3] != null) this._positions[this._players[3].Position].PlayerFourStanding = true;

        //    this.beginGameButton.IsEnabled = false;

        //    this._game.Start();

        //    var playerView = new PlayerViewModel(this._game.CurrentPlayer);
        //    var playerViewUI = new PlayerView(playerView);

        //    this.currentPlayerContainer.Content = playerViewUI;

        //    this.throwDiceButton.IsEnabled = true;
        //}

        //private void EndTurnClicked(object sender, RoutedEventArgs e)
        //{
        //    this.endTurnButton.IsEnabled = false;

        //    this._game.FinishTurn();

        //    this.cards.Children.Clear();

        //    this.throwDiceButton.IsEnabled = true;
        //}

        //private void ThrowDiceClicked(object sender, RoutedEventArgs e)
        //{
        //    this.throwDiceButton.IsEnabled = false;
        //    this._lastDiceResult = Dice.Throw();
        //    this.diceResultView.Children.Clear();
        //    this.diceResultView.Children.Add(new CubeControl(this._lastDiceResult));

        //    this.goClockwiseButton.IsEnabled = true;
        //    this.goCounterClockwiseButton.IsEnabled = true;
        //}

        //private void GoClockwiseClicked(object sender, RoutedEventArgs e)
        //{
        //    var oldPosition = this._game.CurrentPlayer.Position;
        //    var newPosition = this._game.Board.GoClockwise(oldPosition, this._lastDiceResult);
        //    this._game.Rules.GoClockwise(this._lastDiceResult);

        //    this.UpdatePosition(oldPosition, newPosition);

        //    try
        //    {
        //        this.EvalPosition(newPosition);
        //    }
        //    catch (Exception)
        //    {
        //        this.endTurnButton.IsEnabled = true;
        //        MessageBox.Show("Not yet supported field.");
        //    }
            

        //    this.goClockwiseButton.IsEnabled = false;
        //    this.goCounterClockwiseButton.IsEnabled = false;

        //    this.endTurnButton.IsEnabled = true;
        //}


        //private void GoCounterClockwiseClicked(object sender, RoutedEventArgs e)
        //{
        //    var oldPosition = this._game.CurrentPlayer.Position;
        //    var newPosition = this._game.Board.GoCounterClockwise(oldPosition, this._lastDiceResult);
        //    this._game.Rules.GoCounterClockwise(this._lastDiceResult);

        //    this.UpdatePosition(oldPosition, newPosition);

        //    try
        //    {
        //        this.EvalPosition(newPosition);
        //    }
        //    catch (Exception)
        //    {
        //        this.endTurnButton.IsEnabled = true;
        //        MessageBox.Show("Not yet supported field.");
        //    }

        //    this.goClockwiseButton.IsEnabled = false;
        //    this.goCounterClockwiseButton.IsEnabled = false;

        //    this.endTurnButton.IsEnabled = true;
        //}

        private void UpdatePosition(IPosition oldPosition, IPosition newPosition)
        {
            //switch (this._players.IndexOf(this._game.CurrentPlayer))
            //{
            //    case 0:
            //        this._positions[oldPosition].PlayerOneStanding = false;
            //        this._positions[newPosition].PlayerOneStanding = true;
            //        break;
            //    case 1:
            //        this._positions[oldPosition].PlayerTwoStanding = false;
            //        this._positions[newPosition].PlayerTwoStanding = true;
            //        break;
            //    case 2:
            //        this._positions[oldPosition].PlayerThreeStanding = false;
            //        this._positions[newPosition].PlayerThreeStanding = true;
            //        break;
            //    case 3:
            //        this._positions[oldPosition].PlayerFourStanding = false;
            //        this._positions[newPosition].PlayerFourStanding = true;
            //        break;
            //}
        }
    }
}
