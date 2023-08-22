using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public class UnitFactory : MonoBehaviour
    {
        [SerializeField] AllUnitsConfigs allUnitsConfigs;
        [SerializeField] AllUnitsCollection allUnitsCollection;

        public Unit CreateUnit(UnitName unitName, Vector3 spawnPos, Quaternion rotation, Transform armyParent)
        {
            var unitPrefab = allUnitsCollection.GetUnit(unitName);
            var unitConfig = allUnitsConfigs.GetUnitConfig(unitName);
            Unit unit= Instantiate(unitPrefab, spawnPos,rotation, armyParent);
            unit.SetCurrentHealt(unitConfig.Hp);
            unit.SetArmor(unitConfig.Armor);
            unit.Atributes = unitConfig.Atributes;
            unit.AttackInterval = unitConfig.AttackInterval;
            unit.Damage = unitConfig.Damage;
            unit.DamageOverrides = unitConfig.DamageOverrides;

            return unit;
        }
    }
}
