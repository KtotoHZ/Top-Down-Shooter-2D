using UnityEngine;
using Zenject;

public class GamePauseInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IGamePauseService>().To<GamePauseService>().AsSingle();
    }
}