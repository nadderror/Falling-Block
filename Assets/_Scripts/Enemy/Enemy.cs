using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(EnemyFalling))]
[RequireComponent(typeof(EnemyChase))]
[RequireComponent(typeof(EnemyFalling2))]
public class Enemy : MonoBehaviour, IDamageable
{
    private float health = 2;
    public Action<GameObject> disableLikeDie;
    EnemySO[] Enemies;
    private EnemySO currentEnemyType;
    EnemyTypes myType;
    private float speed;
    private float enemySize;
    private Vector2 screenHalfSizeWorldUnits;
    private Vector2 spawnPos;
    private GameObject playerOBJ;

    private void Awake()
    {
        Enemies = EnemiesSpawner.I.Enemies;
        screenHalfSizeWorldUnits =
            new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
        playerOBJ = FindObjectOfType<Player>().gameObject;
        //GetComponent<TrailRenderer>().enabled = false;
    }


    public enum EnemyTypes
    {
        Falling = 0,
        MoveLikePlayer = 1,
        Chaser = 2
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Destroyer")
        {
            disableLikeDie(gameObject);
        }

        else if (col.gameObject.tag == "Player")
        {
            col.GetComponent<IDamageable>().TakeDamage(1);
        }
    }

    private void OnEnable()
    {
        GetComponent<TrailRenderer>().Clear();
        ChooseMyType();
        ChooseColor(myType);
        ChooseMyScale();
        ChooseMyPos();
        ChooseMyRotation();
        
    }

    private void OnDisable()
    {
        //GetComponent<TrailRenderer>().enabled = false;
        ChooseMyPos();
    }

    void ChooseMyType()
    {
        int currentDiffLevel = Difficulty.I.CurrentDifficultyLevel;
        myType = (EnemyTypes) Random.Range(0, currentDiffLevel);
        currentEnemyType = Enemies[(int) myType];

        GetComponent<EnemyFalling>().enabled = myType == EnemyTypes.Falling;
        GetComponent<EnemyChase>().enabled = myType == EnemyTypes.Chaser;
        GetComponent<EnemyFalling2>().enabled = myType == EnemyTypes.MoveLikePlayer;
    }

    void ChooseColor(EnemyTypes eT)
    {
        GetComponent<SpriteRenderer>().color = currentEnemyType.GetColor();
    }


    private void ChooseMyScale()
    {
        var sizeMinMax = currentEnemyType.GetSizeMinMax();
        enemySize = Random.Range(sizeMinMax.x, Random.Range(sizeMinMax.y, sizeMinMax.z));
        transform.localScale = Vector2.one * enemySize;
    }

    void ChooseMyPos()
    {
        spawnPos = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x),
            screenHalfSizeWorldUnits.y + (enemySize / 2));
        transform.position = spawnPos;
    }

    void ChooseMyRotation()
    {
        var enemyDirection = Random.Range(5, 25f);
        switch (currentEnemyType.GetRotationType())
        {
            case EnemySO.RotationType.Random:
                transform.eulerAngles = Vector3.forward * (spawnPos.x < 0 ? enemyDirection : -enemyDirection);
                break;
            case EnemySO.RotationType.playerX:
                var playerPos = playerOBJ.transform.position;
                enemyDirection = playerPos.x < 0 ? -enemyDirection :enemyDirection;
                transform.eulerAngles = Vector3.forward * enemyDirection;
                break;
            //case EnemySO.RotationType.Chase:
            //    break;
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

    public void InitAction(Action<GameObject> _action)
    {
        disableLikeDie = _action;
    }


    public float SetAndGetSpeed()
    {
        Vector3 s;
        s = currentEnemyType.GetEnemySpeedMinMax();
        speed = Mathf.Lerp(s.x, Random.Range(s.y, s.z), Difficulty.I.GetDifficulltyPercent());
        return speed;
    }
}