using System.Linq;
using System.Text.RegularExpressions;
using Code.Services.Bonuses;
using UnityEngine;

namespace Code.StaticData.Bonuses
{
    [CreateAssetMenu(fileName = nameof(BonusesData), menuName = "Data/" + nameof(BonusesData))]
    public class BonusesData : ScriptableObject
    {
        [field: SerializeField] public int Speed { get; private set; } = 2;

        [SerializeField] private BonusData[] _bonuses;

        public BonusData GetBonusByType(TypeBonus type) =>
            _bonuses.FirstOrDefault(bonus => bonus.Type == type);

        private void OnValidate()
        {
            foreach (var bonus in _bonuses)
                bonus.Name = Regex.Replace(bonus.Type.ToString(), "([a-z])([A-Z])", "$1 $2");
        }
    }
}