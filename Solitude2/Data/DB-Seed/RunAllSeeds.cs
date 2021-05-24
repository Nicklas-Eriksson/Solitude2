using System;

namespace Solitude2.Data
{
    internal static class RunAllSeeds
    {
        internal static void CreateItems()
        {
            try
            {
                WeaponSeed.WeaponForge();
                ItemSeed.ItemForge();
                PotionSeed.PotionForge();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
