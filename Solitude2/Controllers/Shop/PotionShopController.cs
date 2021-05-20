﻿using System;
using System.Collections.Generic;
using System.Linq;
using Solitude2.Controllers.Menu;
using Solitude2.Controllers.System;
using Solitude2.Interfaces;
using Solitude2.Models;
using Solitude2.Utility;
using Solitude2.Views.Player;
using Solitude2.Views.Shop;

namespace Solitude2.Controllers.Shop
{
    internal static class PotionShopController
    {
        internal static void Buy()
        {
            Console.Clear();
            PotionShopView.Buy();
            DrawStatsView.PlayerStats();
            var potions = Facade.DbCommunication.GetPotions().ToList();
            PotionShopView.DisplayInventory(potions);
            var userInput = Helper.GetUserInput(potions.Count)-1;
            GrantUserItem(userInput, potions);
        }

        private static void GrantUserItem(int potionIndex, List<IItem> potions)
        {
            var player = StartGameController.CurrentPlayer;
            var potion = potions[potionIndex];
            if (player.Gold >= potion.Value)
            {
                player.Potions.Add((Item)potion);
                StartGameController.CurrentPlayer.Inventory.Add((Item)potion);
            }
            else
            {
                WithdrawGoldView.NotEnoughGold();
                StoreMenuController.Options();
            }
        }
        
    }
}