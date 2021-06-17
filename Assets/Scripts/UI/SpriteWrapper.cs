using UnityEngine;
using UnityEngine.UI;

namespace UniversalRPG
{
    public class SpriteWrapper
    {
        private Object spriteHolder;

        public SpriteWrapper(Object newSpriteHolder) { spriteHolder = newSpriteHolder; }

        public void SetSprite(Sprite newSprite)
        {
            switch (spriteHolder.GetType().ToString())
            {
                case "UnityEngine.UI.Image":
                    ((Image)spriteHolder).sprite = newSprite;
                    break;
                case "UnityEngine.SpriteRenderer":
                    ((SpriteRenderer)spriteHolder).sprite = newSprite;
                    break;
                default:
                    throw new System.Exception($"No behaviour in SpriteWrapper {this} for type {spriteHolder.GetType().ToString()}!");
            }
        }
    }
}