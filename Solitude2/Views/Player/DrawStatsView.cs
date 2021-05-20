using System;
using Solitude2.Controllers.System;
using Solitude2.Models;

namespace Solitude2.Views.Player
{
    internal static class DrawStatsView
    {
        internal static void DisplayCombatInformation(Monster m)
        {
            MonsterStats(m);
            PlayerStats();
        }

        private static void DrawMonsterFrame()
        {
            Console.SetCursorPosition(97, 7);
            Console.WriteLine("╦════════════════════╗");
            Console.SetCursorPosition(97, 8);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(97, 9);
            Console.WriteLine("╬════════════════════╣");
            Console.SetCursorPosition(97, 10);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(97, 11);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(97, 12);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(97, 13);
            Console.WriteLine("╠════════════════════╝");
        }

        private static void DrawPlayerFrame()
        {
            Console.SetCursorPosition(73, 7);
            Console.WriteLine("╔═══════════════════════╗");
            Console.SetCursorPosition(73, 8);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(73, 9);
            Console.WriteLine("╠═══════════════════════╣");
            Console.SetCursorPosition(73, 10);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(73, 11);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(73, 12);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(73, 13);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(73, 14);
            Console.WriteLine("╠═══════════════════════╣");
            Console.SetCursorPosition(73, 15);
            Console.WriteLine("║     Inventory         ║");
            Console.SetCursorPosition(73, 16);
            Console.WriteLine("╠═══════════════════════╣");
            Console.SetCursorPosition(73, 17);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(73, 18);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(73, 19);
            Console.WriteLine("╚═══════════════════════╝");
        }

        private static void MonsterStats(Monster m)
        {
            DrawMonsterFrame();
            var mName = m.Name;
            float mCurrentHp = m.CurrentHp,
                 mMaxHp = m.MaxHp,
                 mDmg = m.Dmg;
            var mLvl = m.Level;

            Console.SetCursorPosition(99, 8);
            Console.WriteLine($"{mName}");
            Console.SetCursorPosition(99, 10);
            Console.WriteLine($"Level: {mLvl}");
            Console.SetCursorPosition(99, 11);
            Console.WriteLine($"Health: {mCurrentHp} / {mMaxHp}");
            Console.SetCursorPosition(99, 12);
            Console.WriteLine($"Attack power: {mDmg}");
        }

        internal static void PlayerStats()
        {
            DrawPlayerFrame();
            var p = StartGameController.CurrentPlayer;
            string pName = p.Name,
                   pWepName = p.EquippedWeapon.Name;
            float pCurrentHp = p.CurrentHP,
                  pMaxHp = p.MaxHP,
                  pDmg = p.AttackPower + p.EquippedWeapon.Bonus,
                  pCurrentExp = p.CurrentExp,
                  pMaxExp = p.ExpReqForLvl,
                  pGold= p.Gold;
            var pLvl = p.CurrentLvl;

            Console.SetCursorPosition(75, 8);
            Console.WriteLine($"{pName}");
            Console.SetCursorPosition(75, 10);
            Console.WriteLine($"Level: {pLvl}");
            Console.SetCursorPosition(75, 11);
            Console.WriteLine($"Health: {pCurrentHp} / {pMaxHp}");
            Console.SetCursorPosition(75, 12);
            Console.WriteLine($"Attack power: {pDmg} ");
            Console.SetCursorPosition(75, 13);
            Console.WriteLine($"Exp: {pCurrentExp} / {pMaxExp}");
            Console.SetCursorPosition(75, 17);
            Console.WriteLine($"Weapon: {pWepName}");
            Console.SetCursorPosition(75, 18);
            Console.WriteLine($"Gold: {pGold}");
        }
    }
}
