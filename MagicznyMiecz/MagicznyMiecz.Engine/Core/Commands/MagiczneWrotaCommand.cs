using System;
using System.Collections.Generic;
using MagicznyMiecz.Common.Core;
using MagicznyMiecz.Common.Data;
using MagicznyMiecz.Engine.Data;

namespace MagicznyMiecz.Engine.Core.Commands
{
    public class MagiczneWrotaCommand : ISpecialCommand
    {
        #region Implementation of ISpecialCommand

        public ISpecialEventResult Execute(IPlayer player)
        {
            ISpecialEventResult result = SpecialEventResult.Create();

            var optionalCommands = new List<ISpecialCommand> {
                                                                 new AddMightPointCommand(),
                                                                 new AddMagicPointCommand(),
                                                                 new AddGoldPointCommand()
                                                             };

            result.OptionalCommands = optionalCommands;

            result.Message = "Wypowiedz ¿yczenie! Mo¿esz zyskaæ do wyboru: 1 punkt Miecza, 1 punkt Magii lub 1 sztukê z³ota.";
            result.Success = true;

            return result;
        }

        public string Name
        {
            get { return "Magiczne Wrota"; }
        }

        #endregion

        #region Nested type: AddGoldPointCommand

        private class AddGoldPointCommand : ISpecialCommand
        {
            #region Implementation of ISpecialCommand

            public ISpecialEventResult Execute(IPlayer player)
            {
                ISpecialEventResult result = SpecialEventResult.Create();

                CommandHelper.AddOnePointOfGold(player);

                result.Message = "Dodano 1 sztukê z³ota !";
                result.Success = true;

                return result;
            }

            public string Name
            {
                get { return "1 Sztuka Z³ota"; }
            }

            #endregion
        }

        #endregion

        #region Nested type: AddMagicPointCommand

        private class AddMagicPointCommand : ISpecialCommand
        {
            #region Implementation of ISpecialCommand

            public ISpecialEventResult Execute(IPlayer player)
            {
                ISpecialEventResult result = SpecialEventResult.Create();

                CommandHelper.AddOnePointOfMagic(player);

                result.Message = "Dodano 1 punkt magii !";
                result.Success = true;

                return result;
            }

            public string Name
            {
                get { return "1 Punkt Magii"; }
            }

            #endregion
        }

        #endregion

        #region Nested type: AddMightPointCommand

        private class AddMightPointCommand : ISpecialCommand
        {
            #region Implementation of ISpecialCommand

            public ISpecialEventResult Execute(IPlayer player)
            {
                ISpecialEventResult result = SpecialEventResult.Create();

                CommandHelper.AddOnePointOfMight(player);

                result.Message = "Dodano 1 punkt miecza !";
                result.Success = true;

                return result;
            }

            public string Name
            {
                get { return "1 Punkt Miecza"; }
            }

            #endregion
        }

        #endregion
    }
}
