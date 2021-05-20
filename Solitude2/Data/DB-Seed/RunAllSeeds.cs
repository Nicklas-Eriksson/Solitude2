using System;

namespace Solitude2.Data
{
    internal static class RunAllSeeds
    {
        internal static bool CreateItems()
        {
            try
            {
                WeaponSeed.WeaponForge();
                ItemSeed.ItemForge();
                PotionSeed.PotionForge();
                MonsterSeed.MonsterForge();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
