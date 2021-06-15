using System;
using System.Collections.Generic;
using System.Linq;
using UniversalRPG.Items;

public class InventorySystem
{
    public class InventorySlot
    {
        public Item SlotItem { get; private set; }
        public int Quantity { get; private set; }
        public int ID { get; private set; }
        public InventorySlot(Item item, int quantity, int id)
        {
            SlotItem = item;
            Quantity = quantity;
            ID = id;
        }
        public void SetID(int newID)
        {
            ID = newID;
        }
        public void AddToQuantity(int quantityToAdd)
        {
            Quantity += quantityToAdd;
        }
        public void DecreaseQuantity(int quantityToDecrease)
        {
            Quantity -= quantityToDecrease;
        }
    }
    
    public int MaxInventoryCapacity { get; private set; }
    public readonly List<InventorySlot> InventorySlots = new List<InventorySlot>();

    public InventorySystem(int inventoryCapacity)
    {
        MaxInventoryCapacity = inventoryCapacity;
    }

    public void IncreaseInventoryCapacity(int capacityToAdd)
    {
        MaxInventoryCapacity += capacityToAdd;
    }

    public void DecreaseInventoryCapacity(int capacityToRemove)
    {
        MaxInventoryCapacity -= capacityToRemove;
        //Remove items till capacity == max capacity
    }

    public bool AddItem(Item item, int quantityToAdd)
    {
        if (quantityToAdd <= 0) return false;
        while(quantityToAdd > 0)
        {
            if(InventorySlots.Exists(x => x.SlotItem.ID == item.ID && x.Quantity < item.MaximumStackCapacity))
            {
                InventorySlot slot = InventorySlots.First(x => x.SlotItem.ID == item.ID && x.Quantity < item.MaximumStackCapacity);
                int availableSlotCapacity = item.MaximumStackCapacity - slot.Quantity;
                int quantityToAddToSlot = Math.Min(availableSlotCapacity, quantityToAdd);
                slot.AddToQuantity(quantityToAddToSlot);
                quantityToAdd -= quantityToAddToSlot;
            }
            else
            {
                if(InventorySlots.Count < MaxInventoryCapacity)
                {
                    InventorySlots.Add(new InventorySlot(item, 0, InventorySlots.Count));
                }
                else
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void RemoveItem(int slotID)
    {
        InventorySlots.Remove(InventorySlots.Find(x => x.ID == slotID));
    }

    public void DecreaseItemQuantity(int slotID, int decreasedQuantity)
    {
        InventorySlot slotToDecreaseQuantity = InventorySlots.Find(x => x.ID == slotID);
        int quantityToDecrease = Math.Min(decreasedQuantity, slotToDecreaseQuantity.Quantity);
        slotToDecreaseQuantity.DecreaseQuantity(quantityToDecrease);
        if (slotToDecreaseQuantity.Quantity == 0)
            InventorySlots.Remove(slotToDecreaseQuantity);
    }

    public void SortSlotsByItemID()
    {
        InventorySlots.Sort(
            delegate(InventorySlot a, InventorySlot b)
            {
                if (a == null && b == null) return 0;
                if (a == null) return -1;
                if (b == null) return 1;
                return a.SlotItem.ID.CompareTo(b.SlotItem.ID);
            }
        );
        for(int i = 0; i < InventorySlots.Count; i++)
        {
            InventorySlots[i].SetID(i);
        }
    }

    public void SortSlotsByItemName()
    {
        InventorySlots.Sort(
               delegate (InventorySlot a, InventorySlot b)
               {
                   if (a == null && b == null) return 0;
                   if (a == null) return -1;
                   if (b == null) return 1;
                   return a.SlotItem.ItemName.CompareTo(b.SlotItem.ItemName);
               }
           );
        for (int i = 0; i < InventorySlots.Count; i++)
        {
            InventorySlots[i].SetID(i);
        }
    }

    public void SortSlotByItemRarity()
    {
        InventorySlots.Sort(
            delegate (InventorySlot a, InventorySlot b)
            {
                if (a == null && b == null) return 0;
                if (a == null) return -1;
                if (b == null) return 1;
                return a.SlotItem.Rarity.CompareTo(b.SlotItem.Rarity);
            }
        );
        for (int i = 0; i < InventorySlots.Count; i++)
        {
            InventorySlots[i].SetID(i);
        }
    }

}