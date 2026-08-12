using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour, IObjectPool
{
    private GameObject _objectPref;

    private GameObject _nowObject;

    private Queue<GameObject> _listObject = new();

    public void Initialize(GameObject pref, int startSize)
    {
        _objectPref = pref;

        CreateTask(startSize).Forget();
    }

    //спавн обьектов раз в кадр, что бы не было фризов
    private async UniTaskVoid CreateTask(int startSize)
    {
        for (int i = 0; i < startSize; i++)
        {
            CreatePart(_objectPref);

            await UniTask.Yield();
        }
    }

    public void CreatePart(GameObject gm)
    {
        _nowObject = Instantiate(gm);

        _listObject.Enqueue(_nowObject);

        IPoolPart poolPart = _nowObject.AddComponent<PoolPart>();
        poolPart.Inittialize(this);

        _nowObject.transform.parent = transform;

        _nowObject.SetActive(false);
    }

    public GameObject SpawnObject(Vector2 spawnPosition, Quaternion quaternion)
    {
        if (_listObject.Count == 0) CreatePart(_objectPref);

        _nowObject = _listObject.Dequeue();

        _nowObject.SetActive(true);

        _nowObject.transform.parent = null;

        _nowObject.transform.position = spawnPosition;
        _nowObject.transform.rotation = quaternion;

        return _nowObject;
    }

    public void DeactivateObject(GameObject gm)
    {
        gm.transform.parent = transform;

        gm.SetActive(false);

        _listObject.Enqueue(gm);
    }
}
