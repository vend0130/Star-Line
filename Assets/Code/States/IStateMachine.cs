namespace Code.States
{
    public interface IStateMachine
    {
        void Enter<T>() where T : class, IState;
    }
}