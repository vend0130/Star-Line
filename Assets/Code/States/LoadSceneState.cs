using System;
using System.Collections;
using Code.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.States
{
    public class LoadSceneState : IState, IDisposable
    {
        private const string SceneName = "Level";

        private CurtainView _curtainView;

        public void Enter(IStateMachine stateMachine)
        {
            if (_curtainView.gameObject.activeSelf)
                Load(SceneName);
            else
                _curtainView.Show();
        }

        public void Exit()
        {
        }

        public void Init(CurtainView curtainView)
        {
            _curtainView = curtainView;
            _curtainView.EffectEndHandler += EndEffectCurtain;
        }

        public void Dispose() =>
            _curtainView.EffectEndHandler -= EndEffectCurtain;

        private void EndEffectCurtain() =>
            Load(SceneName);

        private void Load(string name) =>
            _curtainView.StartCurtain(LoadScene(name));

        private IEnumerator LoadScene(string name)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone)
                yield return null;

            _curtainView.Hide();
        }
    }
}