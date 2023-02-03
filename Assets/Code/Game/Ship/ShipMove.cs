using Code.Services.InputService;
using UnityEngine;

namespace Code.Game.Ship
{
    public class ShipMove : MonoBehaviour
    {
        public bool IsMove { get; set; }

        private float _strafeSpeed;
        private IInputService _inputService;
        private float _screenWidthInUnit;

        private void Update()
        {
            if (!IsMove)
                return;

            transform.Translate(Translation());
            ChangePosition();
        }

        public void Init(IInputService inputService, float screenWidthInUnit, float strafeSpeed)
        {
            _inputService = inputService;
            _screenWidthInUnit = screenWidthInUnit;
            _strafeSpeed = strafeSpeed;
        }

        private Vector3 Translation() =>
            new Vector3(_inputService.DirectionX, 0, 0) * _strafeSpeed * Time.deltaTime;

        private void ChangePosition()
        {
            Vector3 position = transform.position;

            if (transform.position.x < -_screenWidthInUnit)
                position.x = -_screenWidthInUnit;
            else if (transform.position.x > _screenWidthInUnit)
                position.x = _screenWidthInUnit;

            transform.position = position;
        }
    }
}