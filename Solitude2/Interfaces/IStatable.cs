namespace Solitude2.Interfaces
{
    public interface IStats
    {
        float CurrentHP { get; set; }
        float MaxHP { get; set; }
        float AttackPower { get; set; }
        float CriticalBonus { get; }
        float CriticalPercent { get; }
    }
}
