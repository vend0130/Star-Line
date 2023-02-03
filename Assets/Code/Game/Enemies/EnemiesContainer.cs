using System;
using System.Collections.Generic;
using System.Linq;
using Code.Factory.Bonuses;
using Code.Factory.Bullets;
using UnityEditor;
using UnityEngine;

namespace Code.Game.Enemies
{
    public class EnemiesContainer : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private Transform _targetPoint;
        [SerializeField] private List<EnemyShipShield> _shieldShips;
        [SerializeField] private List<EnemyShipAttack> _attackShips;

        public event Action FinishMoveHandler;

        private float _speed;
        private bool _isMoving;
        public event Action AllDeathHandler;

        private void Update()
        {
            if (!_isMoving)
                return;

            _container.position =
                Vector3.MoveTowards(_container.position, _targetPoint.position, _speed * Time.deltaTime);

            if (_container.position == _targetPoint.position)
                FinishMove();
        }

        public void Init(IBonusesFactory bonusesFactory, IBulletsFactory bulletsFactory, float speed)
        {
            foreach (EnemyShipShield enemyShip in _shieldShips)
                enemyShip.Init(bonusesFactory, this);

            foreach (EnemyShipAttack enemyShip in _attackShips)
                enemyShip.Init(bulletsFactory, this);

            ShootChange(false);

            _speed = speed;
            _isMoving = true;
        }

        public void StartShoot() =>
            ShootChange(true);

        public void EndShoot() =>
            ShootChange(false);

        public void ShipDeath(EnemyShipAttack shipAttack)
        {
            _attackShips.Remove(shipAttack);

            if (AllDeath())
                DestroyContainer();
        }

        public void ShipDeath(EnemyShipShield shipShield)
        {
            _shieldShips.Remove(shipShield);

            if (AllDeath())
                DestroyContainer();
        }

        private bool AllDeath() =>
            _attackShips.Count == 0 && _shieldShips.Count == 0;

        private void DestroyContainer()
        {
            AllDeathHandler?.Invoke();
            Destroy(gameObject);
        }

        private void ShootChange(bool value)
        {
            foreach (EnemyShipAttack enemyShip in _attackShips)
            {
                if (enemyShip == null)
                    continue;

                if (value)
                    enemyShip.StartShoot();

                enemyShip.IsShoot = value;
            }
        }

        private void FinishMove()
        {
            _isMoving = false;
            FinishMoveHandler?.Invoke();
        }

#if UNITY_EDITOR
        [ContextMenu("Load Ships")]
        private void LoadShips()
        {
            _shieldShips = GetComponentsInChildren<EnemyShipShield>().ToList();
            _attackShips = GetComponentsInChildren<EnemyShipAttack>().ToList();
            AssetDatabase.SaveAssets();
        }
#endif
    }
}