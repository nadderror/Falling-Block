using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private float health = 2;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
            //col.gameObject.GetComponent<IDamageable>().TakeDamage(1);
        }
    }

    public void TakeDamage(float damageAmounth)
    {
        health -= damageAmounth;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}