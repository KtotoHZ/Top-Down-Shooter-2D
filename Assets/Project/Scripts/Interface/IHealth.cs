using System;

public interface IHealth
{
    float CurrentHealth { get; }
    float MaxHealth { get; }
    bool IsDead { get; }

    event Action OnDeath;
    event Action<float, float> OnHealthChanged;

    void Initialize(int maxHealth);
    void TakeDamage(float damage);
    void Heal(float amount);
    void SetMaxHealth(float newMax);
}
