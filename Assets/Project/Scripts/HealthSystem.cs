using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : IHealth
{
    private float _maxHealth = 100f;
    private float _currentHealth;

    public event Action OnDeath;
    public event Action<float, float> OnHealthChanged; // текущее, максимальное

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;
    public bool IsDead => _currentHealth <= 0;

    public void Initialize(int maxHealth)
    {
        SetMaxHealth(maxHealth);
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (IsDead) return;

        _currentHealth = Mathf.Max(0, _currentHealth - damage);
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (IsDead)
            OnDeath?.Invoke();
    }

    public void Heal(float amount)
    {
        if (IsDead) return;

        _currentHealth = Mathf.Min(_maxHealth, _currentHealth + amount);
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void SetMaxHealth(float newMax)
    {
        _maxHealth = newMax;
        _currentHealth = Mathf.Min(_currentHealth, _maxHealth);
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
