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

    public void InvokeOnAttack() => OnAttack?.Invoke();
    public void InvokeOnDeath() => OnDeath?.Invoke();

    protected virtual void Awake() => _health.Initialize(_enemyData.MaxHealth);

    protected virtual void Start() => _target = FindTarge();

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

        if (_health.CurrentHealth == 0) OnDeath?.Invoke();
    }
    public abstract void Death();

    protected Transform FindTarge() => GameObject.FindObjectOfType<PlayerController>().transform;
}
