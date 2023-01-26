using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private float health = 2;

    void Start()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<IDamageable>().TakeDamage(1);
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