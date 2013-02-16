namespace MagicznyMiecz.Common.Core
{
    public interface IFightResult
    {
        bool Success { get; }
        int PlayerDice { get; }
        int CreatureDice { get; }
        bool IsMagic { get; }
    }
}