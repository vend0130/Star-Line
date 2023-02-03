using System;
using Code.Factory.Bullets;
using Code.Services.Bonuses;
using Code.Services.Progress;
using UnityEngine;

namespace Code.Game.Ship.Gun
{
    public class ShootGuns : MonoBehaviour
    {
        [SerializeField] private Transform _centerSpawnPoint;
        [SerializeField] private Transform[] _spawnPointsOnWings;
        [SerializeField] private int _numberOfActiveGuns;
        [SerializeField] private ShipHealth _shipHealth;

        public bool IsShoot { get; set; }

        private float _nextTimeForShoot;
        private IBulletsFactory _bulletsFactory;
        private IBonusesService _bonusesService;
        private IProgressService _progressService;

        private void Update() =>
            Shoot();

        private void OnDestroy() =>
            _bonusesService.PickupActiveGunsHandler -= ChangeActiveGuns;

        public void Init(IBulletsFactory bulletsFactory, IBonusesService bonusesService,
            IProgressService progressService)
        {
            _bulletsFactory = bulletsFactory;
            _bonusesService = bonusesService;
            _progressService = progressService;

            _bonusesService.PickupActiveGunsHandler += ChangeActiveGuns;
        }

        private void ChangeActiveGuns(int value) =>
            _numberOfActiveGuns = value;

        private void Shoot()
        {
            if (Time.time < _nextTimeForShoot || !IsShoot)
                return;

            SpawnBullets();

            _nextTimeForShoot = Time.time + _progressService.CooldownShoot;
        }

        private void SpawnBullets()
        {
            switch (_numberOfActiveGuns)
            {
                case 1:
                    SpawnCenterBullet();
                    break;
                case 2:
                    SpawnBulletsOnWings();
                    break;
                case 3:
                    SpawnCenterBullet();
                    SpawnBulletsOnWings();
                    break;
                default:
                    throw new Exception(nameof(ShootGuns) + "not correct value" + nameof(_numberOfActiveGuns));
            }
        }


        private void SpawnBulletsOnWings()
        {
            foreach (var spawnPoint in _spawnPointsOnWings)
                _bulletsFactory.SpawnBullet(spawnPoint.position, _shipHealth.UnitType);
        }

        private void SpawnCenterBullet() =>
            _bulletsFactory.SpawnBullet(_centerSpawnPoint.position, _shipHealth.UnitType);
    }
}