using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Engine.Core
{
    internal class Item : IItem
    {
        private readonly int _defense;
        private readonly int _magic;
        private readonly int _might;
        private readonly string _name;

        private Item(string name, int might = 0, int magic = 0, int defense = 0)
        {
            this._might = might;
            this._magic = magic;
            this._name = name;
            this._defense = defense;
        }

        #region Implementation of INamedElement

        public string Name
        {
            get { return this._name; }
        }

        #endregion

        #region IItem Members

        public int Might
        {
            get { return this._might; }
        }

        public int Magic
        {
            get { return this._magic; }
        }

        public int Defense
        {
            get { return this._defense; }
        }

        public IItem SetMight(int points)
        {
            return New(this.Name, points, this.Magic, this.Defense);
        }

        public IItem SetMagic(int points)
        {
            return New(this.Name, this.Might, points, this.Defense);
        }

        public IItem SetDefense(int points)
        {
            return New(this.Name, this.Might, this.Magic, points);
        }

        #endregion

        internal static IItem New(string name)
        {
            return new Item(name);
        }

        private static IItem New(string name, int magic, int might, int defense)
        {
            return new Item(name, magic, might, defense);
        }
    }
}
