using Solitude2.Controllers.Character;
using Solitude2.Controllers.Menu;
using Solitude2.Interfaces;
using Solitude2.Models;
using Solitude2.Utility;
using Solitude2.Views.SetCursorPosition;
using Solitude2.Views.Shop;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solitude2.Controllers.Shop
{
    internal static class PotionShopController
    {
        internal static void Buy()
        {
            Console.Clear();
            var potions = Facade.DbCommunication.GetPotions().ToList();
            PotionShopView.DisplayPotionMenu();
            PotionShopView.DisplayOptions(potions);
            DrawStatsView.PlayerStats();
            var userInput = Helper.GetUserInput(potions.Count)-1;
            if (userInput == 999) { StoreMenuController.Options(); }
            GrantUserItem(userInput, potions);
        }

        private static void GrantUserItem(int potionIndex, IReadOnlyList<IItem> potions)
        {
            var player = PlayerController.CurrentPlayer;
            var potion = potions[potionIndex];
            if (player.Gold >= potion.Value)
            {
                player.Potions.Add((Item)potion);
                PlayerController.CurrentPlayer.Inventory.Add((Item)potion);
            }
            else
            {
                WithdrawGoldView.NotEnoughGold();
                StoreMenuController.Options();
            }
        }
        
    }
}
