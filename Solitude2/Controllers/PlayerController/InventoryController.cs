using Solitude2.Prints;
using Solitude2.Utility;
using Solitude2.Views.PlayerView;

namespace Solitude2.Controllers.PlayerController
{
    internal static class InventoryController
    {
        internal static void Inventory()
        {
            Logotype.Inventory();
            InventoryView.DisplayInventory(Facade.DbCommunication.GetPlayerInventory());
            DrawStatsView.PlayerStats();
            Helper.PressAnyKeyToContinue();
        }
    }
}
