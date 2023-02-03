using System;
using Code.Services.Bonuses;
using UnityEngine;

namespace Code.StaticData.Bonuses
{
    [Serializable]
    public class BonusData
    {
        [field: SerializeField, HideInInspector] public string Name { get; set; }

        [field: SerializeField] public BonusView Prefab { get; private set; }
        [field: SerializeField] public TypeBonus Type { get; private set; }
    }
}