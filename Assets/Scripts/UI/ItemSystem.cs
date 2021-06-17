using System.Collections.Generic;
using UnityEngine;
using UniversalRPG.Items;

namespace UniversalRPG
{
    /*
      TODO:
        1. Handle loading/unloading item sprites and models
        2. Create localisation of item names and descriptions either here or in separate script
    */

    public class ItemSystem : MonoBehaviour
    {
        #region Singleton
        public static ItemSystem Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
            }
            else
            {
                DontDestroyOnLoad(this);
                Instance = this;
            }
        }
        #endregion

        [SerializeField] private List<Item> itemsList;

        public Item GetItemByID(string itemID)
        {
            Item itemToReturn = itemsList.Find(x => x.ID == itemID);
            if (itemToReturn == null)
            {
                Debug.LogError($"Tried getting item with id {itemID}!");
                itemToReturn = itemsList[0];
            }
            return itemToReturn;
        }

        public void SetItemIcon(SpriteWrapper spriteWrapper, Item item)
        {
            if (item.Icon.IsValid())
                item.Icon.OperationHandle.Completed += t => spriteWrapper.SetSprite((Sprite)t.Result);
            else
                item.Icon.LoadAssetAsync<Sprite>().Completed += t => spriteWrapper.SetSprite(t.Result);
        }
    }
        
}