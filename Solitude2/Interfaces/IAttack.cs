namespace Solitude2.Interfaces
{
    public interface IAttack
    {
        string AttackName { get; set; }
        string Description { get; set; }
        float Dmg { get; set; }
    }
}
