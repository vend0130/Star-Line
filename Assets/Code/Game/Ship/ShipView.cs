using Code.Game.Ship.Gun;
using UnityEngine;

namespace Code.Game.Ship
{
    public class ShipView : MonoBehaviour
    {
        [field: SerializeField] public ShipMove ShipMove { get; private set; }
        [field: SerializeField] public Guns Guns { get; private set; }
        [field: SerializeField] public ShipHealth Health { get; private set; }
        [field: SerializeField] public ShipDeath ShipDeath { get; private set; }
    }
}