using UnityEngine;

namespace Code.Services.InputService
{
    public class KeyboardInputService : InputService
    {
        public override float DirectionX
        {
            get
            {
                float directionX = DefaultDirection();

                return directionX == 0
                    ? Input.GetAxisRaw("Horizontal")
                    : directionX;
            }
        }
    }
}