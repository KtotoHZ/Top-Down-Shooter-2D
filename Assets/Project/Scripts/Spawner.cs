using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using Zenject;

[System.Serializable]
struct GroupEnemy
{
    [SerializeField] private EnemyType _type;
    [SerializeField] private int _count;

    public EnemyType Type => _type;
    public int Count => _count;
}

[System.Serializable]
struct Wave
{
    [SerializeField] private GroupEnemy[] _dataWave;
    [SerializeField] private float _waveDuration;

    public GroupEnemy[] DataWaves => _dataWave;
    public float WaveDuration => _waveDuration;
}

public class Spawner : MonoBehaviour
{
    [Inject] private DiContainer _container;

    [System.Serializable]
    private struct _enemyPref
    {
        public EnemyType Type;
        public GameObject Pref;
    }
    
    [SerializeField] private _enemyPref[] _enemyPrefs;

    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private Wave[] _waves;

    private Dictionary<EnemyType, GameObject> _enemys = new();

    private void Start()
    {
        foreach(_enemyPref enemy in _enemyPrefs)
            _enemys.Add(enemy.Type, enemy.Pref);

        SpawnMonster().Forget();
    }

    private async UniTaskVoid SpawnMonster()
    {
        for(int a = 0; a < _waves.Length; a++)
        {
            for (int b = 0; b < _waves[a].DataWaves.Length; b++)
            {
                for (int c = 0; c < _waves[a].DataWaves[b].Count; c++)
                {
                    CreateEnemy(_waves[a].DataWaves[b].Type);

                    await UniTask.WaitForSeconds(0.4f);
                }
            }
            await UniTask.WaitForSeconds(_waves[a].WaveDuration);
        }
    }
    private void CreateEnemy(EnemyType type)
    {
        int randomRange = UnityEngine.Random.Range(0, _spawnPoints.Length);

        _container.InstantiatePrefab(_enemys[type], 
            _spawnPoints[randomRange].position, 
            _spawnPoints[randomRange].rotation, 
            null);
    }
}
