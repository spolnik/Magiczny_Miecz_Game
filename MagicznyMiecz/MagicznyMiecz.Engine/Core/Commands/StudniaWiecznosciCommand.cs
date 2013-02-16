using System;
using System.Collections.Generic;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Common.Utility;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class StudniaWiecznosciCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            var result = SpecialEventResult.Create();
            result.Success = true;

            if (player.Character.Nature == Nature.Good)
            {
                result.OptionalCommands = new List<ISpecialCommand> {
                                                                        new OdnowZyciaCommand(),
                                                                        new RzutKostkaCommand()
                                                                    };
            }

            result.Message = "Je�eli jeste� dobry to mo�esz odzyska� punkty �ycia z pocz�tku w�dr�wki lub rzuci� kostk�.";

            return result;
        }

        public string Name
        {
            get { return "Studnia wieczno�ci"; }
        }

        #endregion

        class OdnowZyciaCommand : ISpecialCommand
        {
            #region Implementation of ISpecialCommand

            public ISpecialEventResult Execute(IPlayer player)
            {
                var result = SpecialEventResult.Create();
                result.Success = true;

                while (player.Character.Life < 4)
                {
                    CommandHelper.AddOnePointOfLife(player);
                }

                result.Message = "Odnowiono wszystkie �ycia z pocz�tku w�dr�wki.";

                return result;
            }

            public string Name
            {
                get { return "Odn�w �ycia"; }
            }

            #endregion
        }

        class RzutKostkaCommand : ISpecialCommand
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
                    case 4:
                        CommandHelper.AddOnePointOfLife(player);
                        break;
                    case 5:
                        CommandHelper.AddOnePointOfMagic(player);
                        break;
                    case 6:
                        CommandHelper.AddAnotherTurn(player);
                        break;
                }

                result.Message =
                    "1,2,3 - moc wody nie dzia�a na Ciebie; 4 - zyskujesz 1 punkt �ycia; 5 - zyskujesz 1 punkt Magii; 6 - zyskujesz dodatkowy ruch.";

                return result;
            }

            public string Name
            {
                get { return "Rzut Ko�ci�"; }
            }

            #endregion
        }
    }
}