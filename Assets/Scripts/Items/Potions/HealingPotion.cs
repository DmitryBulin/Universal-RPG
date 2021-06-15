using UnityEngine;

namespace UniversalRPG.Items
{
    [CreateAssetMenu(fileName = "New Health Potion", menuName = "Items/Potions/HealingPotion")]    
    public class HealingPotion : Potion
    {
        [SerializeField] private int healthToHeal;

        public HealingPotion(int _healthToHeal)
        {
            healthToHeal = _healthToHeal;
        }

        public override void Consume(PlayerControl player)
        {
            player.PlayerHealth.AddHealth(healthToHeal);
        }
    }
}