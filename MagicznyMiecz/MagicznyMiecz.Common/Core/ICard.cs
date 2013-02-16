using MagicznyMiecz.Common.Utility;

namespace MagicznyMiecz.Common.Core
{
    public interface ICard : INamedElement
    {
        string Description { get; }
        CardType CardType { get; }

        IFightResult Eval(IPlayer player);
    }
}