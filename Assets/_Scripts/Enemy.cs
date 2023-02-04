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
    EnemySO[] Enemies;
    EnemyTypes myType;
    private float speed;

    private void Awake()
    {
        Enemies = EnemiesSpawner.I.Enemies;
    }

    public enum EnemyTypes
    {
        Falling = 0,
        MoveLikePlayer = 1,
        Follower = 2
        
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
        int currentDiffLevel = Difficulty.I.CurrentDifficultyLevel;
        myType = (EnemyTypes) Random.Range(0, currentDiffLevel);
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
                GetComponent<SpriteRenderer>().color = Enemies[0].GetColor();
                break;
            case EnemyTypes.Follower:
                GetComponent<SpriteRenderer>().color = Enemies[1].GetColor();
                break;
            case EnemyTypes.MoveLikePlayer:
                GetComponent<SpriteRenderer>().color = Enemies[2].GetColor();
                break;
        }
    }

    public float SetAndGetSpeed()
    {
        Vector3 s;
        switch (myType)
        {
            case EnemyTypes.Falling:
                s = Enemies[0].GetEnemySpeedMinMax();

                break;
            case EnemyTypes.Follower:
                s = Enemies[1].GetEnemySpeedMinMax();
                break;
            case EnemyTypes.MoveLikePlayer:
                s = Enemies[2].GetEnemySpeedMinMax();
                break;
            default:
                s = Enemies[0].GetEnemySpeedMinMax();
                break;
        }

        speed = Mathf.Lerp(s.x, Random.Range(s.y, s.z), Difficulty.I.GetDifficulltyPercent());
        return speed;
    }
}