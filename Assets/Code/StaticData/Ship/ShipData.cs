using UnityEngine;

namespace Code.StaticData.Ship
{
    [CreateAssetMenu(fileName = nameof(ShipData), menuName = "Data/" + nameof(ShipData))]
    public class ShipData : ScriptableObject
    {
        [field: SerializeField] public float MoveSpeed { get; private set; } = 1f;
        [field: SerializeField] public float StrafeSpeed { get; private set; } = 5f;
        [field: SerializeField] public Vector2 SpawnPoint { get; private set; } = new Vector2(0, -4f);
        [field: SerializeField] public float Damage { get; private set; } = 1f;
        [field: SerializeField] public float BulletSpeed { get; private set; } = 7f;
        [field: SerializeField] public float MaxCooldownShoot { get; private set; } = 1f;
        [field: SerializeField] public float MinCooldownShoot { get; private set; } = 0.1f;
        [field: SerializeField] public int Hearts { get; private set; } = 3;
    }
}