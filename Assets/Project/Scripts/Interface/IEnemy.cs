using UnityEngine;

public interface IEnemy : ITakeDamage, IAttack
{
    event System.Action OnTakeDamage;
    event System.Action OnAttack;
    event System.Action OnDeath;

    void Initialize(Transform target);
    bool IsAttackReady();
    void Death();
}
