namespace MagicznyMiecz.Common.Core
{
    public interface IPlayer
    {
        string Name { get; }
        ICharacter Character { get; }
        IPosition Position { get; }
        IGame Game { get; }
        int Id { get; }

        IPlayer SetCharacter(ICharacter character);
        IPlayer SetPosition(IPosition position);
    }
}