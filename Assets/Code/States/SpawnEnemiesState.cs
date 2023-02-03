using Code.Factory.Game;
using Code.Game.Enemies;
using Code.Services.Progress;
using Code.StaticData.Levels;

namespace Code.States
{
    public class SpawnEnemiesState : IState
    {
        private readonly LevelData _levelData;
        private readonly IGameFactory _factory;
        private readonly IProgressService _progressService;

        private IStateMachine _stateMachine;
        private EnemiesContainer _currenContainer;

        public SpawnEnemiesState(LevelData levelData, IGameFactory factory, IProgressService progressService)
        {
            _levelData = levelData;
            _factory = factory;
            _progressService = progressService;
        }

        public void Enter(IStateMachine stateMachine)
        {
            if (_progressService.Stage == _levelData.Containers.Length)
            {
                _stateMachine.Enter<EndGameState>();
                return;
            }

            _stateMachine = stateMachine;

            EnemiesContainer prefab = _levelData.Containers[_progressService.Stage];
            EnemiesContainer enemiesContainer = _factory.CreateEnemiesContainer(prefab);
            enemiesContainer.FinishMoveHandler += FinishedMove;
            _currenContainer = enemiesContainer;
        }

        public void Exit()
        {
            _currenContainer.FinishMoveHandler -= FinishedMove;
            _progressService.Stage++;
        }

        private void FinishedMove() =>
            _stateMachine.Enter<GameLoopState>();
    }
}