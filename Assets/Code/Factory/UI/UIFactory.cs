using Code.Factory.Assets;
using Code.States;
using Code.UI;
using UnityEngine;

namespace Code.Factory.UI
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssets _assets;

        private GameObject _prefab;

        public UIFactory(IAssets assets) =>
            _assets = assets;

        public void WarmUp() =>
            _prefab = _assets.Load(_assets.UIEndGamePath);

        public void CreateEndGame(IStateMachine stateMachine) =>
            Object.Instantiate(_prefab).GetComponent<EndGame>().Init(stateMachine);
    }
}