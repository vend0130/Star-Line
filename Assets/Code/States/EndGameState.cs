using Code.Factory.Bullets;
using Code.Factory.UI;
using Code.Services.Progress;

namespace Code.States
{
    public class EndGameState : IState
    {
        private readonly IUIFactory _uiFactory;
        private readonly IBulletsFactory _bulletsFactory;
        private readonly IProgressService _progressService;

        public EndGameState(IUIFactory uiFactory, IBulletsFactory bulletsFactory, IProgressService progressService)
        {
            _uiFactory = uiFactory;
            _bulletsFactory = bulletsFactory;
            _progressService = progressService;
        }

        public void Enter(IStateMachine stateMachine)
        {
            _uiFactory.CreateEndGame(stateMachine);
            _progressService.Reset();
            _bulletsFactory.Cleanup();
        }

        public void Exit()
        {
        }
    }
}