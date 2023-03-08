using IceWasteland;
using IceWasteland.Player;
using UnityEngine;
using Zenject;

public sealed class LocationInstaller : MonoInstaller
{
    [SerializeField] private Transform startPoint;

    public override void InstallBindings()
    {
        BindInputService();
        BindPlayer();
        BindHUD();
    }

    private void BindInputService()
    {
        Container.BindInterfacesTo<InputService>().AsSingle().NonLazy();
    }

    private void BindPlayer()
    {
        Object playerPrefab = Resources.Load(AssetsPath.PLAYER);

        PlayerProvider player = Container
            .InstantiatePrefabForComponent<PlayerProvider>(playerPrefab, startPoint.position, Quaternion.identity, null);

        Container
            .Bind<PlayerProvider>()
            .FromInstance(player)
            .AsSingle();
    }

    private void BindHUD()
    {
        Object hudPrefab = Resources.Load(AssetsPath.HUD);
        Container.InstantiatePrefab(hudPrefab, startPoint.position, Quaternion.identity, null);
    }
}