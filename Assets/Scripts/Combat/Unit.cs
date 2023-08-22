using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] UnitName unitName;
        private Army army;
        private UnitAtribute atributes;
        private int currentHealth;
        private int armor;
        private int damage;
        private int attackInterval;
        private List<DamageOverride> damageOverrides;

        private int turnsToNextAttack;

        public Army Army { get => army; set => army = value; }

        public UnitName UnitName => unitName;

        public int Damage { get => damage; set => damage = value; }
        public List<DamageOverride> DamageOverrides { get => damageOverrides; set => damageOverrides = value; }
        public UnitAtribute Atributes { get => atributes; set => atributes = value; }
        public int AttackInterval { get => attackInterval; set => attackInterval = value; }
        public int TurnsToNextAttack  => turnsToNextAttack;

        private void OnEnable()
        {
            CombatManager.OnTurnEnded += HandleTurnEnded;
        }

        private void OnDisable()
        {
            CombatManager.OnTurnEnded -= HandleTurnEnded;
        }

        private void HandleTurnEnded(Army army)
        {
            if (Army != army)
                WaitTurn();
        }

        public void SetCurrentHealt(int health)
        {
            currentHealth = health;
        }

        public void SetArmor(int armor)
        {
            this.armor = armor;
        }

        public bool IsAttackAvailable()
        {
            return turnsToNextAttack <= 1;
        }

        private void WaitTurn()
        {
            turnsToNextAttack--;
        }

        public void Attack(Unit unit)
        {
            unit.ReceiveDamage(GetDamageAgainst(unit.atributes));
            turnsToNextAttack = attackInterval;
        }

        public void ReceiveDamage(int damage)
        {
            int finalDamage = (int)Mathf.Clamp(damage - armor, 1, Mathf.Infinity);
            currentHealth -= finalDamage;
            Debug.Log(unitName + " received " + finalDamage + " damage | Current HP: " + currentHealth);
            CheckIfDead();
        }


        private void CheckIfDead()
        {
            if (currentHealth <= 0)
            {
                army.RemoveDeadUnit(this);
                Destroy(this.gameObject);
            }
        }

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
}
