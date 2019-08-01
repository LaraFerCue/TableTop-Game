using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private int strength, dexterity, constitution, intelligence, wisdom, charisma;
        private int currentHitPoints = 10;

        [SerializeField]
        private int armorClass;

        [SerializeField]
        private int level, hitPointsPerLevel;

        public int HitPoints { get { return currentHitPoints; } }

        private void Awake()
        {
            armorClass = 10 + dexterity;
            currentHitPoints = (hitPointsPerLevel + constitution) * level;
        }

        public void ApplyDamage(int damage)
        {
            currentHitPoints -= damage;
        }
    }
}