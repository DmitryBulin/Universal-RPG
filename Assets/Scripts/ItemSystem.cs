using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniversalRPG.Items;

namespace UniversalRPG
{

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

        public void SetItemIcon(Image image, Item item)
        {
            item.Icon.LoadAssetAsync<Sprite>().Completed += t => image.sprite = t.Result;
        }

        public void SetItemIcon(SpriteRenderer spriteRenderer, Item item)
        {
            item.Icon.LoadAssetAsync<Sprite>().Completed += t => spriteRenderer.sprite = t.Result;
        }

    }

}