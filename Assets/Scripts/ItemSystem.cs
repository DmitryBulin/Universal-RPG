using System.Collections.Generic;
using UnityEngine;
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

    }

}