using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : IHealth
{
    private int _maxHealth = 100;
    private int _currentHealth;

    public event Action OnDeath;
    public event Action<int, int> OnHealthChanged; // текущее, максимальное

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;
    public bool IsDead => _currentHealth <= 0;

    public void Initialize(int maxHealth)
    {
        SetMaxHealth(maxHealth);
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        _currentHealth = Mathf.Max(0, _currentHealth - damage);
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (IsDead)
            OnDeath?.Invoke();
    }

    public void Heal(int amount)
    {
        if (IsDead) return;

        _currentHealth = Mathf.Min(_maxHealth, _currentHealth + amount);
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void SetMaxHealth(int newMax)
    {
        _maxHealth = newMax;
        _currentHealth = Mathf.Min(_currentHealth, _maxHealth);
        OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
