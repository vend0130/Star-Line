using Code.Game.Enemies;
using Code.Game.Ship;

namespace Code.Factory.Game
{
    public interface IGameFactory
    {
        ShipView Ship { get; }
        EnemiesContainer EnemiesContainer { get; }

        void CreateHUD();
        void CreateShip(float screenWidthInUnit);
        EnemiesContainer CreateEnemiesContainer(EnemiesContainer prefab);
    }
}