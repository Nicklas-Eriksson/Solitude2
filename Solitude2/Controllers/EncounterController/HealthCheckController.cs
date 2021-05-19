using Solitude2.Views.EncounterView;

namespace Solitude2.Controllers.EncounterController
{
    internal static class HealthCheckController
    {
        internal static bool HealthCheck(float hp, string name)
        {
            if (hp > 0) return true;
            HealthCheckView.HealthCheck(name);
            return false;
        }
    }
}
