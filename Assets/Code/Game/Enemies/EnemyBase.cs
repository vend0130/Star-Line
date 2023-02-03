using Code.Game.Battle;
using UnityEngine;

namespace Code.Game.Enemies
{
    public class EnemyBase : MonoBehaviour, ITakeDamage
    {
        [field: SerializeField] public UnitType UnitType { get; private set; } = UnitType.EnemyShip;

        [SerializeField] private float _defaultHp;
        [SerializeField] private HPBar _hpBar;

        private float _currentHp;

        private void Start()
        {
            _currentHp = _defaultHp;
            _hpBar.gameObject.SetActive(false);
            ChangeHPBar();
        }

        public void TakeDamage(float damage)
        {
            _currentHp -= damage;

            if (!_hpBar.gameObject.activeSelf)
                _hpBar.gameObject.SetActive(true);

            ChangeHPBar();

            if (_currentHp <= 0)
                Die();
        }

        protected virtual void Die() =>
            Destroy(gameObject);

        private void ChangeHPBar() =>
            _hpBar.SetValue(_currentHp, _defaultHp);
    }
}