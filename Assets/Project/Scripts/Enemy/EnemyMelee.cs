using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMelee : Enemy, IMovable
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _distanceToAttack = 1f;

    private Rigidbody2D _rb;

    protected override void Awake()
    {
        base.Awake();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_target == null) return;

        if(Vector2.Distance(transform.position,_target.position) <= _distanceToAttack) Attack();
        else Move(_target.position);
    }
    public override void Attack()
    {
        if (IsAttackReady() == false) return;

        if (_target.gameObject.TryGetComponent(out ITakeDamage takeDamage))
        {
            takeDamage.TakeDamage(_enemyData.Damage);

            _timeToActiveAttack = Time.time + _enemyData.DelayAttack;

            InvokeOnAttack();
        }
    }

    public override void Death()
    {
        base.Death();

        Destroy(gameObject);
    }

    public void Move(Vector2 vectorMove)
    {
        Vector2 direction = (vectorMove - (Vector2)transform.position).normalized;

        _rb.velocity = direction * _speed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.rotation = angle - 90f;
    }
}
