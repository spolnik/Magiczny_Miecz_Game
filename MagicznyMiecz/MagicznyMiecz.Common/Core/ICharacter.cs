using MagicznyMiecz.Common.Utility;

namespace MagicznyMiecz.Common.Core
{
    public interface ICharacter : INamedElement
    {
        int Magic { get; }
        int PureMagic { get; }
        int Might { get; }
        int PureMight { get; }
        int Gold { get; }
        int Life { get; }
        IBag<IItem> Items { get; }
        IPosition StartPosition { get; }
        Nature Nature { get; set; }
        int SkipTurn { get; }
    }
}