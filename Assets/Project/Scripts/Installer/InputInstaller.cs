using UnityEngine;
using Zenject;

public class InputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        #if UNITY_STANDALONE_WIN
            Container.Bind<IInputPlayer>().To<DesktopInput>()
              .FromNewComponentOnNewGameObject().UnderTransform(transform).AsSingle().NonLazy();
        #endif
    }
}