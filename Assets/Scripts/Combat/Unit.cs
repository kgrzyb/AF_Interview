using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] UnitConfig unitConfig;

        public UnitConfig UnitConfig => unitConfig;

        public virtual void Attack(Unit unit) { }

    }
}
