using System;
using System.Collections;
using UnityEngine;

namespace Code.UI
{
    public class CurtainView : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public event Action EffectEndHandler;

        private readonly int _fadeOnHash = Animator.StringToHash("On");
        private readonly int _fadeOffHash = Animator.StringToHash("Off");

        public void StartCurtain(IEnumerator coroutine)
        {
            gameObject.SetActive(true);
            StartCoroutine(coroutine);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _animator.SetTrigger(_fadeOnHash);
        }

        public void Hide() =>
            _animator.SetTrigger(_fadeOffHash);

        //note: animation callback
        public void ShowEnded() =>
            EffectEndHandler?.Invoke();

        //note: animation callback
        public void HideEnded() =>
            gameObject.SetActive(false);
    }
}