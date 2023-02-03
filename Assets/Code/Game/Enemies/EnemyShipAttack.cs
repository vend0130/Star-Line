using Code.Factory.Bullets;
using UnityEngine;

namespace Code.Game.Enemies
{
    public class EnemyShipAttack : EnemyBase
    {
        [SerializeField] private Vector2Int _coldownTime = new Vector2Int(1, 10);
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _bulletSpeed = 4;
        [SerializeField] private float _damage = 1;

        public bool IsShoot { get; set; }

        private float _nextTimeForShoot;
        private IBulletsFactory _bulletsFactory;
        private EnemiesContainer _enemiesContainer;


        public void Init(IBulletsFactory bulletsFactory, EnemiesContainer enemiesContainer)
        {
            _bulletsFactory = bulletsFactory;
            _enemiesContainer = enemiesContainer;
        }

        private void Update() =>
            Shoot();

        public void StartShoot() =>
            UpdateNextTime();

        protected override void Die()
        {
            _enemiesContainer.ShipDeath(this);
            base.Die();
        }

        private void Shoot()
        {
            if (Time.time < _nextTimeForShoot || !IsShoot)
                return;

            _bulletsFactory.SpawnBullet(_spawnPoint.position, UnitType, _bulletSpeed, _damage);

            UpdateNextTime();
        }

        private void UpdateNextTime() =>
            _nextTimeForShoot = Time.time + Random.Range(_coldownTime.x, _coldownTime.y + 1);
    }
}