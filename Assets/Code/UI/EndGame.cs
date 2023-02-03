using Code.States;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private Button _againButton;

        private IStateMachine _stateMachine;

        public void Init(IStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        private void Start() =>
            _againButton.onClick.AddListener(OnClick);

        private void OnClick() =>
            _stateMachine.Enter<LoadSceneState>();
    }
}