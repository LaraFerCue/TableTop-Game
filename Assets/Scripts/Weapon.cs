using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int minDamage = 1;
    public int maxDamage = 2;
    public string[] targets;

    public abstract void Attack(GameObject target);

    private void OnCollisionEnter(Collision collision)
    {
        foreach (string tag in targets)
        {
            if (collision.transform.gameObject.tag == tag)
                Attack(collision.transform.gameObject);
        }
    }
}
