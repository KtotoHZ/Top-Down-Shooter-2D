using UnityEngine;
using Zenject;

public class InventoryInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInventory<IWeapon>>().To<Inventory<IWeapon>>().AsSingle();
    }
}