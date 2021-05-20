using System;
using System.Threading;
using Solitude2.Prints;

namespace Solitude2.Views.System
{
    public static class ExitView
    {
        public static void ExitGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Logotype.Exit();
            Console.WriteLine("Exiting application.");
            Thread.Sleep(2000);
        }
    }
}
