using Microsoft.EntityFrameworkCore;
using Solitude2.Controllers.SystemController;
using Solitude2.Data;
using Solitude2.Interfaces;
using Solitude2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Solitude2.Facade
{
    internal class DbCommunication
    {
        private static readonly MyDbContext Db = new();

        internal static List<Player> SavedGames()
        {
            return Db.Players.Include(p => p.Weapons).Include(p => p.Potions).Include(p=>p.Inventory).ToList();
        }

        internal static List<Item> GetPlayerInventory()
        {
            var playerId = StartGameController.CurrentPlayer.ID;
            
            try
            {
                var player = Db.Players.FirstOrDefault(p=>p.ID == playerId);

                return player.Inventory;
            }
            catch
            {
                return null;
            }
        }

        internal static bool CheckForEmptySeedTables()
        {
            try
            {
                var weapons = Db.Weapons.ToList();
                if (weapons.Count > 0)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        internal static IEnumerable<IItem> GetWeapons()
        {
            try { return Db.Weapons.ToList(); }
            catch { return null; }
        }

        internal static IItem GetWeaponsById(int id)
        {
            try
            {
                var weapon = Db.Weapons.FirstOrDefault(w => w.ID == id);

                return weapon ?? null;
            }
            catch { return null; }
        }

        internal static IEnumerable<IItem> GetPotions()
        {
            try { return Db.Potions.ToList(); }
            catch { return null; }
        }

        internal static IEnumerable<IItem> GetItems()
        {
            try { return Db.Items.ToList(); }
            catch { return null; }
        }

        internal static IEnumerable<IEnemy> GetMonsters()
        {
            try { return Db.Monsters.ToList(); }
            catch { return null; }
        }

        internal static IEnumerable<Player> GetPlayers()
        {
            try { return Db.Players.ToList(); }
            catch { return null; }
        }
    }
}
