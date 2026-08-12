using UnityEngine;
using Zenject;

public class ObjectPoolManagerInstaller : MonoInstaller
{
    [SerializeField]private ObjectPoolsManager _objectPoolManager;
    public override void InstallBindings()
    {
        Container.Bind<IObjectPoolManager>().FromInstance(_objectPoolManager).AsSingle();
    }
}