using MagicznyMiecz.Common.Data;

namespace MagicznyMiecz.Common.Core
{
    public interface ISpecialCommand
    {
        ISpecialEventResult Execute(IPlayer player);
        string Name { get; }
    }
}