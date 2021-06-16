using UnityEngine;

namespace UniversalRPG.Items
{
    public abstract class Weapon : Item, IEquipable, IUsable
    {
        [field: SerializeField] public ItemEquipSlot EquipSlot { get; protected set; }

        public void Equip(Equipment equipment)
        {
            equipment.EquipItem(this);
        }

        public abstract void Use(PlayerControl player);

    }
}
