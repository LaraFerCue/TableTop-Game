using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
        public float speed = 10.0f;
        public float timeToLive = 600.0f;
        public int damage;
        public string targetTag;

        // Start is called before the first frame update
        void OnEnable()
        {
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
            Destroy(gameObject, timeToLive);
        }

        private void OnTriggerEnter(Collider other)
        {
            Character character = other.GetComponent<Character>();
            if (character != null && other.transform.gameObject.tag == targetTag)
            {
                Destroy(gameObject);
                character.ApplyDamage(damage);
            }
        }
    }
}