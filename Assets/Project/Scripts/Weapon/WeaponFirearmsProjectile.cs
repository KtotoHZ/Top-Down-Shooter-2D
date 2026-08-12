using UnityEngine;

public class WeaponFirearmsProjectile : Weapon
{
    [SerializeField] private Transform _pointShoot;
    private void Update()
    {
        if (_input.IsAttackPressed()) Attack();
    }
    public override void Attack()
    {
        if (IsAttackReady() == false) return;

        _objectPool.SpawnObject(_pointShoot.position, _pointShoot.rotation)
            .GetComponent<ISetDamage>().SetDamage(_weaponData.Damage);

        _timeToActiveAttack = Time.time + _weaponData.DelayAttack;

        InovkeOnAttack();
    }
}
