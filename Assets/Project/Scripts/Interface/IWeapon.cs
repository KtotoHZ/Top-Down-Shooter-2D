using System;
public interface IWeapon : IAttack
{
    WeaponData WeaponData { get; }

    event Action OnAttack;
    event Action OnAlternativeAttack;

    bool IsAttackReady();
}
