using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;

namespace MagicznyMiecz.Engine.Core
{
    public class StandardPlayer : IPlayer
    {
        private readonly ICharacter _character;
        private readonly IGame _game;
        private readonly int _id;
        private readonly string _name;
        private readonly IPosition _position;

        private StandardPlayer(string name, int id, IGame game, ICharacter character, IPosition position)
        {
            this._name = name;
            this._id = id;
            this._game = game;
            this._character = character;
            this._position = position;
        }

        #region Implementation of IPlayer

        public string Name
        {
            get { return this._name; }
        }

        public ICharacter Character
        {
            get { return this._character; }
        }

        public IPlayer SetCharacter(ICharacter character)
        {
            var player = New(this.Name, this.Id, this.Game, character);

            return character.IsNull()
                ? player
                : player.SetPosition(character.StartPosition);
        }

        public IPosition Position
        {
            get { return this._position; }
        }

        public IPlayer SetPosition(IPosition position)
        {
            return New(this.Name, this.Id, this.Game, this.Character, position);
        }

        public IGame Game
        {
            get { return this._game; }
        }

        public int Id
        {
            get { return this._id; }
        }

        #endregion

        internal static IPlayer New(string name, int id, IGame game, ICharacter character = null, IPosition position = null)
        {
            return new StandardPlayer(name, id, game, character, position);
        }
    }
}
