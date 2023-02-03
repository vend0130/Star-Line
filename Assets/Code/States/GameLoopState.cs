using Code.Factory.Game;

namespace Code.States
{
    public class GameLoopState : IState
    {
        private readonly IGameFactory _factory;
        private IStateMachine _stateMachine;

        public GameLoopState(IGameFactory factory) =>
            _factory = factory;

        public void Enter(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _factory.Ship.Guns.ChangeShootState(true);
            _factory.EnemiesContainer.StartShoot();

            _factory.EnemiesContainer.AllDeathHandler += KillAllEnemy;
            _factory.Ship.ShipDeath.DeathHandler += Death;
        }

        public void Exit()
        {
            _factory.EnemiesContainer.AllDeathHandler -= KillAllEnemy;
            _factory.Ship.ShipDeath.DeathHandler -= Death;
        }

        private void KillAllEnemy()
        {
            _factory.Ship.Guns.ChangeShootState(false);
            _stateMachine.Enter<SpawnEnemiesState>();
        }

        private void Death()
        {
            _factory.EnemiesContainer.EndShoot();
            _stateMachine.Enter<EndGameState>();
        }
    }
}