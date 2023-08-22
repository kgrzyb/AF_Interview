using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public class Army : MonoBehaviour
    {
        [SerializeField] BoxCollider armyBounds;
        [SerializeField] List<UnitName> armyUnits = new();

        public List<UnitName> ArmyUnits => armyUnits;
        public Bounds ArmyBounds => armyBounds.bounds;
    }
}
