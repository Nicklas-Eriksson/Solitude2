using Solitude2.Controllers.SystemController;
using Solitude2.Models;
using System;

namespace Solitude2.Views.PlayerView
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

        internal static void DrawPlayerFrame()
        {
            Console.SetCursorPosition(76, 7);
            Console.WriteLine("╔════════════════════╗");
            Console.SetCursorPosition(76, 8);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(76, 9);
            Console.WriteLine("╠════════════════════╣");
            Console.SetCursorPosition(76, 10);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(76, 11);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(76, 12);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(76, 13);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(76, 14);
            Console.WriteLine("╠════════════════════╣");
            Console.SetCursorPosition(76, 15);
            Console.WriteLine("║     Inventory      ║");
            Console.SetCursorPosition(76, 16);
            Console.WriteLine("╠════════════════════╣");
            Console.SetCursorPosition(76, 17);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(76, 18);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(76, 19);
            Console.WriteLine("╚════════════════════╝");
        }

        internal static void MonsterStats(Monster m)
        {
            DrawMonsterFrame();
            var mName = m.Name;
            float mCurrentHp = m.CurrentHP,
                 mMaxHp = m.MaxHP,
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

            Console.SetCursorPosition(78, 8);
            Console.WriteLine($"{pName}");
            Console.SetCursorPosition(78, 10);
            Console.WriteLine($"Level: {pLvl}");
            Console.SetCursorPosition(78, 11);
            Console.WriteLine($"Health: {pCurrentHp} / {pMaxHp}");
            Console.SetCursorPosition(78, 12);
            Console.WriteLine($"Attack power: {pDmg} ");
            Console.SetCursorPosition(78, 13);
            Console.WriteLine($"Exp: {pCurrentExp} / {pMaxExp}");
            Console.SetCursorPosition(78, 17);
            Console.WriteLine($"Weapon: {pWepName}");
            Console.SetCursorPosition(78, 18);
            Console.WriteLine($"Gold: {pGold}");
        }
    }
}
