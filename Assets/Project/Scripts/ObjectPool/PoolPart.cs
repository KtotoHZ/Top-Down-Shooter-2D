using System;
using UnityEngine;

public class PoolPart : MonoBehaviour, IPoolPart
{
    private IObjectPool _objectPool;

    private bool _isPooled;

    public void Inittialize(IObjectPool objectPool)
    {
        _isPooled = false;

        _objectPool = objectPool;
    }

    public void Dispose()
    {
        if (_isPooled) return;
        
        _objectPool.DeactivateObject(gameObject);

        _isPooled = true;
    }
}
