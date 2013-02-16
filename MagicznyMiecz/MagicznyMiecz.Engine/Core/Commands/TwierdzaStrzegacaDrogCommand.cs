using System;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class TwierdzaStrzegacaDrogCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();
            var dice = Dice.Throw();
            result.Dices.Add(dice);
            result.Success = false;

            switch (dice)
            {
                case 1:
                    var straznik = StandardCreature.New("Stra¿nik Twierdzy", 8);

                    var fightResult = straznik.Fight(player);

                    result.Success = fightResult.Success;

                    result.Dices.Add(fightResult.PlayerDice);
                    result.Dices.Add(fightResult.CreatureDice);
                    break;
                case 2:
                case 3:
                    var widmo = StandardMagicCreature.New("Widmo Twierdzy", 8);

                    var magicFightResult = widmo.Fight(player);

                    result.Success = magicFightResult.Success;

                    result.Dices.Add(magicFightResult.PlayerDice);
                    result.Dices.Add(magicFightResult.CreatureDice);
                    break;
                case 4:
                case 5:
                    if (player.Character.Gold > 2)
                    {
                        CommandHelper.RemoveManyPointsOfGold(player, 3);
                        result.Success = true;
                    }
                    break;
                case 6:
                    if (player.Character.Gold > 1)
                    {
                        CommandHelper.RemoveManyPointsOfGold(player, 2);
                        result.Success = true;
                    }
                    break;
            }

            if (result.Success)
                player.Game.ItemRepository.Assign(player, ItemRepository.TarczaBogaTolimana);

            result.Message = "W³adca Twierdzy mo¿e wyznaczyæ Ci misjê. Je¿eli siê zdecydowa³eœ rzuæ kostk¹: 1 - pokonaj Stra¿nika Twierdzy (Miecz 8);" +
                             " 2-3 pokonaj Widmo Twierdzy (Magia 8); 4-5 oddaj 3 Sztuki Z³ota; 6 oddaj 2 Sztuki Z³ota. Po wype³nieniu misji, W³adca ofiarujê Ci Tarczê Tolimana";

            return result;
        }

        public string Name
        {
            get { return "Twierdza Strzeg¹ca Dróg"; }
        }

        #endregion
    }
}