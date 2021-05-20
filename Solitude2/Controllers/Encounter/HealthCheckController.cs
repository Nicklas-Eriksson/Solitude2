﻿using Solitude2.Controllers.System;
using Solitude2.Views.EncounterView;

namespace Solitude2.Controllers.Encounter
{
    internal static class HealthCheckController
    {
        internal static bool HealthCheck(float hp, string name)
        {
            if (hp > 0) { return true; }
            if (name == StartGameController.CurrentPlayer.Name)
            {
                PlayerController.GameOver();
            }
            HealthCheckView.HealthCheck(name);
            return false;
        }
    }
}