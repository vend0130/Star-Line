using Code.Game.Battle;
using Code.Game.Ship.Gun;
using UnityEngine;

namespace Code.Factory.Bullets
{
    public interface IBulletsFactory
    {
        void SpawnBullet(Vector2 position, UnitType unitType);
        void SpawnBullet(Vector2 position, UnitType unitType, float speed, float damage);
        void BulletBackToPool(Bullet bullet);
        void CreateBullets(float screenHeightInUnit);
        void Cleanup();
    }
}