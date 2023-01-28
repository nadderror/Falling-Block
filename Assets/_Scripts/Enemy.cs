using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private float health = 2;
    public Action<GameObject> action;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Destroyer")
        {
            action(gameObject);
        }

        else if (col.gameObject.tag == "Player")
        {
            col.GetComponent<IDamageable>().TakeDamage(1);
        }
    }

    public void InitAction(Action<GameObject> _action)
    {
        action = _action;
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