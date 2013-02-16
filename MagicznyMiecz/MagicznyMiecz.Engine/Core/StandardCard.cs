using System;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Engine.Core
{
    internal class StandardCard : ICard
    {
        private readonly Func<IPlayer, IFightResult> _action;

        private StandardCard(CardType cardType, string name, string description, Func<IPlayer, IFightResult> action)
        {
            this.CardType = cardType;
            this.Name = name;
            this.Description = description;
            this._action = action;
        }

        #region ICard Members

        public CardType CardType { get; private set; }

        #endregion

        #region Implementation of INamedElement

        public string Name { get; private set; }

        #endregion

        #region Implementation of ICard

        public string Description { get; private set; }

        public IFightResult Eval(IPlayer player)
        {
            return this._action(player);
        }

        #endregion

        internal static ICard NewWithCreature(string name, string description, Func<IPlayer, IFightResult> expression)
        {
            return new StandardCard(CardType.Creature, name, description, expression);
        }

        internal static ICard NewWithGold(string name, string description, Action<IPlayer> action)
        {
            Func<IPlayer, IFightResult> expression = x =>
                                                     {
                                                         action(x);
                                                         return FightResult.CreateEmpty();
                                                     };

            return new StandardCard(CardType.Gold, name, description, expression);
        }

        internal static ICard NewWithItem(string name, string description, Action<IPlayer> action)
        {
            Func<IPlayer, IFightResult> expression = x =>
                                                     {
                                                         action(x);
                                                         return FightResult.CreateEmpty();
                                                     };

            return new StandardCard(CardType.Item, name, description, expression);
        }
    }
}
