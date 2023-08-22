using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    [CreateAssetMenu(fileName = "Unit", menuName = "Create Unit Config")]
    public class UnitConfig : ScriptableObject
    {
        [SerializeField] UnitName unitName;
        [SerializeField] UnitAtribute atributes;
        [SerializeField] int hp;
        [SerializeField] int armor;
        [SerializeField] int attackInterval;
        [SerializeField] int damage;
        [SerializeField] List<DamageOverride> damageOverrides;

        public UnitName UnitName => unitName;
        public UnitAtribute Atributes => atributes;
        public int Hp => hp;
        public int Armor => armor;
        public int AttackInterval => attackInterval;

        public int GetDamageAgainst(UnitAtribute unitAtribute)
        {
            foreach (DamageOverride damageOverride in damageOverrides)
            {
                if (unitAtribute.HasFlag(damageOverride.UnitAtribute))
                    return damageOverride.Damge;
            }
            return damage;
        }

    }

    [Serializable]
    public struct DamageOverride
    {
        [SerializeField] UnitAtribute unitAtribute;
        [SerializeField] int damage;

        public UnitAtribute UnitAtribute => unitAtribute;
        public int Damge => damage;
    }
}
