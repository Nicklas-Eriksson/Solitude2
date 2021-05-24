using Solitude2.Controllers.Character;
using Solitude2.Facade;
using Solitude2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solitude2.Views.SetCursorPosition
{
    internal static class DrawStatsView
    {
        private static int Left, Top;

        internal static void DisplayCombatInformation(Monster m)
        {
            MonsterStats(m);
            PlayerStats();
        }

        private static void DrawMonsterFrame()
        {
            Left = 97;
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
            Console.WriteLine("╠════════════════════╝");
        }

        private static void DrawPlayerFrame()
        {
            Left = 73;
            Top = 7;
            Console.SetCursorPosition(73, Top);
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
            Console.WriteLine("╠═══════════════════════════════════════════════╣");
            Console.SetCursorPosition(Left, Top + 8);
            Console.WriteLine("║      Inventory        ║        Potions        ║");
            Console.SetCursorPosition(Left, Top + 9);
            Console.WriteLine("╠═══════════════════════╬═══════════════════════╣");
            Console.SetCursorPosition(Left, Top + 10);
            Console.WriteLine("║                       ║                       ║");
            Console.SetCursorPosition(Left, Top + 11);
            Console.WriteLine("║                       ║                       ║");
            Console.SetCursorPosition(Left, Top + 12);
            Console.WriteLine("║                       ║                       ║");
            Console.SetCursorPosition(Left, Top + 13);
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
        }

        private static void MonsterStats(Monster m)
        {
            DrawMonsterFrame();
            var mName = m.Name;
            float mCurrentHp = m.CurrentHp,
                 mMaxHp = m.MaxHp,
                 mDmg = m.Dmg;
            var mLvl = m.Level;
            Left = 99;
            Top = 8;
            Console.SetCursorPosition(Left, Top);
            Console.WriteLine($"{mName}");
            Console.SetCursorPosition(Left, Top+2);
            Console.WriteLine($"Level: {mLvl}");
            Console.SetCursorPosition(Left, Top+3);
            Console.WriteLine($"Health: {mCurrentHp} / {mMaxHp}");
            Console.SetCursorPosition(Left, Top+4);
            Console.WriteLine($"Attack power: {mDmg}");
        }

        internal static void PlayerStats()
        {
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
            var potions = (List<Item>)DbCommunication.GetPotions();
            Left = 75;
            Top = 8;
            //Stats
            Console.SetCursorPosition(Left, Top);
            Console.WriteLine($"{pName}");
            Console.SetCursorPosition(Left, Top+2);
            Console.WriteLine($"Level: {pLvl}");
            Console.SetCursorPosition(Left, Top + 3);
            Console.WriteLine($"Health: {pCurrentHp} / {pMaxHp}");
            Console.SetCursorPosition(Left, Top + 4);
            Console.WriteLine($"Attack power: {pDmg} ");
            Console.SetCursorPosition(Left, Top + 5);
            Console.WriteLine($"Exp: {pCurrentExp} / {pMaxExp}");
            Console.SetCursorPosition(Left, Top + 8);

            //Inventory
            Console.WriteLine($"Weapon: {pWepName}");
            Console.SetCursorPosition(Left, Top + 9);
            Console.WriteLine($"Gold: {pGold}");

            Left = 97;
            Top = 17;
            //Potions
            for (var i = 0; i < potions.Count; i++)
            {
                var playerPotions = PlayerController.CurrentPlayer.Potions.Where(p => p.ILvl == i);
                Console.WriteLine($"{potions[i].Name}: +{potions[i].Bonus}HP. {playerPotions.Count()}pcs");
                Console.SetCursorPosition(Left, Top);
                Top++;
            }
        }
    }
}
