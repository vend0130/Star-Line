using System;

namespace Code.Services.Bonuses
{
    public interface IBonusesService
    {
        event Action<int> PickupActiveGunsHandler;
        event Action PickupHeartHandler;
        event Action PickupCooldownHandler;

        void Pickup(TypeBonus type);
    }
}