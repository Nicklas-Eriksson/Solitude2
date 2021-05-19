using Solitude2.Controllers.PlayerController;
using Solitude2.Controllers.SystemController;
using Solitude2.Views.EncounterView;

namespace Solitude2.Controllers.EncounterController
{
    internal static class HealthCheckController
    {
        internal static bool HealthCheck(float hp, string name)
        {
            if (hp > 0) { return true; }
            if (name == StartGameController.CurrentPlayer.Name)
            {
                GameOverController.GameOver();
            }
            HealthCheckView.HealthCheck(name);
            return false;
        }
    }
}
