namespace UniversalRPG.Items
{
    public interface IEquipable
    {
        ItemEquipSlot EquipSlot { get; }
        void Equip(Equipment equipment);
    }
}