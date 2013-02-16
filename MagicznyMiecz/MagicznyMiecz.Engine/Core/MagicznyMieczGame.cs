using System;
using System.Collections.Generic;
using System.Linq;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using Microsoft.Practices.Unity;

namespace MagicznyMiecz.Engine.Core
{
    internal class MagicznyMieczGame : IGame
    {
        private readonly List<IPlayer> _players;
        private GameState _state;

        public MagicznyMieczGame()
        {
            this._players = new List<IPlayer>();
            this._state = GameState.Created;
        }

        #region Implementation of IGame

        [Dependency(GameConstants.CharacterRepositoryName)]
        public IRepository CharacterRepository { get; set; }

        [Dependency]
        public IRepositoryInitializer<ICharacter> CharacterRepositoryInitializer { get; set; }

        [Dependency(GameConstants.ItemRepositoryName)]
        public IRepository ItemRepository { get; set; }

        [Dependency]
        public IRepositoryInitializer<IItem> ItemRepositoryInitializer { get; set; }

        [Dependency(GameConstants.CardRepositoryName)]
        public ICardRepository CardRepository { get; set; }

        [Dependency]
        public IRepositoryInitializer<ICard> CardRepositoryInitializer { get; set; }

        [Dependency]
        public IRules Rules { get; set; }

        [Dependency]
        public IBoard Board { get; set; }

        public IPlayer CurrentPlayer { get; internal set; }

        public IPlayer Register(string playerName)
        {
            if (this._players.Any(p => string.Equals(p.Name, playerName)))
                throw new ApplicationException("Every user must have uniqe name.");

            var player = StandardPlayer.New(playerName, this._players.Count, this);
            this._players.Add(player);

            return player;
        }

        public void UpdatePlayer(IPlayer player)
        {
            this._players[player.Id] = player;
        }

        public IPlayer GetOpponent()
        {
            return this._players.Where(player => player.Position == this.CurrentPlayer.Position).FirstOrDefault();
        }

        public void Start()
        {
            if (this._state != GameState.Initialized)
                throw new ApplicationException("Game is in wrong state.");

            if (this._players.Count < 2)
                throw new ApplicationException("Game must have 2-4 players.");

            if (this._players.Any(player => player.Character == null))
                throw new ApplicationException("All players must choose the own character.");

            this._state = GameState.Started;
            this.CurrentPlayer = this._players[0];
        }

        public void FinishTurn()
        {
            var index = this.CurrentPlayer.Id;
            index++;

            this.CurrentPlayer = this._players[index % this._players.Count];
        }

        #endregion

        internal void Init()
        {
            this.CharacterRepositoryInitializer.Init((IEditableRepository<ICharacter>)this.CharacterRepository);
            this.ItemRepositoryInitializer.Init((IEditableRepository<IItem>)this.ItemRepository);
            this.CardRepositoryInitializer.Init((IEditableRepository<ICard>)this.CardRepository);

            this.Rules.InitRules(this);

            this._state = GameState.Initialized;
        }
    }
}
