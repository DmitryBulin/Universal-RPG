using UnityEngine;
using System.Collections.Generic;

namespace UniversalRPG.Items
{
    [CreateAssetMenu(fileName = "New Armour", menuName = "Items/Armour")]
    public class Armour : Item, IEquipable, ICharacterizeable
    {
        [field: SerializeField] public ItemEquipSlot EquipSlot { get; private set; }
        [field: SerializeField] public List<ItemStat> ItemStats { get; private set; }
        public void Equip(Equipment equipment)
        {
            equipment.EquipItem(this);
        }
    }
}