using UnityEngine;

namespace Code.Services.Bonuses
{
    public class BonusView : MonoBehaviour
    {
        private TypeBonus _typeBonus;
        private float _speed;
        private IBonusesService _bonusesService;

        private void Update() =>
            transform.Translate(Vector2.down * _speed * Time.deltaTime);

        private void OnTriggerEnter2D(Collider2D other)
        {
            _bonusesService?.Pickup(_typeBonus);
            Destroy(gameObject);
        }

        public void Init(IBonusesService bonusesService, int speed, TypeBonus typeBonus)
        {
            _bonusesService = bonusesService;
            _speed = speed;
            _typeBonus = typeBonus;
        }
    }
}