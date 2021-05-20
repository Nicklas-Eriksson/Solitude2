using Solitude2.Prints;
using System;
using System.Collections.Generic;
using Solitude2.Views.PlayerView;

namespace Solitude2.Views.ShopView
{
    public static class PowerUpShopView
    {
        /// <summary>
        /// 3 options
        /// </summary>
        internal static void Buy()
        {
            Logotype.PowerUps();
            Frame.New(new List<string> { "Bonus Health.", "Bonus Damage.", "Main Menu." });
            DrawStatsView.PlayerStats();
        }
    }
}
