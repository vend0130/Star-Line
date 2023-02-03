using System;
using Code.Services.Bonuses;
using Code.StaticData.Ship;

namespace Code.Services.Progress
{
    public class ProgressService : IDisposable, IProgressService
    {
        public float CooldownShoot { get; private set; }
        public float BulletSpeed { get; private set; }
        public int Hearts { get; set; }
        public int Stage { get; set; }

        private readonly ShipData _shipData;
        private readonly IBonusesService _bonusesService;

        public ProgressService(ShipData shipData, IBonusesService bonusesService)
        {
            _shipData = shipData;
            _bonusesService = bonusesService;

            Reset();

            _bonusesService.PickupCooldownHandler += UpdateCooldown;
        }

        private void UpdateCooldown() =>
            CooldownShoot = _shipData.MinCooldownShoot;

        public void Dispose() =>
            _bonusesService.PickupCooldownHandler -= UpdateCooldown;

        public void Reset()
        {
            CooldownShoot = _shipData.MaxCooldownShoot;
            BulletSpeed = _shipData.BulletSpeed;
            Stage = 0;
        }
    }
}