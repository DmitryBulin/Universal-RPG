using UnityEngine;

namespace UniversalRPG.Items
{
    public abstract class Weapon : Item, IEquipable, IUsable
    {
        [SerializeField] private ItemEquipSlot equipSlot;
        public ItemEquipSlot EquipSlot { get => equipSlot; }

        public void Equip(PlayerControl player)
        {
            //
        }

        public abstract void Use(PlayerControl player);

    }
}
