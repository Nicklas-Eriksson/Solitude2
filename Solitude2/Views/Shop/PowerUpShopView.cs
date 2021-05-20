using System.Collections.Generic;
using Solitude2.Prints;
using Solitude2.Views.Player;

namespace Solitude2.Views.Shop
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
