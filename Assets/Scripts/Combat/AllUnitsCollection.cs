using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    [CreateAssetMenu(fileName = "UnitsCollection", menuName = "Create Unit Collection")]
    public class AllUnitsCollection : ScriptableObject
    {
        public List<Unit> units;

        public Unit GetUnit(UnitName unitName)
        {
            foreach(var unit in units)
            {
                if (unit.UnitConfig.UnitName == unitName)
                    return unit;
            }
            Debug.LogError("No unit config with given name: " + unitName);
            return null;
        }
    }

}
