using System;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour, ITakeDamage, IHealable, ITargetPositionProvider
{
    [SerializeField] private int _maxHealth;
    [Inject] public IHealth Health { get; private set; }

    public Vector2 Position => transform.position;

    public Action OnTakeDamage;
    public Action OnHeal;
    public Action OnDeath;

    private void Awake() => Health.Initialize(_maxHealth);

    private void OnEnable()
    {
        Health.OnDeath += Death;
    }
    private void OnDisable()
    {
        Health.OnDeath -= Death;
    }

    public void TakeDamage(int damage)
    {
        Health.TakeDamage(damage);

        OnTakeDamage?.Invoke();
    }
    public void Heal(int point)
    {
        Health.Heal(point);

        OnHeal?.Invoke();   
    }

    public void Death() 
    {
        OnDeath?.Invoke();
    }

}
