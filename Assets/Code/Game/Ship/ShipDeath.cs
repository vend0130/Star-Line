using System;
using UnityEngine;

namespace Code.Game.Ship
{
    public class ShipDeath : MonoBehaviour
    {
        [SerializeField] private ShipHealth _health;
        [SerializeField] private ShipMove _shipMove;
        [SerializeField] private Collider2D _collider;

        public event Action DeathHandler;

        private void Start() =>
            _health.DieHandler += Die;

        private void OnDestroy() =>
            _health.DieHandler += Die;

        private void Die()
        {
            _shipMove.IsMove = false;
            _collider.enabled = false;
            DeathHandler?.Invoke();
            Destroy(gameObject);
        }
    }
}