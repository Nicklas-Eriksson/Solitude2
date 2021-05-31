using Solitude2.Views.SetCursorPosition;
using Solitude2.Views.Shop;
using System;
using Solitude2.Prints;

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
            Logotype.PowerUps();
            PowerUpShopView.Buy();
            DrawStatsView.PlayerStats();
        }
    }
}
