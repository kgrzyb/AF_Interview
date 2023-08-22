using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField] UnitFactory unitFactory;
        [SerializeField] List<Army> armies;

        public static Action<Army> OnTurnEnded;

        private int currentAttackingArmyIndex;

        public bool isGameOver = false;

        private void Start()
        {
            CreateArmies();
            currentAttackingArmyIndex = UnityEngine.Random.Range(0, armies.Count);
        }

        private void Update()
        {
            if (!isGameOver)
            {
                if (Input.GetKeyDown(KeyCode.T))
                    PlayTurn();
            }
        }

        private void PlayTurn()
        {
            var currentArmy = armies[currentAttackingArmyIndex];
            currentArmy.Attack();
            OnTurnEnded?.Invoke(currentArmy);
            ChangeTurn();
        }

        private void ChangeTurn()
        {
            CheckForGameOver();
            currentAttackingArmyIndex++;
            if (currentAttackingArmyIndex >= armies.Count)
                currentAttackingArmyIndex = 0;
        }


        private void CreateArmies()
        {
            foreach (Army army in armies)
            {
                for (int i = 0; i < army.ArmyUnits.Count; i++)
                {
                    var unitName = army.ArmyUnits[i];
                    var spawnPos = GetRandomSpawnPositionInBounds(army.ArmyBounds);
                    var unit = unitFactory.CreateUnit(unitName, spawnPos, Quaternion.identity, army.transform);
                    unit.ArmyId = army.ArmyId;
                    army.availableUnits.Add(unit);
                }
                army.SetTurnOrder();
            }

        }

        private void CheckForGameOver()
        {
            foreach (var army in armies)
            {
                if (army.IsArmyDefeated)
                {
                    isGameOver = true;
                    Debug.Log(army.ArmyId + " was defeated!");
                }
            }
        }

        private Vector3 GetRandomSpawnPositionInBounds(Bounds bounds)
        {
            return new Vector3(
                UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
                0f,
                UnityEngine.Random.Range(bounds.min.z, bounds.max.z)
            );
        }
    }

}
