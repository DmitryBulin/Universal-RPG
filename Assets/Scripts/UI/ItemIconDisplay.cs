using UnityEngine;
using UnityEngine.Events;
using UniversalRPG.Items;

namespace UniversalRPG
{
    public class ItemIconDisplay : MonoBehaviour
    {
        [SerializeField] private Object spriteHolder;
        [SerializeField] private Item item;
        public UnityEvent<Item> ItemChanged { get; } = new UnityEvent<Item>();

        public void SetNewItemIcon(Item newItem)
        {
            ItemChanged?.Invoke(item);
            item = newItem;
            ItemSystem.Instance.SetItemIcon(new SpriteWrapper(spriteHolder), item);
        }
    }
}