using UnityEngine;
using Zenject;

public class WeaponFirearmsProjectile : Weapon
{
    [SerializeField] private Transform _pointShoot;
    [SerializeField] private GameObject _bulletPref;
    [Inject] private IObjectPoolManager _objectPoolManager;

    private void Update()
    {
        if (_input.IsAttackPressed()) Attack();
    }
    public override void Attack()
    {
        if (IsAttackReady() == false) return;

        _objectPoolManager.SpawnObject(_bulletPref, _pointShoot.position, _pointShoot.rotation)
            .GetComponent<ISetDamage>().SetDamage(_weaponData.Damage);

        _timeToActiveAttack = Time.time + _weaponData.DelayAttack;

        InovkeOnAttack();
    }
}
