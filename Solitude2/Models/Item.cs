using Solitude2.Interfaces;

namespace Solitude2.Models
{
    public class Item : IItem
    {
        public int ID { get; set; }
        public string Name { get; set; } = "Unknown";
        public string Description { get; set; } = "Non.";
        public float Value { get; set; } = default;
        public float Bonus { get; set; } = default;
        public int ILvl { get; set; } = default;
        public bool IsWeapon { get; set; } = false;
        public bool IsPotion { get; set; } = false;
        public bool IsTrash { get; set; } = false;

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Item(){}

        /// <summary>
        /// For creating a instance of an item without description.
        /// </summary>
        /// <param name="name">Item name.</param>
        /// <param name="bonus">Item bonus.</param>
        /// <param name="goldValue">Gold value.</param>
        /// <param name="iLvl">Item level. 0-indexed.</param>
        /// <param name="isWeapon">If item is weapon > true. Else false.</param>
        /// <param name="isPotion">If item is potion > true. Else false.</param>
        /// <param name="isTrash">If item is trash > true. Else false.</param>
        public Item(string name, float bonus, float goldValue, int iLvl, bool isWeapon, bool isPotion, bool isTrash)
        {
            this.Name = name;
            this.Bonus = bonus;
            this.Value = goldValue;
            this.ILvl = iLvl;
            this.IsWeapon = isWeapon;
            this.IsPotion = isPotion;
            this.IsTrash = isTrash;
        }

        /// <summary>
        /// For creating a instance of an item with all props.
        /// </summary>
        /// <param name="name">Weapon name.</param>
        /// <param name="bonus">Bonus damage.</param>
        /// <param name="goldValue">Gold value.</param>
        /// <param name="iLvl">Item level. 0-indexed.</param>
        /// <param name="description">Short description of the item.</param>
        /// <param name="isWeapon">If item is weapon > true. Else false.</param>
        /// <param name="isPotion">If item is potion > true. Else false.</param>
        /// <param name="isTrash">If item is trash > true. Else false.</param>
        public Item(string name, float bonus, float goldValue, int iLvl, string description, bool isWeapon, bool isPotion, bool isTrash)
        {
            this.Name = name;
            this.Bonus = bonus;
            this.Value = goldValue;
            this.ILvl = iLvl;
            this.Description = description;
            this.IsWeapon = isWeapon;
            this.IsPotion = isPotion;
            this.IsTrash = isTrash;
        }
    }
}
