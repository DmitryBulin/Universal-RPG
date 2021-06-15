using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Health", menuName = "Health")]
public class Health : ScriptableObject
{
    [Range(0, 5000)] [SerializeField] private int maxHealth; 
    public int MaxHealth { get => maxHealth; } 
    public int CurrentHealth { get; private set; }
    public UnityEvent<int> HealthChanged { get; private set; } = new UnityEvent<int>();

    public void IncreaseMaxHealth(int maxHealthToAdd)
    {
        maxHealth += maxHealthToAdd;
    }

    public void DecreaseMaxHealth(int maxHealthToSusbtract)
    {
        maxHealth = Math.Min(1, maxHealth - maxHealthToSusbtract);
    }

    public void AddHealth(int healthToAdd)
    {
        if(healthToAdd < 0) { Debug.LogError("Tried adding negative health amount!"); return; }
        CurrentHealth = Math.Min(MaxHealth, CurrentHealth + healthToAdd);
        HealthChanged?.Invoke(CurrentHealth);
    }

    public void SubstractHealth(int healthToSubstract)
    {
        if (healthToSubstract < 0) { Debug.LogError("Tried substracting negative health amount!"); return; }
        CurrentHealth = Math.Max(0, CurrentHealth - healthToSubstract);
        HealthChanged?.Invoke(CurrentHealth);
    }

}
