using Code.States;

namespace Code.Factory.UI
{
    public interface IUIFactory
    {
        void WarmUp();
        void CreateEndGame(IStateMachine stateMachine);
    }
}