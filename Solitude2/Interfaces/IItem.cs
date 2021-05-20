namespace Solitude2.Interfaces
{
    public interface IItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsWeapon { get; set; }
        public bool IsPotion { get; set; }
        public bool IsTrash { get; set; }
        public float Value { get; set; }
        public float Bonus { get; set; }
        public int ILvl { get; set; }
    }
}
