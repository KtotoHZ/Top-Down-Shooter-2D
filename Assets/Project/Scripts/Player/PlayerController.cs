using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour, ITakeDamage, IHealable
{
    [SerializeField] private int _maxHealth;
    [Inject] public IHealth _health { get; private set; }

    public Action OnTakeDamage;
    public Action OnHeal;
    public Action OnDeath;

    private void Awake() => _health.Initialize(_maxHealth);

    private void OnEnable()
    {
        _health.OnDeath += Death;
    }
    private void OnDisable()
    {
        _health.OnDeath -= Death;
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);

        OnTakeDamage?.Invoke();
    }
    public void Heal(int point)
    {
        _health.Heal(point);

        OnHeal?.Invoke();   
    }

    public void Death() 
    {
        OnDeath?.Invoke();
    }

}
