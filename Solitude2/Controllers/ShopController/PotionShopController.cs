using System.Collections.Generic;
using System.Linq;
using Solitude2.Controllers.MenuController;
using Solitude2.Controllers.SystemController;
using Solitude2.Interfaces;
using Solitude2.Models;
using Solitude2.Utility;
using Solitude2.Views.PlayerView;
using Solitude2.Views.ShopView;

namespace Solitude2.Controllers.ShopController
{
    internal static class PotionShopController
    {
        internal static void Buy()
        {
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
            var potion = (Potion) potions[potionIndex];
            if (player.Gold >= potion.Value)
            {
                player.Potions.Add(potion);
                StartGameController.CurrentPlayer.Inventory.Add(potion);
            }
            else
            {
                WithdrawGoldView.NotEnoughGold();
                StoreMenuController.Options();
            }
        }
        
    }
}
