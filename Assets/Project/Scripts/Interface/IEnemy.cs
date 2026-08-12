public interface IEnemy : ITakeDamage, IAttack
{
    event System.Action OnTakeDamage;
    event System.Action OnAttack;
    event System.Action OnDeath;

    bool IsAttackReady();
    void Death();
}
