using System;
public interface IWeapon : IAttack
{
    event Action OnAttack;
    event Action OnAlternativeAttack;

    bool IsAttackReady();
}
