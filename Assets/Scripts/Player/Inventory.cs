using System;
using System.Collections.Generic;
using System.Linq;
using UniversalRPG.Items;
using UnityEngine.Events;

public enum InventorySortSetting
{
    ID, NAME, RARITY
}

public class Inventory
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
    public UnityEvent InventoryUpdated { get; } = new UnityEvent();

    private static readonly Dictionary<InventorySortSetting, Func<InventorySlot, InventorySlot, int>> sortFuncs = new Dictionary<InventorySortSetting, Func<InventorySlot, InventorySlot, int>>
    {
        [InventorySortSetting.ID] = (InventorySlot a, InventorySlot b) => a.SlotItem.ID.CompareTo(b.SlotItem.ID),
        [InventorySortSetting.NAME] = (InventorySlot a, InventorySlot b) => a.SlotItem.ItemName.CompareTo(b.SlotItem.ItemName),
        [InventorySortSetting.RARITY] = (InventorySlot a, InventorySlot b) => a.SlotItem.Rarity.CompareTo(b.SlotItem.Rarity)
    };

    public Inventory(int inventoryCapacity)
    {
        MaxInventoryCapacity = inventoryCapacity;
        InventoryUpdated?.Invoke();
    }

    public void IncreaseInventoryCapacity(int capacityToAdd)
    {
        MaxInventoryCapacity += capacityToAdd;
        InventoryUpdated?.Invoke();
    }

    public void DecreaseInventoryCapacity(int capacityToRemove)
    {
        MaxInventoryCapacity -= capacityToRemove;
        InventoryUpdated?.Invoke();
        //TODO: Remove items till capacity == max capacity and drop last items on the ground
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
                    InventoryUpdated?.Invoke();
                    return false;
                }
            }
        }
        InventoryUpdated?.Invoke();
        return true;
    }

    public void RemoveItem(int slotID)
    {
        InventorySlots.Remove(InventorySlots.Find(x => x.ID == slotID));
        InventoryUpdated?.Invoke();
    }

    public void DecreaseItemQuantity(int slotID, int decreasedQuantity)
    {
        InventorySlot slotToDecreaseQuantity = InventorySlots.Find(x => x.ID == slotID);

        int quantityToDecrease = Math.Min(decreasedQuantity, slotToDecreaseQuantity.Quantity);
        slotToDecreaseQuantity.DecreaseQuantity(quantityToDecrease);

        if (slotToDecreaseQuantity.Quantity == 0)
            InventorySlots.Remove(slotToDecreaseQuantity);

        InventoryUpdated?.Invoke();
    }

    public void SortSlots(InventorySortSetting sortSetting)
    {
        InventorySlots.Sort(delegate (InventorySlot a, InventorySlot b)
        {
            if (a == null && b == null) return 0;
            if (a == null) return -1;
            if (b == null) return 1;
            return sortFuncs[sortSetting](a, b);
        });
        UpdateSlotsID();
        InventoryUpdated?.Invoke();
    }

    private void UpdateSlotsID()
    {
        for (int i = 0; i < InventorySlots.Count; i++)
            InventorySlots[i].SetID(i);
    }

}