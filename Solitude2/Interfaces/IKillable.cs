using Solitude2.Models;

namespace Solitude2.Interfaces
{
    public interface IKillable
    {
        float GoldDrop { get; set; }
        float ExpDrop { get; set; }
        Item Drop { get; set; }
        int TalentDrop { get; set; }
    }
}
