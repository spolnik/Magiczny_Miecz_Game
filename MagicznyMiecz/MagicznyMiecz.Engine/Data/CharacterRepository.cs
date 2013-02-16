using System;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Engine.Data
{
    public class CharacterRepository : Repository<ICharacter>
    {
        #region Overrides of Repository<IItem>

        public override IPlayer Assign(IPlayer player, string name)
        {
            var playerWithCharacter = player.SetCharacter(this.GameRepository[name]);
            this.GameRepository.Remove(name);

            return playerWithCharacter;
        }

        public override IPlayer Detach(IPlayer player, string name)
        {
            if (!string.Equals(player.Character.Name, name))
                throw new ApplicationException("Player has not character with this name.");

            return player.SetCharacter(null);
        }

        #endregion
    }
}
