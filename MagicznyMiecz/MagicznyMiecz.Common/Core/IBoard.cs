namespace MagicznyMiecz.Common.Core
{
    public interface IBoard
    {
        IPosition GoClockwise(IPosition position, int dice);
        IPosition GoCounterClockwise(IPosition position, int dice);

        IPosition GoFromInnerToMiddle();
        IPosition GoFromMiddleToOuter();
        IPosition GoFromMiddleToInner();
        IPosition GoToSwiatyniaNemed();
    }
}