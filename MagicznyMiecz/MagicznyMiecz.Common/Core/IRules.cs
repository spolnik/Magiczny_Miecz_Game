using MagicznyMiecz.Common.Data;

namespace MagicznyMiecz.Common.Core
{
    public interface IRules
    {
        IPosition GoClockwise(int dice);
        IPosition GoCounterClockwise(int dice);

        IEvalCardsResult EvalCards();

        IFightResult Fight(bool isMagic);
        ISpecialEventResult EvalSpecial();

        void InitRules(IGame game);
    }
}