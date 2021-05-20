using System;
using Solitude2.Views.PlayerView;
using Solitude2.Views.ShopView;

namespace Solitude2.Controllers.ShopController
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
