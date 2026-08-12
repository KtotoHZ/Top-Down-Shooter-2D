using System;

public interface IPoolPart: IDisposable
{
    void Inittialize(IObjectPool objectPool);
}
