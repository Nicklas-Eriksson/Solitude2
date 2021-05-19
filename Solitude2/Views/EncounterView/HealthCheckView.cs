using System;
using static System.Threading.Thread;

namespace Solitude2.Views.EncounterView
{
    internal static class HealthCheckView
    {
        internal static void HealthCheck(string name)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"{name} has died..");
            Sleep(1300);
            Console.ResetColor();
        }
    }
}
