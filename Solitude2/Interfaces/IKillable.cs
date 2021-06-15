using Solitude2.Models;

namespace Solitude2.Interfaces
{
    public interface IKillable
    {
        float GoldDrop { get; }
        float ExpDrop { get; }
        Item Drop { get; set; }
    }
}
