/*
 * EnemiesSpawner.cs
 * Created by: #AUTHOR#
 * Created on: #CREATIONDATE#
*/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    static EnemiesSpawner _i; //  _i ←→ _instance 
    public EnemySO[] Enemies;
    private Vector2 screenHalfSizeWorldUnits;
    [SerializeField] GameObject Enemy;
    private bool canSpawn = true;
    private ObjectPool<GameObject> pool;

    public static EnemiesSpawner I
    {
        //  _i ←→ Instance 
        get
        {
            //Singleton
            if (_i == null) //Are we have EnemiesSpawner before? Checking...
            {
                _i = FindObjectOfType<EnemiesSpawner>();
                if (_i == null)
                {
                    //Ok... we dont have any <EnemiesSpawner>(); then create that
                    GameObject myEnemiesSpawner = new GameObject("EnemiesSpawner");
                    myEnemiesSpawner.AddComponent<EnemiesSpawner>();
                    _i = myEnemiesSpawner.GetComponent<EnemiesSpawner>();
                }
            }

            //return _i anyway
            return _i;
        }
    }

    private void Awake()
    {
        if (_i != null) // if we have _i (EnemiesSpawner) before, then destroy me bos...
            Destroy(this);
        //DontDestroyOnLoad(this.gameObject); //it's ok... i'am first <EnemiesSpawner>() now.
    }

    private void OnEnable()
    {
        canSpawn = true;
    }

    void Start()
    {
        FindObjectOfType<GameOver>().OnGameOver += StopSpawning;
        pool = new ObjectPool<GameObject>(CreateBullet, OnGet, OnRelease, OnDestroyBullet, false, 5, 100);
        screenHalfSizeWorldUnits =
            new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
        StartCoroutine(SpawnEnemy());
    }

    private void OnDestroyBullet(GameObject obj)
    {
        Destroy(obj);
    }

    private void OnRelease(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnGet(GameObject obj)
    {
        EnemyDisplayerCompany(obj);
        obj.SetActive(true);
    }

    public void OnReleaseBullet(GameObject bullet)
    {
        pool.Release(bullet);
    }

    private GameObject CreateBullet()
    {
        GameObject newEnemy = (GameObject) Instantiate(Enemy, Vector3.zero, Quaternion.identity);
        newEnemy.transform.parent = gameObject.transform;
        EnemyDisplayerCompany(newEnemy);
        return newEnemy;
    }

    void EnemyDisplayerCompany(GameObject enemy)
    {
        var enemySize = Random.Range(1, 5f);
        Vector2 spawnPos = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x),
            screenHalfSizeWorldUnits.y + (enemySize / 2));
        enemy.transform.position = spawnPos;
        enemy.transform.localScale = Vector2.one * enemySize;
        var enemyDirection = Random.Range(-5, 25);
        enemy.transform.eulerAngles = Vector3.forward * (spawnPos.x < 0 ? enemyDirection : -enemyDirection);
    }

    IEnumerator SpawnEnemy()
    {
        while (canSpawn)
        {
            pool.Get().GetComponent<Enemy>().InitAction(OnReleaseBullet);
            float secondsBetweenSpawn = Mathf.Lerp(1, 0.35f, Difficulty.I.GetDifficulltyPercent());
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }

    void StopSpawning()
    {
        canSpawn = false;
    }
}