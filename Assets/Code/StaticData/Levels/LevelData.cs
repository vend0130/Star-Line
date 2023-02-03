using Code.Game.Enemies;
using UnityEngine;

namespace Code.StaticData.Levels
{
    [CreateAssetMenu(fileName = nameof(LevelData), menuName = "Data/" + nameof(LevelData))]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField] public EnemiesContainer[] Containers { get; private set; }
    }
}