using UnityEngine;

namespace Code.Game.Background
{
    public class BackgroundScroll : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] _sprites;

        private float _shipSpeed;
        private float _screenHeightInUnit;
        private float _extentsSpriteY;
        private int _lastSpriteIndex;
        private int _firstSpriteIndex;

        private void Update()
        {
            Move();
            SpriteToUp();
        }

        public void Init(float screenHeightInUnit, float shipSpeed)
        {
            _shipSpeed = shipSpeed;
            _screenHeightInUnit = screenHeightInUnit;

            _firstSpriteIndex = 0;
            _extentsSpriteY = _sprites[_firstSpriteIndex].bounds.extents.y;

            ChangePositionOnStart();
        }

        private void ChangePositionOnStart()
        {
            Vector2 firstPosition = new Vector2(0, (_extentsSpriteY - _screenHeightInUnit));

            for (int i = 0; i < _sprites.Length; i++)
            {
                Vector2 position = _sprites[i].transform.position;
                position.y = firstPosition.y + i * (_extentsSpriteY * 2);
                _sprites[i].transform.position = position;

                _lastSpriteIndex = i;
            }
        }

        private void Move()
        {
            foreach (var t in _sprites)
                t.transform.Translate(Vector2.down * _shipSpeed * Time.deltaTime);
        }

        private void SpriteToUp()
        {
            if (_sprites[_firstSpriteIndex].transform.position.y + _extentsSpriteY >= -_screenHeightInUnit)
                return;

            Vector2 position = _sprites[_lastSpriteIndex].transform.position;
            position.y += _extentsSpriteY * 2;
            _sprites[_firstSpriteIndex].transform.position = position;

            _lastSpriteIndex = _firstSpriteIndex;
            _firstSpriteIndex = _firstSpriteIndex + 1 >= _sprites.Length ? 0 : _firstSpriteIndex + 1;
        }
    }
}