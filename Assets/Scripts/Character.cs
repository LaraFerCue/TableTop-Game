using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private int hitPoints = 10;
        private int currentHitPoints = 10;

        [SerializeField]
        private int armorClass;

        public int HitPoints { get { return currentHitPoints; } }

        private void Awake()
        {
            currentHitPoints = hitPoints;
        }

        public void ApplyDamage(int damage)
        {
            currentHitPoints -= damage;
        }
    }
}