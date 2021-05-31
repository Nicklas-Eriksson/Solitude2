using Solitude2.Controllers.Shop;
using Solitude2.Prints;
using Solitude2.Utility;
using Solitude2.Views.Menu;

namespace Solitude2.Controllers.Menu
{
    internal static class StoreMenuController
    {
        internal static void Options()
        {
            Logotype.IronSkillet();
            StoreMenuView.IronSkillet();
            UserOptions(Helper.GetUserInput(4));
        }

        private static void UserOptions(int userInput)
        {
            switch (userInput)
            {
                case 1:
                    WeaponShopController.Buy();
                    break;
                case 2:
                    PotionShopController.Buy();
                    break;
                case 3:
                    PowerUpShopController.Buy();
                    break;
                case 4:
                    MainMenuController.Options();
                    break;
            }
        }
    }
}
