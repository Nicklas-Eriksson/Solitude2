using Solitude2.Controllers.Character;
using Solitude2.Models;
using System;
using System.Linq;

namespace Solitude2.Views.SetCursorPosition
{
    internal static class DrawStatsView
    {
        private static int Left, Top;

        internal static void DisplayCombatInformation(Monster m)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            MonsterStats(m);
            PlayerStats();
            Console.ResetColor();
        }

        private static void DrawMonsterFrame()
        {
            Left = 83;
            Top = 7;
            Console.SetCursorPosition(Left, Top);
            Console.WriteLine("╦════════════════════╗");
            Console.SetCursorPosition(Left, Top + 1);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(Left, Top + 2);
            Console.WriteLine("╬════════════════════╣");
            Console.SetCursorPosition(Left, Top + 3);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(Left, Top + 4);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(Left, Top + 5);
            Console.WriteLine("║                    ║");
            Console.SetCursorPosition(Left, Top + 6);
            Console.WriteLine("╠════════════════════╣");
        }

        private static void DrawPlayerFrame()
        {
            Left = 59;
            Top = 7;
            Console.SetCursorPosition(Left, Top);
            Console.WriteLine("╔═══════════════════════╗");
            Console.SetCursorPosition(Left, Top + 1);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(Left, Top + 2);
            Console.WriteLine("╠═══════════════════════╣");
            Console.SetCursorPosition(Left, Top + 3);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(Left, Top + 4);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(Left, Top + 5);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(Left, Top + 6);
            Console.WriteLine("║                       ║");
            Console.SetCursorPosition(Left, Top + 7);
            Console.WriteLine("╠═══════════════════════╬════════════════════════════════╗");
            Console.SetCursorPosition(Left, Top + 8);
            Console.WriteLine("║       Rucksack        ║            Potions             ║");
            Console.SetCursorPosition(Left, Top + 9);
            Console.WriteLine("╠═══════════════════════╬════════════════════════════════╣");
            Console.SetCursorPosition(Left, Top + 10);
            Console.WriteLine("║                       ║                                ║");
            Console.SetCursorPosition(Left, Top + 11);
            Console.WriteLine("║                       ║                                ║");
            Console.SetCursorPosition(Left, Top + 12);
            Console.WriteLine("║                       ║                                ║");
            Console.SetCursorPosition(Left, Top + 13);
            Console.WriteLine("║                       ║                                ║");
            Console.SetCursorPosition(Left, Top + 14);
            Console.WriteLine("╚═══════════════════════╩════════════════════════════════╝");
        }

        private static void MonsterStats(Monster m)
        {
            DrawMonsterFrame();
            var mName = m.Name;
            float mCurrentHp = m.CurrentHp,
                 mMaxHp = m.MaxHp,
                 mDmg = m.Dmg;
            var mLvl = m.Level;
            Left = 85;
            Top = 8;
            Console.SetCursorPosition(Left, Top);
            Console.WriteLine($"{mName}");
            Console.SetCursorPosition(Left, Top + 2);
            Console.WriteLine($"Level: {mLvl}");
            Console.SetCursorPosition(Left, Top + 3);
            Console.WriteLine($"Health: {mCurrentHp} / {mMaxHp}");
            Console.SetCursorPosition(Left, Top + 4);
            Console.WriteLine($"Attack power: {mDmg}");
        }

        internal static void PlayerStats()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            DrawPlayerFrame();
            var p = PlayerController.CurrentPlayer;
            string pName = p.Name,
                pWepName = p.EquippedWeapon.Name;
            float pCurrentHp = p.CurrentHP,
                  pMaxHp = p.MaxHP,
                  pDmg = p.AttackPower + p.EquippedWeapon.Bonus,
                  pCurrentExp = p.CurrentExp,
                  pMaxExp = p.ExpReqForLvl,
                  pGold = p.Gold;
            var pLvl = p.CurrentLvl;
            var potions = p.Inventory.Where(i => i.IsPotion).ToList();
            Left = 61;
            Top = 8;
            //Stats
            Console.SetCursorPosition(Left, Top);
            Console.WriteLine($"{pName}");
            Console.SetCursorPosition(Left, Top + 2);
            Console.WriteLine($"Level: {pLvl}");
            Console.SetCursorPosition(Left, Top + 3);
            Console.WriteLine($"Health: {pCurrentHp} / {pMaxHp}");
            Console.SetCursorPosition(Left, Top + 4);
            Console.WriteLine($"Attack power: {pDmg} ");
            Console.SetCursorPosition(Left, Top + 5);
            Console.WriteLine($"Exp: {pCurrentExp} / {pMaxExp}");

            //Rucksack
            Console.SetCursorPosition(Left, Top + 9);
            Console.WriteLine($"Weapon: {pWepName}");
            Console.SetCursorPosition(Left, Top + 10);
            Console.WriteLine($"Weapon damage: {p.EquippedWeapon.Bonus}");
            Console.SetCursorPosition(Left, Top + 11);
            Console.WriteLine($"Gold: {pGold}");

            Left = 85;
            Top = 17;
            //Potions
            if (potions.Count == 0)
            {
                Console.SetCursorPosition(Left, Top);
                Console.WriteLine("No potions in inventory");
            }
            for (var i = 0; i < potions.Count; i++)
            {
                Console.SetCursorPosition(Left, Top);
                var playerPotions = PlayerController.CurrentPlayer.Inventory.Where(i=>i.IsPotion).Where(p => p.ILvl == i);
                Console.WriteLine($"{playerPotions.Count()}x {potions[i].Name}: +{potions[i].Bonus}HP");
                Top++;
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
