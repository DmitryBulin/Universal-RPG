using UnityEngine;

namespace UniversalRPG.Items
{

    public abstract class Item : ScriptableObject
    {
        [Header("General settings")]

        [SerializeField] private string itemID;
        public string ID { get => itemID; }

        [Range(1, 1000)] [SerializeField] protected int maximumStackCapacity;
        public int MaximumStackCapacity { get => maximumStackCapacity; }

        [SerializeField] protected ItemRarity rarity;
        public ItemRarity Rarity { get => rarity; }

        [SerializeField] protected Sprite icon;
        public Sprite Icon { get => icon; }
        
        public string ItemName { get; protected set; }
        public string Description { get; protected set; }

        protected Item() { maximumStackCapacity = 1; }
    }
}