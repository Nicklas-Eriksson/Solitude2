﻿using System;

namespace Solitude2.Views.EncounterView
{
    internal static class FightView
    {
        internal static void DmgDealt(float dmgDealt)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"{dmgDealt} was dealt!");
            Console.ResetColor();
        }
    }
}