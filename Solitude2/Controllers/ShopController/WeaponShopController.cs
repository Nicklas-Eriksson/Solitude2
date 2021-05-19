﻿using System;
using Solitude2.Controllers.SystemController;
using Solitude2.Data;
using Solitude2.Models;
using Solitude2.Utility;
using Solitude2.Views.ShopView;
using System.Linq;
using Solitude2.Views.PlayerView;

namespace Solitude2.Controllers.ShopController
{
    internal static class WeaponShopController
    {
        internal static void Buy()
        {
            var weapons = Facade.DbCommunication.GetWeapons().ToList();
            WeaponShopView.DisplayOptions(weapons);
            DrawStatsView.PlayerStats();
            var weaponIndex = Helper.GetUserInput(weapons.Count) - 1;
            var chosenWeapon = (Weapon) weapons[weaponIndex];
            GrantUserItem(chosenWeapon);
        }

        private static void GrantUserItem(Weapon weapon)
        {
            if (weapon == null) throw new ArgumentNullException(nameof(weapon));
            var db = new MyDbContext();
            var player = StartGameController.CurrentPlayer;
            var success = WithdrawGoldController.WithdrawGold(weapon.Value);

            if (success)
            {
                player.Inventory.Add(weapon);
                db.Update(player);
            }
            else
            {
                //Back to shop + error
            }
        }
    }
}
