using UnityEngine;

namespace UniversalRPG.Items
{
    [CreateAssetMenu(fileName = "New Health Potion", menuName = "Items/Potions/HealingPotion")]    
    public class HealingPotion : Potion
    {
        [field: SerializeField]  public int HealthToHeal { get; private set; }
        
        public override void Consume(PlayerControl player)
        {
            player.PlayerHealth.AddHealth(HealthToHeal);
        }
    }
}