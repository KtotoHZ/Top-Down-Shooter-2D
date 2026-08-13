using System;
using UnityEngine;
using Zenject;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] protected WeaponData _weaponData;
    [Inject] protected IInputPlayer _input;

    protected float _timeToActiveAttack;


    public event Action OnAttack;
    public event Action OnAlternativeAttack;
    protected void InvokeOnAttack() => OnAttack?.Invoke();
    protected void InvokeOnAlternativeAttack() => OnAlternativeAttack?.Invoke();

    public abstract void Attack();

    public bool IsAttackReady()
    {
        if (Time.time >= _timeToActiveAttack) return true;
        else return false;
    }

}
