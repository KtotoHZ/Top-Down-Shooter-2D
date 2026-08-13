using System;
using UnityEngine;

public class PoolPart : MonoBehaviour, IPoolPart
{
    private IObjectPool _objectPool;

    private bool _isPooled;

    private void OnEnable() => _isPooled = false;

    public void Inittialize(IObjectPool objectPool)
    {
        _objectPool = objectPool;
    }

    public void Dispose()
    {
        if (_isPooled) return;
        
        _isPooled = true;

        _objectPool.DeactivateObject(gameObject);
    }
}
