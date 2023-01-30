using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(EnemyFalling))]
[RequireComponent(typeof(EnemyMoveToPlayer))]
[RequireComponent(typeof(MoveLikePlayer))]
public class Enemy : MonoBehaviour, IDamageable
{
    private float health = 2;
    public Action<GameObject> action;
    private Color[] enemyColors = new Color[3];
    EnemyTypes myType;

    public enum EnemyTypes
    {
        Falling = 0,
        Follower = 1,
        MoveLikePlayer = 2
    }

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

    private void Awake()
    {
        enemyColors[0] = new Color(1.0f, 0.4627451f, 0.2235294f, 1);
        enemyColors[1] = new Color(0.1798683f, 0.8113208f, 0.5136882f, 1);
        enemyColors[2] = new Color(0.4476996f, 0.9433962f, 0.2180491f, 1);
    }

    private void OnEnable()
    {
        ChooseMyType();
        ChooseColor(myType);
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

    void ChooseMyType()
    {
        myType = (EnemyTypes) Random.Range(0, 3);
        //EnemyTypes ETypes = (EnemyTypes) Random.Range(0, 3);

        GetComponent<EnemyFalling>().enabled = myType == EnemyTypes.Falling;
        GetComponent<EnemyMoveToPlayer>().enabled = myType == EnemyTypes.Follower;
        GetComponent<MoveLikePlayer>().enabled = myType == EnemyTypes.MoveLikePlayer;
    }

    void ChooseColor(EnemyTypes eT)
    {
        switch (eT)
        {
            case EnemyTypes.Falling:
                GetComponent<SpriteRenderer>().color = enemyColors[0];
                break;
            case EnemyTypes.Follower:
                GetComponent<SpriteRenderer>().color = enemyColors[1];
                break;
            case EnemyTypes.MoveLikePlayer:
                GetComponent<SpriteRenderer>().color = enemyColors[2];
                break;
        }
    }
}