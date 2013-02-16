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

            var rycerz = StandardCreature.New("Rycerz Wiecznych Œniegów", 10);

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
                "Nim przeprawisz siê przez Lodowy Las musisz pokonaæ strzeg¹cego Prze³êczy Rycerza Wiecznych Œniegów (Miecz 10). Nie mo¿esz kontynuowaæ podró¿y " +
                "dopóki walka nie zostanie rozstrzygniêta. Rycerz pozostanie tu nawet pokonany, lecz nie atakuje jeœli przychodzisz z Doliny Czaszek.";

            return result;
        }

        public string Name
        {
            get { return "Prze³êcz Wichrów"; }
        }

        #endregion
    }
}