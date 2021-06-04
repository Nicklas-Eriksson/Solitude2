namespace Solitude2.Interfaces
{
    public interface ILevelable
    {
        int CurrentLvl { get; set; }
        int MaxLvl { get; set; }
        float CurrentExp { get; set; }
        float ExpReqForLvl { get; set; }
    }
}
