using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class MeleeWeapon : Weapon
    {
        public override void Damage(GameObject target)
        {
            int damage = Random.Range(minDamage, maxDamage);
            Character character = target.GetComponent<Character>();

            if (character != null)
            {
                character.ApplyDamage(damage);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            Attack(other);
            Movement movement = gameObject.GetComponentInParent<Movement>();
            if (movement)
                movement.Stop();
        }

        private void OnTriggerStay(Collider other)
        {
            Attack(other);
        }
    }
}