using System;
using UnityEngine;

public class DisposeAfterTime : MonoBehaviour
{
    [SerializeField] private float _delay;
    private float _timeToDispose;

    private void OnEnable() => _timeToDispose = Time.time + _delay;
    
    void Update()
    {
        if(Time.time >= _timeToDispose)
        {
            if (TryGetComponent(out IDisposable disposable)) disposable.Dispose();
            else Destroy(gameObject);
        }
    }
}
