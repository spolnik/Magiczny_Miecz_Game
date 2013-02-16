namespace MagicznyMiecz.GUI.ViewModels
{
    public class DiceResult
    {
        public DiceResult(int dice)
        {
            this.Dice = dice;
        }
        public int Dice { get; private set; }
    }
}