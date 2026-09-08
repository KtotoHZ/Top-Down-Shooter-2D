using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

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

    [Header("Игрок")]
    [SerializeField] private Transform _target;

    [Header("Точки спавна врагов")]
    [SerializeField] private Transform[] _spawnPoints;

    [Header("Волны")]
    [SerializeField] private EnemyWaveSO _wavesConfig;

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

        for (int a = 0; a < _wavesConfig.Waves.Length; a++)
        {
            for (int b = 0; b < _wavesConfig.Waves[a].DataWaves.Length; b++)
            {
                for (int c = 0; c < _wavesConfig.Waves[a].DataWaves[b].Count; c++)
                {
                    CreateEnemy(_wavesConfig.Waves[a].DataWaves[b].Type);

                    await UniTask.WaitForSeconds(_delaySpawn, cancellationToken: cancellationToken);
                }
            }
            await UniTask.WaitWhile(() => _enemysCount > 0); 
        }
    }

    private void CreateEnemy(EnemyType type)
    {
        int randomRange = Random.Range(0, _spawnPoints.Length);

        IEnemy enemy = _container.InstantiatePrefab(_enemys[type],
            _spawnPoints[randomRange].position,
            _spawnPoints[randomRange].rotation,
            null).GetComponent<IEnemy>();

        enemy.Initialize(_target);

        _enemysCount++;
    }

    private void OnEnemyDead() => _enemysCount--;
}
