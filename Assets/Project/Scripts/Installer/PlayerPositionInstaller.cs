using UnityEngine;
using Zenject;

public class PlayerPositionInstaller : MonoInstaller
{
    [SerializeField] private PlayerController _playerController;
    public override void InstallBindings()
    {
        Container.Bind<ITargetPositionProvider>()
            .FromComponentInHierarchy(_playerController)
            .AsSingle();
    }
}