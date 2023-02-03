using Code.Factory.Bullets;
using UnityEngine;

namespace Code.Game.Battle
{
    public class Bullet : MonoBehaviour
    {
        private float _speed;
        private float _screenHeightInUnit;
        private IBulletsFactory _bulletsFactory;
        private float _damage;
        private UnitType _unitShoot;
        private Vector2 _direction;

        private void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);

            if (transform.position.y > _screenHeightInUnit || transform.position.y < -_screenHeightInUnit)
                _bulletsFactory.BulletBackToPool(this);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out ITakeDamage takeDamage) && takeDamage.UnitType != _unitShoot)
            {
                takeDamage.TakeDamage(_damage);
                _bulletsFactory.BulletBackToPool(this);
            }
        }

        public void Init(float screenHeightInUnit, IBulletsFactory bulletsFactory)
        {
            _screenHeightInUnit = screenHeightInUnit;
            _bulletsFactory = bulletsFactory;
        }

        public void SetData(float damage, float speed, UnitType unitType, Vector2 direction)
        {
            _damage = damage;
            _speed = speed;
            _unitShoot = unitType;
            _direction = direction;
        }
    }
}