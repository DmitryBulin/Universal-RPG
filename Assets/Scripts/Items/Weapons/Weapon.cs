using UnityEngine;

namespace UniversalRPG.Items
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Items/Weapon")]
    public class Weapon : Item, IEquipable, IUsable
    {
        [field: SerializeField] public ItemEquipSlot EquipSlot { get; protected set; }
        [field: SerializeField] [field: Range(0, 5000)] public int Damage { get; private set; }

        public void Equip(Equipment equipment)
        {
            equipment.EquipItem(this);
        }

        public void Use(PlayerControl player)
        {
            //Make attack with damage set in weapon
        }

    }
}
