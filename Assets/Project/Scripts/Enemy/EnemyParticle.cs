using UnityEngine;
using Zenject;

public class EnemyParticle : MonoBehaviour
{
    [SerializeField] private GameObject _prefDamagePS;
    [SerializeField] private GameObject _prefDeadPS;

    [Inject] private IObjectPoolManager _poolManager;

    private IEnemy _enemy;

    private void Awake() => _enemy = GetComponent<Enemy>();

    private void OnEnable()
    {
        _enemy.OnTakeDamage += SpawnDamagePs;
        _enemy.OnDeath += SpawnDeadPs;
    }

    private void OnDisable()
    {
        _enemy.OnTakeDamage -= SpawnDamagePs;
        _enemy.OnDeath -= SpawnDeadPs;
    }

    private void SpawnDamagePs()
    {
        if(_prefDamagePS != null)
            _poolManager.SpawnObject(_prefDamagePS, transform.position, transform.rotation);
    }
    private void SpawnDeadPs()
    {
        if(_prefDeadPS != null)
            _poolManager?.SpawnObject(_prefDeadPS, transform.position, transform.rotation);
    }
}
