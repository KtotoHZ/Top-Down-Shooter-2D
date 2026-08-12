using UnityEngine;
using Zenject;

public class ObjectPoolInstaller : MonoInstaller
{
    [SerializeField]private ObjectPool _poolObject;
    public override void InstallBindings()
    {
        Container.Bind<IObjectPool>().FromInstance(_poolObject).AsSingle();
    }
}