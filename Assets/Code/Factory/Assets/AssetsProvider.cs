using UnityEngine;

namespace Code.Factory.Assets
{
    public class AssetsProvider : IAssets
    {
        public string HUDPath => "Prefabs/UI/HUD/HUD";
        public string HeartUIPath => "Prefabs/UI/HUD/HeartSprite";
        public string ShipPath => "Prefabs/Ship/Ship";
        public string BulletPath => "Prefabs/Bullet";
        public string UIEndGamePath => "Prefabs/UI/EndGameUI";

        public GameObject Load(string path) =>
            Resources.Load<GameObject>(path);
    }
}