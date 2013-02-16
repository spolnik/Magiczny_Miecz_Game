using System.Collections.Generic;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Core.Commands;

namespace MagicznyMiecz.Engine.Core
{
    public class StandardRules : IRules
    {
        private IGame _game;

        #region Implementation of IRules

        public void InitRules(IGame game)
        {
            this._game = game;
        }

        public IPosition GoClockwise(int dice)
        {
            var position = this._game.Board.GoClockwise(this._game.CurrentPlayer.Position, dice);

            return this.UpdatePositionOfCurrentPlayer(position);
        }

        private IPosition UpdatePositionOfCurrentPlayer(IPosition position)
        {
            ((MagicznyMieczGame)this._game).CurrentPlayer = this._game.CurrentPlayer.SetPosition(this.GetCardsAndSavePosition(position));

            return this._game.CurrentPlayer.Position;
        }

        public IPosition GoCounterClockwise(int dice)
        {
            var position = this._game.Board.GoCounterClockwise(this._game.CurrentPlayer.Position, dice);

            return this.UpdatePositionOfCurrentPlayer(position);
        }

        public IEvalCardsResult EvalCards()
        {
            IList<ICard> actualCards = this._game.CurrentPlayer.Position.Cards;
            IEvalCardsResult result = EvalCardsResult.Create();
            var cardsToRemoveFromPosition = new List<ICard>();

            foreach (ICard actualCard in actualCards)
            {
                result.Cards.Add(actualCard);
                IFightResult fightResult = actualCard.Eval(this._game.CurrentPlayer);

                if (actualCard.CardType == CardType.Creature)
                {
                    result.FightResults.Add(fightResult);

                    if (fightResult.Success)
                        cardsToRemoveFromPosition.Add(actualCard);
                }
                else
                    cardsToRemoveFromPosition.Add(actualCard);
            }

            foreach (ICard card in cardsToRemoveFromPosition)
                this._game.CurrentPlayer.Position.Cards.Remove(card);

            return result;
        }

        public IFightResult Fight(bool isMagic)
        {
            int playerDice = Dice.Throw();
            int opponentDice = Dice.Throw();

            bool isFightWon = isMagic
                                  ? this.GetMagicFightResult(playerDice, opponentDice)
                                  : this.GetMightFightResult(playerDice, opponentDice);

            CommandHelper.RemoveOnePointOfLife(isFightWon ? this._game.GetOpponent() : this._game.CurrentPlayer);

            return FightResult.Create(isFightWon, playerDice, opponentDice, isMagic);
        }

        public ISpecialEventResult EvalSpecial()
        {
            ISpecialCommand command = this._game.CurrentPlayer.Position.Command;
            return command.Execute(this._game.CurrentPlayer);
        }

        #endregion

        private IPosition GetCardsAndSavePosition(IPosition position)
        {
            int numberOfCardsToAdd = position.NewCardsCount - position.Cards.Count;

            for (int i = 0; i < numberOfCardsToAdd; i++)
                position.Cards.Add(this._game.CardRepository.NextCard());

            return position;
        }

        private bool GetMightFightResult(int playerDice, int opponentDice)
        {
            return this._game.CurrentPlayer.Character.Might + playerDice >=
                   this._game.GetOpponent().Character.Might + opponentDice;
        }

        private bool GetMagicFightResult(int playerDice, int opponentDice)
        {
            return this._game.CurrentPlayer.Character.Magic + playerDice >=
                   this._game.GetOpponent().Character.Magic + opponentDice;
        }
    }
}
