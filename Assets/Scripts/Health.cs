using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Health", menuName = "Health")]
public class Health : ScriptableObject
{
    [field: SerializeField] [field : Range(0, 5000)] public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public UnityEvent<int> HealthChanged { get; private set; } = new UnityEvent<int>();

    public void IncreaseMaxHealth(int maxHealthToAdd)
    {
        MaxHealth += maxHealthToAdd;
    }

    public void DecreaseMaxHealth(int maxHealthToSusbtract)
    {
        MaxHealth = Math.Min(1, MaxHealth - maxHealthToSusbtract);
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
