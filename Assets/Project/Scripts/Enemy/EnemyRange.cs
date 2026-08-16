using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Windows;
using Zenject;

public class EnemyRange : Enemy
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _distanceToAttack = 1f;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _bulletPref;

    [Inject] private IObjectPoolManager _objectPoolManager;

    private Rigidbody2D _rb;

    protected override void Awake()
    {
        base.Awake(); 
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_target == null) return;

        Vector3 direction = (_target.position - transform.position).normalized;

        Rotate(direction);

        if (Vector2.Distance(transform.position, _target.position) <= _distanceToAttack)
        {
            _rb.velocity = Vector2.zero;

            Attack();
        }
        else Move(direction);

    }
    public override void Attack()
    {
        if (IsAttackReady() == false) return;

        if (_target != null)
        {
            _timeToActiveAttack = Time.time + _enemyData.DelayAttack;

            _objectPoolManager.SpawnObject(_bulletPref, _shootPoint.position, _shootPoint.rotation).
                 GetComponent<ISetDamage>()?.SetDamage(_enemyData.Damage);

            InvokeOnAttack();
        }
    }

    public override void Death()
    {
        base.Death();

        Destroy(gameObject);
    }

    public void Move(Vector2 direction)
    {
        _rb.velocity = direction * _speed;
    }

    private void Rotate(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.rotation = angle - 90f;
    }
}
