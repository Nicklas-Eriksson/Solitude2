using System;
using System.Threading;
using static System.Threading.Thread;

namespace Solitude2.Views.ShopView
{
    internal static class WithdrawGoldView
    {
        internal static void WithdrawGold(float goldWithdrawn)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{goldWithdrawn} gold has been drawn from your pouch.");
            Thread.Sleep(1300);
            Console.ResetColor();
        }

        internal static void NotEnoughGold()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Not enough gold!");
            Sleep(1300);
            Console.ResetColor();
        }
    }
}
