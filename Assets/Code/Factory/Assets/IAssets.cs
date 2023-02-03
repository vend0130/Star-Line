using UnityEngine;

namespace Code.Factory.Assets
{
    public interface IAssets
    {
        string HUDPath { get; }
        string ShipPath { get; }
        string BulletPath { get; }
        string HeartUIPath { get; }
        string UIEndGamePath { get; }

        GameObject Load(string path);
    }
}