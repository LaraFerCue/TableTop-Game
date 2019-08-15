using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts {
    public class RangedWeapon : Weapon
    {
        public GameObject projectile;

        public override void Damage(GameObject target)
        {
            Quaternion rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
            GameObject prefab = Instantiate(this.projectile, transform.position, rotation);
            Projectile projectile = prefab.GetComponent<Projectile>();
            projectile.damage = Random.Range(minDamage, maxDamage);
            projectile.targetTag = target.tag;
        }

        private void OnTriggerEnter(Collider other)
        {
            Attack(other);
        }

        private void OnTriggerStay(Collider other)
        {
            Attack(other);
        }
    }
}
