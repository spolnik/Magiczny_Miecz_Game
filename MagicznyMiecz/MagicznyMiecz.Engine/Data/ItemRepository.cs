using System;
using System.Linq;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.Engine.Data
{
    public class ItemRepository : Repository<IItem>
    {
        public const string TarczaBogaTolimana = "Tarcza Boga Tolimana";
        public const string MagicznyMiecz = "Magiczny Miecz";
        public const string Miecz = "Miecz";
        public const string Sztylet = "Sztylet";
        public const string Tarcza = "Tarcza";
        public const string Zbroja = "Zbroja";
        public const string Helm = "He³m";

        #region Overrides of Repository<IItem>

        public override IPlayer Assign(IPlayer player, string name)
        {
            player.Character.Items.Add(this.GameRepository[name]);
            return player;
        }

        public override IPlayer Detach(IPlayer player, string name)
        {
            if (!player.Character.Items.Select(item => item.Name).Contains(name))
                throw new ApplicationException("Player has not character with this name.");

            player.Character.Items.Remove(player.Character.Items.Where(item => string.Equals(item.Name, name)).FirstOrDefault());
            return player;
        }

        #endregion
    }
}