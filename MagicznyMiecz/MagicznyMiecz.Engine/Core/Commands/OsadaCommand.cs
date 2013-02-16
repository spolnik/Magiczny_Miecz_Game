using System;
using System.Collections.Generic;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class OsadaCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();

            result.OptionalCommands = new List<ISpecialCommand> {
                                                                    new CzarownicaCommand(),
                                                                    new PlatnerzCommand(),
                                                                    new MedykCommand()
                                                                };

            result.Message = "Mo�esz tu odwiedzi�: Czarownic�, P�atnerza, Medyka.";

            return result;
        }

        public string Name
        {
            get { return "Osada"; }
        }

        #endregion

        class CzarownicaCommand : ISpecialCommand
        {
            #region Implementation of ISpecialCommand

            public ISpecialEventResult Execute(IPlayer player)
            {
                var result = SpecialEventResult.Create();
                result.Success = true;
                
                var dice = Dice.Throw();
                result.Dices.Add(dice);

                switch (dice)
                {
                    case 1:
                    case 2:
                        CommandHelper.RemoveOnePointOfMight(player);
                        break;
                    case 3:
                    case 4:
                        CommandHelper.AddOnePointOfMight(player);
                        break;
                    case 5:
                        CommandHelper.AddOnePointOfMagic(player);
                        break;
                }

                result.Message =
                    "Rzu� kostk� 1,2 - tracisz 1 punkt Miecza; 3,4 - zyskujesz 1 punkt Miecza; 5 - zyskujesz 1 punkt Magii; 6 - zosta�e� zignorowany.";

                return result;
            }

            public string Name
            {
                get { return "Czarownica"; }
            }

            #endregion
        }

        class PlatnerzCommand : ISpecialCommand
        {
            #region Implementation of ISpecialCommand

            public ISpecialEventResult Execute(IPlayer player)
            {
                var result = SpecialEventResult.Create();
                result.Success = true;

                result.OptionalCommands = new List<ISpecialCommand> {
                                                                        new MieczCommand(),
                                                                        new SztyletCommand(),
                                                                        new HelmCommand()
                                                                    };

                result.Message = "U p�atnerza mo�esz kupi�: za 2 Sz. Z. miecz; sztylet za 3 Sz. Z.; he�m - 1 Sz. Z.";

                return result;
            }

            public string Name
            {
                get { return "P�atnerz"; }
            }

            #endregion

            class MieczCommand : ISpecialCommand
            {
                #region Implementation of ISpecialCommand

                public ISpecialEventResult Execute(IPlayer player)
                {
                    var result = SpecialEventResult.Create();
                    result.Success = true;

                    if (player.Character.Gold > 1)
                    {
                        CommandHelper.RemoveManyPointsOfGold(player, 2);
                        player.Game.ItemRepository.Assign(player, ItemRepository.Miecz);

                        result.Message = "Kupiono miecz";
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Gracz nie ma 2 sztuk z�ota na zakup miecza";
                    }

                    return result;
                }

                public string Name
                {
                    get { return "Miecz"; }
                }

                #endregion
            }

            class SztyletCommand : ISpecialCommand
            {
                #region Implementation of ISpecialCommand

                public ISpecialEventResult Execute(IPlayer player)
                {
                    var result = SpecialEventResult.Create();
                    result.Success = true;

                    if (player.Character.Gold > 2)
                    {
                        CommandHelper.RemoveManyPointsOfGold(player, 3);
                        player.Game.ItemRepository.Assign(player, ItemRepository.Sztylet);

                        result.Message = "Kupiono sztylet";
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Gracz nie ma 3 sztuk z�ota na zakup sztyletu";
                    }

                    return result;
                }

                public string Name
                {
                    get { return "Sztylet"; }
                }

                #endregion
            }

            class HelmCommand : ISpecialCommand
            {
                #region Implementation of ISpecialCommand

                public ISpecialEventResult Execute(IPlayer player)
                {
                    var result = SpecialEventResult.Create();
                    result.Success = true;

                    if (player.Character.Gold > 0)
                    {
                        CommandHelper.RemoveOnePointOfGold(player);
                        player.Game.ItemRepository.Assign(player, ItemRepository.Helm);

                        result.Message = "Kupiono he�m";
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "Gracz nie ma 1 sztuki z�ota na zakup he�mu";
                    }

                    return result;
                }

                public string Name
                {
                    get { return "He�m"; }
                }

                #endregion
            }
        }

        class MedykCommand : ISpecialCommand
        {
            #region Implementation of ISpecialCommand

            public ISpecialEventResult Execute(IPlayer player)
            {
                var result = SpecialEventResult.Create();
                result.Success = true;

                while (player.Character.Life < 4)
                {
                    if (player.Character.Gold == 0)
                        break;

                    CommandHelper.RemoveOnePointOfGold(player);
                    CommandHelper.AddOnePointOfLife(player);
                }

                result.Message = "Medyk za ka�d� Sztuk� Z�ota przywr�ci Ci 1 punkt �ycia.";

                return result;
            }

            public string Name
            {
                get { return "Medyk"; }
            }

            #endregion
        }
    }
}