using Code.Services.Bonuses;
using Code.StaticData.Bonuses;
using UnityEngine;

namespace Code.Factory.Bonuses
{
    public class BonusesFactory : IBonusesFactory
    {
        private readonly BonusesData _bonusesData;
        private readonly IBonusesService _bonusesService;

        private GameObject _prefab;

        public BonusesFactory(BonusesData bonusesData, IBonusesService bonusesService)
        {
            _bonusesData = bonusesData;
            _bonusesService = bonusesService;
        }

        public void Create(TypeBonus type, Vector2 position)
        {
            BonusData bonusData = _bonusesData.GetBonusByType(type);

            BonusView bonus = Object.Instantiate(bonusData.Prefab, position, Quaternion.identity);
            bonus.Init(_bonusesService, _bonusesData.Speed, bonusData.Type);
        }
    }
}