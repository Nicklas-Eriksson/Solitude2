using Solitude2.Controllers.MenuController;
using Solitude2.Controllers.SystemController;
using Solitude2.Views.Shop;

namespace Solitude2.Controllers.ShopController
{
    internal static class WithdrawGoldController
    {
        internal static bool WithdrawGold(float value)
        {
            var player = StartGameController.CurrentPlayer;
            if (player.Gold < value)
            {
                WithdrawGoldView.NotEnoughGold();
                StoreMenuController.Options();
                return false;
            }

            StartGameController.CurrentPlayer.Gold -= value;
            WithdrawGoldView.WithdrawGold(value);
            return true;
        }
    }
}
