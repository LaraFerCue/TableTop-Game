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
    }
}