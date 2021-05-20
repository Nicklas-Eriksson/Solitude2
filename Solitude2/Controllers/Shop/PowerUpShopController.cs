using System;
using Solitude2.Views.Player;
using Solitude2.Views.Shop;

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
        }
    }
}
