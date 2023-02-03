using Code.Services.Bonuses;
using UnityEngine;

namespace Code.Factory.Bonuses
{
    public interface IBonusesFactory
    {
        void Create(TypeBonus type, Vector2 position);
    }
}