using System.ComponentModel;
using UnityEngine;
using Zenject;

public class SignalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<WeaponAttackSignal>().OptionalSubscriber();
        Container.DeclareSignal<EnemyDeadSignal>().OptionalSubscriber();
        Container.DeclareSignal<GamePauseSignal>().OptionalSubscriber();
    }
}