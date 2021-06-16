using UnityEngine;

namespace UniversalRPG.Items
{
    public abstract class Potion : Item, IConsumable, IEquipable
    {
        [field: SerializeField] public ItemEquipSlot EquipSlot { get; private set; }

        public abstract void Consume(PlayerControl player);
        public void Equip(Equipment equipment)
        {
            equipment.EquipItem(this);
        }

    }
}