using UnityEngine;
using UnityEngine.AddressableAssets;

namespace UniversalRPG.Items
{

    public abstract class Item : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        
        [field : SerializeField] [field : Range(1, 256)] public int MaximumStackCapacity { get; private set; }
        
        [field: SerializeField] public ItemRarity Rarity { get; private set; }

        [field: SerializeField] public AssetReference Icon { get; private set; }
        
        //Name and description will be loaded via localisation tool
        public string ItemName { get; protected set; }
        public string Description { get; protected set; }

        protected Item() { MaximumStackCapacity = 1; }

        public virtual void SetNewLocalisation(string newName, string newDescription)
        {
            ItemName = newName;
            Description = newDescription;
        }

    }
}