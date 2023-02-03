using Code.Factory.Assets;
using Code.Factory.Bonuses;
using Code.Factory.Bullets;
using Code.Factory.Game;
using Code.Factory.UI;
using Code.Services.Bonuses;
using Code.Services.InputService;
using Code.Services.Progress;
using Code.States;
using Code.StaticData.Bonuses;
using Code.StaticData.Levels;
using Code.StaticData.Ship;
using Code.UI;
using UnityEngine;
using Zenject;

namespace Code.Root
{
    public class Bootstrap : MonoInstaller, IInitializable
    {
        [SerializeField] private ShipData _shipData;
        [SerializeField] private BonusesData _bonusesData;
        [SerializeField] private LevelData _levelData;
        [SerializeField] private CurtainView _curtain;

        public override void InstallBindings()
        {
            BindServices();
            BindFromInstance();
            BindFactories();
            BindStates();

            Container.BindInterfacesTo<Bootstrap>().FromInstance(this).AsSingle();
        }

        private void BindServices()
        {
            BindInputService();
            Container.BindInterfacesTo<BonusesService>().AsSingle();
            Container.BindInterfacesTo<ProgressService>().AsSingle();
        }

        private void BindInputService()
        {
#if UNITY_EDITOR
            InputService inputService = new KeyboardInputService();
#else
            InputService inputService = new MobileInputService();
#endif

            Container.Bind<IInputService>().FromInstance(inputService).AsSingle();
        }

        private void BindFromInstance()
        {
            Container.Bind<ShipData>().FromInstance(_shipData).AsSingle();
            Container.Bind<BonusesData>().FromInstance(_bonusesData).AsSingle();
            Container.Bind<LevelData>().FromInstance(_levelData).AsSingle();
        }

        private void BindFactories()
        {
            Container.BindInterfacesTo<AssetsProvider>().AsSingle();
            Container.BindInterfacesTo<BonusesFactory>().AsSingle();
            Container.BindInterfacesTo<BulletsFactory>().AsSingle();
            Container.BindInterfacesTo<UIFactory>().AsSingle();
            Container.BindInterfacesTo<GameFactory>().AsSingle();
        }

        private void BindStates()
        {
            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<LoadSceneState>().AsSingle();
            Container.Bind<SpawnEnemiesState>().AsSingle();
            Container.Bind<GameLoopState>().AsSingle();
            Container.Bind<EndGameState>().AsSingle();
        }

        public void Initialize()
        {
            CurtainView curtainView = Container.InstantiatePrefabForComponent<CurtainView>(_curtain);
            LoadSceneState loadSceneState = Container.Resolve<LoadSceneState>();
            var stateMachine = Container.Resolve<GameStateMachine>();

            loadSceneState.Init(curtainView);
            stateMachine.Enter<LoadSceneState>();
        }
    }
}