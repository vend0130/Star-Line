using Code.Game.Background;
using UnityEngine;
using Zenject;

namespace Code.Root
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private BackgroundScroll _background;

        public override void InstallBindings()
        {
            Container.Bind<BackgroundScroll>().FromInstance(_background).AsSingle();
            Container.Bind<Camera>().FromInstance(Camera.main);
            Container.BindInterfacesTo<InitializeLeve>().AsSingle();
        }
    }
}