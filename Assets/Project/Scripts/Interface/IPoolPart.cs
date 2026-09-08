using System;

public interface IPoolPart
{
    void Initialize(IObjectPool objectPool);
    void ReturnToPool();
}
