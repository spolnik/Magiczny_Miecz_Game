namespace MagicznyMiecz.Common.Core
{
    public interface IEditableCharacter
    {
        void AddMight(int points);

        void RemoveMight(int points);

        void AddMagic(int points);

        void RemoveMagic(int points);

        void AddGold(int points);

        void RemoveGold(int points);

        void AddLife(int points);

        void RemoveLife(int points);

        void ChangeNature(Nature newCharacterNature);
    }
}