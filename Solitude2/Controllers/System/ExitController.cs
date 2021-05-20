﻿using System;
using Solitude2.Views.System;

namespace Solitude2.Controllers.System
{
    internal static class ExitController
    {
        internal static void Exit()
        {
            ExitView.ExitGame();
            Environment.Exit(0);
        }
    }
}