using System;
using System.Linq;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Utility;

namespace MagicznyMiecz.Engine.Core
{
    public class Character : ICharacter, IEditableCharacter
    {
        private readonly int _startMagic;
        private readonly int _startMight;

        private Character(string name, IPosition startPosition, Nature nature, int might, int magic)
        {
            this.Name = name;
            this.StartPosition = startPosition;
            this.Nature = nature;

            this.Items = Bag<IItem>.Create();

            this.PureMight = might;
            this.PureMagic = magic;
            this._startMight = might;
            this._startMagic = magic;
            this.Life = GameConstants.LifeOnStart;
            this.Gold = GameConstants.GoldOnStart;
        }

        #region ICharacter Members

        public string Name { get; private set; }

        public int Magic
        {
            get { return this.PureMagic + this.Items.Sum(item => item.Magic); }
        }

        public int Might
        {
            get { return this.PureMight + this.Items.Sum(item => item.Might); }
        }

        public int PureMagic { get; private set; }
        public int PureMight { get; private set; }

        public int Gold { get; private set; }
        public int Life { get; private set; }

        public Nature Nature { get; set; }

        public int SkipTurn { get; internal set; }

        public IBag<IItem> Items { get; internal set; }

        public IPosition StartPosition { get; private set; }

        #endregion

        public static ICharacter Create(string name, IPosition startPosition, Nature nature, int might, int magic)
        {
            return new Character(name, startPosition, nature, might, magic);
        }

        #region Implementation of IEditableCharacter

        void IEditableCharacter.AddMight(int points)
        {
            if (points > GameConstants.MaxAttributePointsToAdd)
                throw new ApplicationException("You want to add to much might points.");

            this.PureMight += points;
        }

        void IEditableCharacter.RemoveMight(int points)
        {
            this.PureMight -= points;

            if (this.PureMight < this._startMight)
                this.PureMight = this._startMight;
        }

        void IEditableCharacter.AddMagic(int points)
        {
            if (points > GameConstants.MaxAttributePointsToAdd)
                throw new ApplicationException("You want to add to much magic points.");

            this.PureMagic += points;
        }

        void IEditableCharacter.RemoveMagic(int points)
        {
            this.PureMagic -= points;

            if (this.PureMagic < this._startMagic)
                this.PureMagic = this._startMagic;
        }

        void IEditableCharacter.AddGold(int points)
        {
            this.Gold += points;
        }

        void IEditableCharacter.RemoveGold(int points)
        {
            if (this.Gold - points < 0)
                throw new ApplicationException("You want remove more gold than player has.");

            this.Gold -= points;
        }

        void IEditableCharacter.AddLife(int points)
        {
            if (points > GameConstants.MaxAttributePointsToAdd)
                throw new ApplicationException("You want to add to much life points.");

            this.Life += points;
        }

        void IEditableCharacter.RemoveLife(int points)
        {
            this.Life -= points;

            if (this.Life <= 0)
                throw new PlayerHasNoLifePointsException();
        }

        void IEditableCharacter.ChangeNature(Nature newCharacterNature)
        {
            this.Nature = newCharacterNature;
        }

        #endregion
    }
}
