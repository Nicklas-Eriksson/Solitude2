using Solitude2.Controllers.Character;
using Solitude2.Controllers.Menu;
using Solitude2.Data;
using Solitude2.Interfaces;
using Solitude2.Models;
using Solitude2.Utility;
using Solitude2.Views.SetCursorPosition;
using Solitude2.Views.Shop;
using System;
using System.Linq;
using Solitude2.Prints;

namespace Solitude2.Controllers.Shop
{
    internal static class WeaponShopController
    {
        internal static void Buy()
        {
            Console.Clear();
            Logotype.Weapons();
            var weapons = Facade.DbCommunication.GetWeapons().ToList();
            DrawStatsView.PlayerStats();
            WeaponShopView.DisplayOptions(weapons);
            var weaponIndex = Helper.GetUserInput(weapons.Count) - 1;
            var chosenWeapon = weapons[weaponIndex];
            GrantUserItem(chosenWeapon);
        }

        private static void GrantUserItem(IItem weapon)
        {
            if (weapon == null) { return; }
            var db = new MyDbContext();
            var player = PlayerController.CurrentPlayer;
            var success = WithdrawGoldController.WithdrawGold(weapon.Value);

            if (success)
            {
                player.Inventory.Add((Item)weapon);
                db.Update(player);
            }
            StoreMenuController.Options();
        }
    }
}
