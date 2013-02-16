using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class PrzeleczWichrowCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();
            var dice = Dice.Throw();
            result.Dices.Add(dice);

            var rycerz = StandardCreature.New("Rycerz Wiecznych �nieg�w", 10);

            var fightResult = rycerz.Fight(player);
            result.Success = fightResult.Success;

            result.Dices.Add(fightResult.PlayerDice);
            result.Dices.Add(fightResult.CreatureDice);

            if (result.Success)
            {
                var position = player.Game.Board.GoFromMiddleToOuter();
                result.Player = player.SetPosition(position);
            }

            result.Message =
                "Nim przeprawisz si� przez Lodowy Las musisz pokona� strzeg�cego Prze��czy Rycerza Wiecznych �nieg�w (Miecz 10). Nie mo�esz kontynuowa� podr�y " +
                "dop�ki walka nie zostanie rozstrzygni�ta. Rycerz pozostanie tu nawet pokonany, lecz nie atakuje je�li przychodzisz z Doliny Czaszek.";

            return result;
        }

        public string Name
        {
            get { return "Prze��cz Wichr�w"; }
        }

        #endregion
    }
}