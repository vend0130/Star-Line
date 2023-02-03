using UnityEngine;

namespace Code.Game.Ship
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _cameraOffset = .5f;

        private Transform _target;
        private float _screenWidthInUnit;

        private void LateUpdate()
        {
            if (_target == null)
                return;

            Follow();
        }

        public void Init(Transform target, float screenWidthInUnit)
        {
            _target = target;
            _screenWidthInUnit = screenWidthInUnit;
        }

        private void Follow()
        {
            Vector3 position = transform.position;
            position.x = _target.position.x / _screenWidthInUnit * _cameraOffset;
            transform.position = position;
        }
    }
}