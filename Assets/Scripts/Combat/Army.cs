using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public class Army : MonoBehaviour
    {
        [SerializeField] ArmyId armyId;
        [SerializeField] BoxCollider armyBounds;
        [SerializeField] List<UnitName> armyUnits = new();

        public List<Unit> availableUnits;

        public List<Unit> unitsOrder;

        public List<UnitName> ArmyUnits => armyUnits;
        public ArmyId ArmyId => armyId;
        public Bounds ArmyBounds => armyBounds.bounds;
        public bool IsArmyDefeated => availableUnits.Count <= 0;

        private void OnEnable()
        {
            Unit.OnUnitKilled += HandleUnitKilled;
        }

        private void HandleUnitKilled(Unit unit)
        {
            availableUnits.Remove(unit);
            unitsOrder.Remove(unit);
            Destroy(unit.gameObject);
        }

        public void SetTurnOrder()
        {
            var units = new List<Unit>(availableUnits);
            for(int i = 0; i < armyUnits.Count; i++)
            {
                var unit = GetUnit(units);
                units.Remove(unit);
                unitsOrder.Add(unit);
            }
        }

        public Unit GetUnit(List<Unit> units)
        {
            var randIndex = Random.Range(0, units.Count);
            var unit = units[randIndex];
            return unit;
        }

        public bool TryGetAvailableUnitTurn(out Unit availableUnit)
        {
            foreach(var unit in unitsOrder)
            {
                if (unit.IsAttackAvailable())
                {
                    availableUnit = unit;
                    return true;
                }
            }
            availableUnit = null;
            return false;
        }

        public Unit SelectUnitForAttack()
        {
            return GetUnit(availableUnits);
        }
    }
}
