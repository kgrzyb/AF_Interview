using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    [CreateAssetMenu(fileName = "UnitsConfigs", menuName = "All Units Configs")]
    public class AllUnitsConfigs  : ScriptableObject
    {
        public List<UnitConfig> unitConfigs;

        public UnitConfig GetUnitConfig(UnitName unitName)
        {
            foreach(var unit in unitConfigs)
            {
                if (unit.UnitName == unitName)
                    return unit;
            }
            Debug.LogError("No unit config with given name: " + unitName);
            return null;
        }
    }

}
