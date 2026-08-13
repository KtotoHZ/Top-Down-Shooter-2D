using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon
{
    [SerializeField] private float _delayColliderDeactive;
    [SerializeField] private Collider2D _collider;

    private void Start() => _collider.enabled = false;
    private void Update()
    {
        if (_input.IsAttackPressed()) Attack();
    }

    public override void Attack()
    {
        if (IsAttackReady() == false) return;

        _timeToActiveAttack = Time.time + _weaponData.DelayAttack;

        AttackStart().Forget();

        InvokeOnAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ITakeDamage takeDamage))
        {
            takeDamage.TakeDamage(_weaponData.Damage);
        }
    }
    private async UniTaskVoid AttackStart()
    {
        _collider.enabled = true;

        await UniTask.WaitForSeconds(_delayColliderDeactive);

        _collider.enabled = false;
    }
}
