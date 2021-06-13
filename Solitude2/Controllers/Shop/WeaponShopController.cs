using Solitude2.Controllers.Character;
using Solitude2.Controllers.Menu;
using Solitude2.Data;
using Solitude2.Interfaces;
using Solitude2.Models;
using Solitude2.Utility;
using Solitude2.Views.Shop;
using System;
using System.Linq;
using Solitude2.Views.SetCursorPosition;

namespace Solitude2.Controllers.Shop
{
    internal static class WeaponShopController
    {
        internal static void Buy()
        {
            Console.Clear();
            var weapons = Facade.DbCommunication.GetWeapons().ToList();
            WeaponShopView.DisplayOptions(weapons);
            DrawStatsView.PlayerStats();
            var weaponIndex = Helper.GetUserInput(weapons.Count);
            if (weaponIndex == 999) { StoreMenuController.Options(); }
            var chosenWeapon = weapons[weaponIndex-1];
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
