using Code.Factory.Bullets;
using Code.Factory.Game;
using Code.Factory.UI;
using Code.Game.Background;
using Code.Game.Ship;
using Code.States;
using Code.StaticData.Ship;
using UnityEngine;
using Zenject;

namespace Code.Root
{
    public class InitializeLeve : IInitializable
    {
        private readonly IGameFactory _factory;
        private readonly IBulletsFactory _bulletsFactory;
        private readonly Camera _camera;
        private readonly BackgroundScroll _backgroundScroll;
        private readonly ShipData _shipData;
        private readonly GameStateMachine _stateMachine;
        private readonly IUIFactory _uiFactory;

        public InitializeLeve(IGameFactory factory, IBulletsFactory bulletsFactory, Camera camera,
            BackgroundScroll backgroundScroll, ShipData shipData, GameStateMachine stateMachine,
            IUIFactory uiFactory)
        {
            _factory = factory;
            _bulletsFactory = bulletsFactory;
            _camera = camera;
            _backgroundScroll = backgroundScroll;
            _shipData = shipData;
            _stateMachine = stateMachine;
            _uiFactory = uiFactory;
        }

        public void Initialize()
        {
            Vector2 screenSizeInUnit =
                _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            _factory.CreateHUD();
            _bulletsFactory.CreateBullets(screenSizeInUnit.y);
            _factory.CreateShip(screenSizeInUnit.x);
            _uiFactory.WarmUp();

            _backgroundScroll.Init(screenSizeInUnit.y, _shipData.MoveSpeed);

            InitialCamera(screenSizeInUnit.x);

            _stateMachine.Enter<SpawnEnemiesState>();
        }

        private void InitialCamera(float screenWidthInUnit)
        {
            if (_camera.TryGetComponent(out CameraFollow cameraFollow))
                cameraFollow.Init(_factory.Ship.transform, screenWidthInUnit);
        }
    }
}