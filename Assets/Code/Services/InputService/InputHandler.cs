using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Services.InputService
{
    public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler,
        IInputHandler
    {
        public float DirectionX { get; private set; }

        private float _screenWidth;
        private List<PointerEventData> _eventDatas = new List<PointerEventData>();
        private bool _pressed => _eventDatas.Count > 0;

        private void Start() =>
            _screenWidth = Screen.width;

        public void OnPointerDown(PointerEventData eventData)
        {
            _eventDatas.Add(eventData);
            UpdateDirectionX();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            DirectionX = 0;
            _eventDatas.Remove(eventData);

            if (_eventDatas.Count != 0)
                UpdateDirectionX();
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (!_pressed)
                return;

            UpdateDirectionX();
        }

        public void Init(float screenWidth) =>
            _screenWidth = screenWidth;

        private void UpdateDirectionX() =>
            DirectionX = EventDataPosition() > _screenWidth / 2 ? 1 : -1;

        private float EventDataPosition()
        {
            if (_eventDatas.Count == 0)
                return 0;

            return _eventDatas[^1].position.x;
        }
    }
}