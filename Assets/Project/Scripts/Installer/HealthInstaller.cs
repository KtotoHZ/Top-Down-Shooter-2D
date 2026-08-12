using UnityEngine;
using Zenject;

public class HealthInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IHealth>().To<HealthSystem>().AsTransient();
    }
}