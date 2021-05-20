using Solitude2.Controllers.Menu;
using Solitude2.Controllers.System;
using Solitude2.Views.Shop;

namespace Solitude2.Controllers.Shop
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
