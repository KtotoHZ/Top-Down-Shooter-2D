using System;
using UnityEngine;
using Zenject;

public abstract class Enemy : MonoBehaviour, IEnemy
{
    [SerializeField] protected EnemyData _enemyData;
    [Inject] public IHealth _health { get; private set; }

    protected float _timeToActiveAttack;

    protected Transform _target;

    public event Action OnTakeDamage;
    public event Action OnAttack;
    public event Action OnDeath;

    public static Action OnAnyDeath;

    public void InvokeOnAttack() => OnAttack?.Invoke();
    public void InvokeOnDeath() => OnDeath?.Invoke();

    protected virtual void Awake() => _health.Initialize(_enemyData.MaxHealth);

    protected virtual void Start() => _target = FindTarget();

    protected virtual void OnEnable()
    {
        _health.OnDeath += Death;
    }
    protected virtual void OnDisable()
    {
        _health.OnDeath -= Death;
    }
    
    public abstract void Attack();
    public bool IsAttackReady()
    {
        if (Time.time >= _timeToActiveAttack) return true;
        else return false;
    }

    public  void TakeDamage(int damage)
    {
        OnTakeDamage?.Invoke();

        _health.TakeDamage(damage);
    }
    public virtual void Death() 
    {
        OnDeath?.Invoke();
        OnAnyDeath?.Invoke();
    }

    protected Transform FindTarget() => GameObject.FindObjectOfType<PlayerController>().transform;
}
