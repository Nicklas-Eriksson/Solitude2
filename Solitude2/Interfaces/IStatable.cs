namespace Solitude2.Interfaces
{
    public interface IStatable
    {
        float CurrentHP { get; set; }
        float MaxHP { get; set; }
        float AttackPower { get; set; }
        float CritBonus { get; set; }
        float CritPercent { get; set; }
    }
}
