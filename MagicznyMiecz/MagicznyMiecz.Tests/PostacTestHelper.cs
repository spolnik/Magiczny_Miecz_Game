using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Engine.Core;

namespace MagicznyMiecz.Tests
{
    public static class PostacTestHelper
    {
        internal const string GoodCharacterName = "GoodCharacter";
        internal const string ChaoticCharacterName = "ChaoticCharacter";
        internal const string BadCharacterName = "BadCharacter";

        internal const int DefaultValue = 4;

        private static IPosition GetDefaultPosition()
        {
            return StandardBoardDefinition.InnerCircle[StandardBoardDefinition.GrodId];
        }

        public static ICharacter GetGoodCharacter()
        {
            return Character.Create(GoodCharacterName, GetDefaultPosition(), Nature.Good, DefaultValue, DefaultValue);
        }

        public static ICharacter GetChaoticCharacter()
        {
            return Character.Create(ChaoticCharacterName, GetDefaultPosition(), Nature.Chaotic, DefaultValue, DefaultValue);
        }

        public static ICharacter GetBadCharacter()
        {
            return Character.Create(BadCharacterName, GetDefaultPosition(), Nature.Bad, DefaultValue, DefaultValue);
        }
    }
}