namespace UniversalRPG.Items
{
    interface IConsumable
    {
        void Consume(PlayerControl player);
    }

    interface IEquipable
    {
        ItemEquipSlot EquipSlot { get; }
        void Equip(PlayerControl player);
    }

    interface IUsable
    {
        void Use(PlayerControl player);
    }

}