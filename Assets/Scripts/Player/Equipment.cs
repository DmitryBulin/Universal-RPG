using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniversalRPG.Items;

public class Equipment
{
    public Weapon MainWeapon { get; private set; }
    public Weapon SecondWeapon { get; private set; }
    public Armour Helmet { get; private set; }
    public Armour Chestplate { get; private set; }
    public Potion Potion { get; private set; }

    public Equipment(List<Item> startingItems)
    {
        for (int i = 0; i < startingItems.Count; i++)
            EquipItem((IEquipable)startingItems[i]);
    }

    public void EquipItem(IEquipable equipable)
    {
        if(equipable == null) { throw new UnassignedReferenceException($"Equipment {this} got item without IEquipable interface!"); }
        switch(equipable.EquipSlot)
        {
            case ItemEquipSlot.WEAPON:
                EquipMainWeapon((Weapon)equipable);
                break;
            case ItemEquipSlot.SECOND_WEAPON:
                EquipSecondWeapon((Weapon)equipable);
                break;
            case ItemEquipSlot.HELMET:
                EquipHelmet((Armour)equipable);
                break;
            case ItemEquipSlot.CHESTPLATE:
                EquipChestplate((Armour)equipable);
                break;
            case ItemEquipSlot.POTION:
                EquipPotion((Potion)equipable);
                break;
        }
    }

    private void EquipMainWeapon(Weapon newWeapon) => MainWeapon = newWeapon;

    private void EquipSecondWeapon(Weapon newWeapon) => SecondWeapon = newWeapon;

    private void EquipHelmet(Armour newArmour) => Helmet = newArmour;

    private void EquipChestplate(Armour newArmour) => Chestplate = newArmour;

    private void EquipPotion(Potion newPotion) => Potion = newPotion;

}
