using System;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Engine.Core.Commands
{
    internal static class CommandHelper
    {
        internal static void AddOnePointOfLife(IPlayer player)
        {
            ((IEditableCharacter)player.Character).AddLife(1);
        }

        internal static void RemoveOnePointOfLife(IPlayer player)
        {
            ((IEditableCharacter)player.Character).RemoveLife(1);
        }

        internal static void AddOnePointOfMagic(IPlayer player)
        {
            ((IEditableCharacter)player.Character).AddMagic(1);
        }

        internal static void WaitOneTurn(IPlayer player)
        {
            ((Character)player.Character).SkipTurn++;
        }

        internal static void AddAnotherTurn(IPlayer player)
        {
            ((Character)player.Character).SkipTurn--;
        }

        internal static void AddOnePointOfMight(IPlayer player)
        {
            ((IEditableCharacter)player.Character).AddMight(1);
        }

        internal static void RemoveOnePointOfGold(IPlayer player)
        {
            ((IEditableCharacter)player.Character).RemoveGold(1);
        }

        internal static void RemoveManyPointsOfGold(IPlayer player, int value)
        {
            ((IEditableCharacter)player.Character).RemoveGold(value);
        }

        internal static void AddOnePointOfGold(IPlayer player)
        {
            ((IEditableCharacter)player.Character).AddGold(1);
        }

        public static IPlayer GoToSwiatyniaNemed(IPlayer player)
        {
            var position = player.Game.Board.GoToSwiatyniaNemed();
            return player.SetPosition(position);
        }

        public static void AddManyPointsOfLife(IPlayer player, int value)
        {
            ((IEditableCharacter)player.Character).AddLife(value);
        }

        public static void RemoveOnePointOfMight(IPlayer player)
        {
            ((IEditableCharacter)player.Character).RemoveMight(1);
        }

        public static void RemoveManyPointsOfLife(IPlayer player, int value)
        {
            ((IEditableCharacter)player.Character).RemoveLife(value);
        }
    }
}