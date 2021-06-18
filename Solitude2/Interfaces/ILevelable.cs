namespace Solitude2.Interfaces
{
    public interface ILevelable
    {
        int MaxLvl { get; set; }
        static int CurrentLvl { get; set; }
        float CurrentExp { get; set; }
        float ExpReqForLvl { get; }
    }
}
