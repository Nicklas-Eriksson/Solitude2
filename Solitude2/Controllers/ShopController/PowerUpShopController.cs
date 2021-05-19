using Solitude2.Views.PlayerView;
using Solitude2.Views.ShopView;

namespace Solitude2.Controllers.ShopController
{
    internal static class PowerUpShopController
    {
        internal static void Buy()
        {
            PowerUpShopView.Buy();
            DrawStatsView.PlayerStats();
        }
    }
}
