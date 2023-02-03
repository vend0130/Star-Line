using System;
using System.Collections.Generic;

namespace Code.States
{
    public class GameStateMachine : IStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(LoadSceneState loadSceneState, SpawnEnemiesState spawnEnemiesState,
            GameLoopState gameLoopState, EndGameState endGameState)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(LoadSceneState)] = loadSceneState,
                [typeof(SpawnEnemiesState)] = spawnEnemiesState,
                [typeof(GameLoopState)] = gameLoopState,
                [typeof(EndGameState)] = endGameState
            };
        }

        public void Enter<T>() where T : class, IState
        {
            _activeState?.Exit();

            var state = _states[typeof(T)];
            _activeState = state;
            _activeState.Enter(this);
        }
    }
}