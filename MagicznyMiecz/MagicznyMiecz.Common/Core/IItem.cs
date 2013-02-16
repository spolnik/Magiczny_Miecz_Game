using MagicznyMiecz.Common.Utility;

namespace MagicznyMiecz.Common.Core
{
    public interface IItem : INamedElement
    {
        int Might { get; }
        int Magic { get; }
        int Defense { get; }

        IItem SetMight(int points);
        IItem SetMagic(int points);
        IItem SetDefense(int points);
    }
}