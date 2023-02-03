using System;
using Code.Factory.Assets;
using Code.Factory.Bonuses;
using Code.Factory.Bullets;
using Code.Game;
using Code.Game.Enemies;
using Code.Game.Ship;
using Code.Services.Bonuses;
using Code.Services.InputService;
using Code.Services.Progress;
using Code.StaticData.Ship;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Code.Factory.Game
{
    public class GameFactory : IGameFactory, IDisposable
    {
        public ShipView Ship { get; private set; }
        public EnemiesContainer EnemiesContainer { get; private set; }

        private readonly DiContainer _container;
        private readonly IAssets _assets;
        private readonly IInputService _inputService;
        private readonly ShipData _shipData;
        private readonly IBulletsFactory _bulletsFactory;
        private readonly IBonusesFactory _bonusesFactory;
        private readonly IBonusesService _bonusesService;
        private readonly IProgressService _progressService;
        private readonly float _screenWidth;

        private HeartsView _hearts;
        private GameObject _heartPrefab;

        public GameFactory(IAssets assets, IInputService inputService, ShipData shipData,
            IBulletsFactory bulletsFactory, IBonusesFactory bonusesFactory, IBonusesService bonusesService,
            IProgressService progressService)
        {
            _assets = assets;
            _inputService = inputService;
            _shipData = shipData;
            _bulletsFactory = bulletsFactory;
            _bonusesFactory = bonusesFactory;
            _bonusesService = bonusesService;
            _progressService = progressService;
            _screenWidth = Screen.width;

            _bonusesService.PickupHeartHandler += CreateHeartInHUD;
        }

        public void Dispose()
        {
            _bonusesService.PickupHeartHandler -= CreateHeartInHUD;
        }

        public void CreateHUD()
        {
            GameObject prefab = _assets.Load(_assets.HUDPath);
            GameObject hud = Object.Instantiate(prefab);

            InputHandler inputHandler = hud.GetComponentInChildren<InputHandler>();
            inputHandler.Init(_screenWidth);
            _inputService.InitInputHandler(inputHandler);

            _heartPrefab = _assets.Load(_assets.HeartUIPath);
            CreateHeartsInHUD(hud);
        }

        public void CreateShip(float screenWidthInUnit)
        {
            GameObject prefab = _assets.Load(_assets.ShipPath);

            Ship = Object.Instantiate(prefab, _shipData.SpawnPoint, Quaternion.identity)
                .GetComponent<ShipView>();

            Ship.ShipMove.Init(_inputService, screenWidthInUnit, _shipData.StrafeSpeed);
            Ship.ShipMove.IsMove = true;

            Ship.Guns.Init(_bulletsFactory, _bonusesService, _progressService);
            Ship.Guns.ChangeShootState(false);

            Ship.Health.InitProgress(_progressService, _hearts);
        }

        public EnemiesContainer CreateEnemiesContainer(EnemiesContainer prefab)
        {
            EnemiesContainer = Object.Instantiate(prefab);
            EnemiesContainer.Init(_bonusesFactory, _bulletsFactory, _shipData.MoveSpeed);

            return EnemiesContainer;
        }

        private void CreateHeartsInHUD(GameObject hud)
        {
            _hearts = hud.GetComponentInChildren<HeartsView>();

            for (int i = 0; i < _shipData.Hearts; i++)
                CreateHeartInHUD();
        }

        private void CreateHeartInHUD()
        {
            _progressService.Hearts++;
            GameObject heart = Object.Instantiate(_heartPrefab, _hearts.transform);
            _hearts.AddHeart(heart);
        }
    }
}