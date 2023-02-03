namespace Code.States
{
    public interface IState
    {
        void Enter(IStateMachine stateMachine);
        void Exit();
    }
}