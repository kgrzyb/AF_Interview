using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public class CombatManager : MonoBehaviour
    {
        [SerializeField] UnitFactory unitFactory;
        [SerializeField] List<Army> armies;


        private void Start()
        {
            CreateArmies();
        }


        private void CreateArmies()
        {
            foreach(Army army in armies)
            {
                for(int i=0; i < army.ArmyUnits.Count; i++)
                {
                    var unitName = army.ArmyUnits[i];
                    var spawnPos = GetRandomSpawnPositionInBounds(army.ArmyBounds);
                    unitFactory.CreateUnit(unitName, spawnPos, Quaternion.identity, army.transform);
                }
            }
        }
        private Vector3 GetRandomSpawnPositionInBounds(Bounds bounds)
        {
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                0f,
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }
    }

}
