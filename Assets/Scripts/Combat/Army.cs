using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public class Army : MonoBehaviour
    {
        [SerializeField] ArmyId armyId;
        [SerializeField] Army enemyArmy;
        [SerializeField] BoxCollider armyBounds;
        [SerializeField] List<UnitName> armyUnits = new();

        private List<Unit> availableUnits= new();

        private List<Unit> unitsOrder = new();

        public List<UnitName> ArmyUnits => armyUnits;
        public ArmyId ArmyId => armyId;
        public Bounds ArmyBounds => armyBounds.bounds;
        public bool IsArmyDefeated => availableUnits.Count <= 0;

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

        public void Attack()
        {
            foreach(var unit in unitsOrder)
            {
                if (unit.IsAttackAvailable())
                {
                    var unitToAttack = enemyArmy.SelectUnitForAttack();
                    Debug.Log("Unit " + unit.UnitName + " of " + ArmyId + " attacked unit " + unitToAttack.UnitName);
                    unit.Attack(unitToAttack);
                }
                else
                {
                    Debug.Log("Unit " + unit.UnitName + " of " + ArmyId + " need wait " + unit.TurnsToNextAttack + " turns");
                }
            }
        }

        public Unit SelectUnitForAttack()
        {
            return GetUnit(availableUnits);
        }

        public void AddUnit(Unit unit)
        {
            availableUnits.Add(unit);
        }

        public void RemoveDeadUnit(Unit unit)
        {
            availableUnits.Remove(unit);
            unitsOrder.Remove(unit);
        }
    }
}
