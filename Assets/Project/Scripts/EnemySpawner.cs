using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[System.Serializable]
struct GroupEnemy
{
    [Header("Тип Врага")]
    [SerializeField] private EnemyType _type;
    [Header("Количество врагов")]
    [SerializeField] private int _count;

    public EnemyType Type => _type;
    public int Count => _count;
}

[System.Serializable]
struct Wave
{
    [SerializeField] private GroupEnemy[] _dataWave;

    public GroupEnemy[] DataWaves => _dataWave;
}

public class EnemySpawner : MonoBehaviour
{
    [Inject] private DiContainer _container;
    [Inject] private SignalBus _signalBus;

    [System.Serializable]
    private struct _enemyPref
    {
        [Header("Тип")]
        public EnemyType Type;

        [Header("Преваб")]
        public GameObject Pref;
    }

    [Header("Префабы врагов")]
    [SerializeField] private _enemyPref[] _enemyPrefs;

    [Header("Точки спавна врагов")]
    [SerializeField] private Transform[] _spawnPoints;

    [Header("Волны")]
    [SerializeField] private Wave[] _waves;

    [Header("Интервал спавна врагов")]
    [SerializeField] private float _delaySpawn = 0.4f;

    private int _enemysCount;

    private Dictionary<EnemyType, GameObject> _enemys = new();

    private void OnEnable() => _signalBus.Subscribe<EnemyDeadSignal>(OnEnemyDead);
    private void OnDisable() => _signalBus.Unsubscribe<EnemyDeadSignal>(OnEnemyDead);

    private void Start()
    {
        foreach(_enemyPref enemy in _enemyPrefs)
            _enemys.Add(enemy.Type, enemy.Pref);

        SpawnMonster().Forget();
    }

    private async UniTaskVoid SpawnMonster()
    {
        var cancellationToken = this.GetCancellationTokenOnDestroy();

        for (int a = 0; a < _waves.Length; a++)
        {
            for (int b = 0; b < _waves[a].DataWaves.Length; b++)
            {
                for (int c = 0; c < _waves[a].DataWaves[b].Count; c++)
                {
                    CreateEnemy(_waves[a].DataWaves[b].Type);

                    await UniTask.WaitForSeconds(_delaySpawn, cancellationToken: cancellationToken);
                }
            }
            await UniTask.WaitWhile(() => _enemysCount > 0); 
        }
    }

    private void CreateEnemy(EnemyType type)
    {
        int randomRange = Random.Range(0, _spawnPoints.Length);

        _container.InstantiatePrefab(_enemys[type],
            _spawnPoints[randomRange].position,
            _spawnPoints[randomRange].rotation,
            null).GetComponent<IEnemy>();

        _enemysCount++;
    }

    private void OnEnemyDead() => _enemysCount--;
}
