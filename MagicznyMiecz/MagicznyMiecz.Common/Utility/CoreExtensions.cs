using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Common.Utility
{
    public static class CoreExtensions
    {
        public static bool IsNull(this ICharacter character)
        {
            return character == null;
        }
    }
}