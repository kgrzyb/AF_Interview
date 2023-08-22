using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public class UnitFactory : MonoBehaviour
    {
        [SerializeField] AllUnitsCollection allUnitsCollection;

        public Unit CreateUnit(UnitName unitName, Vector3 spawnPos, Quaternion rotation, Transform armyParent)
        {
            var unit = allUnitsCollection.GetUnit(unitName);
            Unit instance = Instantiate(unit, spawnPos,rotation, armyParent) as Unit;
            
            return instance;
        }
    }
}
