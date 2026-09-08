using System;
using UnityEngine;

public class PoolPart : MonoBehaviour, IPoolPart
{
    private IObjectPool _objectPool;

    private bool _isPooled;

    private void OnEnable() => _isPooled = false;

    public void Initialize(IObjectPool objectPool)
    {
        _objectPool = objectPool;
    }

    public void ReturnToPool()
    {
        if (_isPooled) return;
        
        _isPooled = true;

        _objectPool.DeactivateObject(gameObject);
    }
}
