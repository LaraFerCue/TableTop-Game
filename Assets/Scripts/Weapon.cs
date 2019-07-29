using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public abstract class Weapon : MonoBehaviour
{
    public int minDamage = 1;
    public int maxDamage = 2;
    public string[] targets;

    public abstract void Damage(GameObject target);

    private void Attack(Collider collision)
    {
        Debug.Log("Attacking");
        foreach (string tag in targets)
        {
            if (collision.transform.gameObject.tag == tag)
                Damage(collision.transform.gameObject);
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
