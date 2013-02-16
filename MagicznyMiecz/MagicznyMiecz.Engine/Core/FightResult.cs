using System;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Engine.Core
{
    public class FightResult : IFightResult
    {
        private FightResult(bool success, int playerDice, int creatureDice, bool isMagic)
        {
            this.Success = success;
            this.PlayerDice = playerDice;
            this.CreatureDice = creatureDice;
            this.IsMagic = isMagic;
        }

        #region Implementation of IFightResult

        public bool Success { get; private set; }
        public int PlayerDice { get; private set; }
        public int CreatureDice { get; private set; }
        public bool IsMagic { get; private set; }

        #endregion

        public static FightResult Create(bool success, int playerDice, int opponentDice, bool isMagic)
        {
            return new FightResult(success, playerDice, opponentDice, isMagic);
        }

        public static IFightResult CreateEmpty()
        {
            return null;
        }
    }
}
