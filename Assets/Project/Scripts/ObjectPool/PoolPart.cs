using System;
using UnityEngine;

public class PoolPart : MonoBehaviour, IPoolPart
{
    private IObjectPool _objectPool;

    public void Inittialize(IObjectPool objectPool) => _objectPool = objectPool;
    
    public void Dispose() => _objectPool.DeactivateObject(gameObject);
}
