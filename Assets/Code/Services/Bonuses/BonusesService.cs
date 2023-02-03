using System;

namespace Code.Services.Bonuses
{
    public class BonusesService : IBonusesService
    {
        public event Action<int> PickupActiveGunsHandler;
        public event Action PickupHeartHandler;
        public event Action PickupCooldownHandler;

        public void Pickup(TypeBonus type)
        {
            switch (type)
            {
                case TypeBonus.OneGun:
                case TypeBonus.TwoGuns:
                case TypeBonus.ThreeGuns:
                    PickupActiveGunsHandler?.Invoke((int)type);
                    break;
                case TypeBonus.Heart:
                    PickupHeartHandler?.Invoke();
                    break;
                case TypeBonus.UpBulletSpeed:
                    PickupCooldownHandler?.Invoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}