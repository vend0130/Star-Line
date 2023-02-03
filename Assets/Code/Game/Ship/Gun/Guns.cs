using Code.Factory.Bullets;
using Code.Services.Bonuses;
using Code.Services.Progress;
using UnityEngine;

namespace Code.Game.Ship.Gun
{
    public class Guns : MonoBehaviour
    {
        [field: SerializeField] public ShootGuns ShootGuns { get; private set; }

        private IBulletsFactory _bulletsFactory;

        public void Init(IBulletsFactory bulletsFactory, IBonusesService bonusesService,
            IProgressService progressService) =>
            ShootGuns.Init(bulletsFactory, bonusesService, progressService);

        public void ChangeShootState(bool value) =>
            ShootGuns.IsShoot = value;
    }
}