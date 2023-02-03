namespace Code.Services.InputService
{
    public abstract class InputService : IInputService
    {
        public abstract float DirectionX { get; }

        private IInputHandler _inputHandler;

        public void InitInputHandler(IInputHandler inputHandler) =>
            _inputHandler = inputHandler;

        protected float DefaultDirection() =>
            _inputHandler?.DirectionX ?? default;
    }
}