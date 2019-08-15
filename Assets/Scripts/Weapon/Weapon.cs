using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public abstract class Weapon : MonoBehaviour
{
    public int minDamage = 1;
    public int maxDamage = 2;
    public string[] targets;
    public float attackTime = 1.0f;
    private float timeout = 0.0f;

    private void Awake()
    {
        timeout = 0.0f;
    }

    public abstract void Damage(GameObject target);

    protected void Attack(Collider collision)
    {
        foreach (string tag in targets)
        {
            if (collision.transform.gameObject.tag == tag)
            {
                if (timeout >= attackTime)
                {
                    Damage(collision.transform.gameObject);
                    timeout = 0.0f;
                }
                timeout += Time.deltaTime;
            }
        }
    }

}
