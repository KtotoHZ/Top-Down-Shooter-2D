using System;

public interface IHealth
{
    int CurrentHealth { get; }
    int MaxHealth { get; }
    bool IsDead { get; }

    event Action OnDeath;
    event Action<int, int> OnHealthChanged;

    void Initialize(int maxHealth);
    void TakeDamage(int damage);
    void Heal(int amount);
    void SetMaxHealth(int newMax);
}
