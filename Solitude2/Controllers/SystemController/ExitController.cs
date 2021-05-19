using System;
using Solitude2.Views.SystemView;

namespace Solitude2.Controllers.SystemController
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
