using System;
using System.Collections.Generic;
using Code.Factory.Assets;
using Code.Game.Battle;
using Code.Game.Ship.Gun;
using Code.Services.Progress;
using Code.StaticData.Ship;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Factory.Bullets
{
    public class BulletsFactory : IBulletsFactory
    {
        private const string BulletsPoolName = "Bullets";
        private const int DefaultBulletsCount = 20;

        private readonly IAssets _assets;
        private readonly ShipData _shipData;
        private readonly IProgressService _progressService;
        private readonly List<Bullet> _bullets = new List<Bullet>();

        private Bullet _bulletPrefab;
        private Transform _parentForBullets;
        private float _screenHeightInUnit;
        private IBulletsFactory _bulletsFactoryImplementation;

        public BulletsFactory(IAssets assets, ShipData shipData, IProgressService progressService)
        {
            _assets = assets;
            _shipData = shipData;
            _progressService = progressService;
        }

        public void CreateBullets(float screenHeightInUnit)
        {
            Cleanup();
            _screenHeightInUnit = screenHeightInUnit;

            _bulletPrefab = _assets.Load(_assets.BulletPath).GetComponent<Bullet>();
            _parentForBullets = new GameObject(BulletsPoolName).transform;

            for (int i = 0; i < DefaultBulletsCount; i++)
            {
                var bullet = CreateBullet();
                _bullets.Add(bullet);
            }
        }

        public void SpawnBullet(Vector2 position, UnitType unitType) =>
            SpawnBullet(position, unitType, _progressService.BulletSpeed, _shipData.Damage);

        public void SpawnBullet(Vector2 position, UnitType unitType, float speed, float damage)
        {
            Bullet bullet = GetBullet();
            bullet.transform.position = position;
            bullet.SetData(damage, speed, unitType, GetDirection(unitType));
            bullet.gameObject.SetActive(true);
        }

        public void BulletBackToPool(Bullet bullet)
        {
            _bullets.Add(bullet);

            bullet.gameObject.SetActive(false);
            bullet.transform.position = Vector2.zero;
        }

        public void Cleanup()
        {
            _bullets.Clear();
        }

        private Bullet GetBullet()
        {
            Bullet bullet;

            if (_bullets.Count > 0)
            {
                bullet = _bullets[0];
                _bullets.Remove(bullet);
            }
            else
            {
                bullet = CreateBullet();
            }

            return bullet;
        }

        private Bullet CreateBullet()
        {
            Bullet bulletGameObject = Object.Instantiate(_bulletPrefab, _parentForBullets);
            bulletGameObject.gameObject.SetActive(false);
            bulletGameObject.Init(_screenHeightInUnit, this);

            return bulletGameObject;
        }

        private Vector2 GetDirection(UnitType unitType)
        {
            switch (unitType)
            {
                case UnitType.Player:
                    return Vector2.up;
                case UnitType.EnemyShip:
                    return Vector2.down;
                default:
                    throw new ArgumentOutOfRangeException(nameof(unitType), unitType, null);
            }
        }
    }
}