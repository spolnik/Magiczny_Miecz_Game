using MagicznyMiecz.Common.Utility;

namespace MagicznyMiecz.Common.Core
{
    public interface ICreature : INamedElement
    {
        int Value { get; }

        IFightResult Fight(IPlayer player);
    }
}