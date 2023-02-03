using Code.Factory.Bonuses;
using Code.Services.Bonuses;
using UnityEngine;

namespace Code.Game.Enemies
{
    public class EnemyShipShield : EnemyBase
    {
        [SerializeField] private TypeBonus _type;

        private IBonusesFactory _bonusesFactory;
        private EnemiesContainer _enemiesContainer;

        public void Init(IBonusesFactory bonusesFactory, EnemiesContainer enemiesContainer)
        {
            _bonusesFactory = bonusesFactory;
            _enemiesContainer = enemiesContainer;
        }

        protected override void Die()
        {
            DropBonus();
            _enemiesContainer.ShipDeath(this);
            base.Die();
        }

        private void DropBonus() =>
            _bonusesFactory.Create(_type, transform.position);
    }
}