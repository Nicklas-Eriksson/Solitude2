using Solitude2.Views.SetCursorPosition;
using Solitude2.Views.Shop;
using System;

namespace Solitude2.Controllers.Shop
{
    internal static class PowerUpShopController
    {
        /// <summary>
        /// Not yet implemented.
        /// </summary>
        internal static void Buy()
        {
            Console.Clear();
            PowerUpShopView.Buy();
            DrawStatsView.PlayerStats();
            //if (userInput == 999) { StoreMenuController.Options(); }
        }
    }
}
