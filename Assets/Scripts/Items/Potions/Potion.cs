using UnityEngine;

namespace UniversalRPG.Items
{
    public abstract class Potion : Item, IConsumable, IEquipable
    {
        [Header("Potion specific settigs")]
        [SerializeField] private ItemEquipSlot equipSlot;
        public ItemEquipSlot EquipSlot { get => equipSlot; }

        public abstract void Consume(PlayerControl player);
        public void Equip(PlayerControl player)
        {
            //
        }

    }
}