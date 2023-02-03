namespace Code.Services.InputService
{
    public interface IInputService
    {
        float DirectionX { get; }
        void InitInputHandler(IInputHandler inputHandler);
    }
}