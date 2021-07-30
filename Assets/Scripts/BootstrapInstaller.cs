using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] private Ship _ship;
    [SerializeField] private ShipSpawner _shipSpawner;
    public override void InstallBindings()
    {
        BindShipWithCamera();
        BindShipWithRoads();
    }
    private void BindShipWithRoads()
    {
        Container.Bind<ShipSpawner>().FromInstance(_shipSpawner).AsSingle();
    }
    private void BindShipWithCamera()
    {
        Container.Bind<Ship>().FromInstance(_ship).AsSingle();

    }

}