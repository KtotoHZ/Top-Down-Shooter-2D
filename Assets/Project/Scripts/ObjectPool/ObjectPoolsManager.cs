using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolsManager : MonoBehaviour, IObjectPoolManager
{
    [SerializeField] private int _defaultPoolSize;
    private Dictionary<GameObject, IObjectPool> _objectPools = new();

    public GameObject SpawnObject(GameObject pref, Vector2 spawnPoint, Quaternion quaternion)
    {
        if (_objectPools.ContainsKey(pref))
        {
            return _objectPools[pref].SpawnObject(spawnPoint, quaternion);
        }
        else
        {
            CreatePool(pref);

            return _objectPools[pref].SpawnObject(spawnPoint, quaternion);
        }
    }
    private void CreatePool(GameObject pref)
    {
        GameObject gm = new GameObject($"ObjectPool_{pref.name}");
        gm.AddComponent<ObjectPool>();
        gm.transform.parent = transform;

        IObjectPool objectPool = gm.GetComponent<IObjectPool>();

        objectPool.Initialize(pref, _defaultPoolSize);

        _objectPools.Add(pref, objectPool);
    }
}
