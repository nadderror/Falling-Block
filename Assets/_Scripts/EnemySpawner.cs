using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    private Vector2 screenHalfSizeWorldUnits;
    [SerializeField] GameObject[] Enemys;
    private bool canSpawn = true;
    private ObjectPool<GameObject> pool;

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
        GameObject newEnemy = (GameObject) Instantiate(Enemys[Random.Range(0, Enemys.Length - 1)], Vector3.zero,
            Quaternion.identity);
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
        //enemy.transform.Rotate();
    }

    IEnumerator SpawnEnemy()
    {
        while (canSpawn)
        {
            pool.Get().GetComponent<Enemy>().InitAction(OnReleaseBullet);
            float secondsBetweenSpawn = Mathf.Lerp(1, 0.35f, Difficulty.getDifficulltyPercent());
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }

    void StopSpawning()
    {
        canSpawn = false;
    }
}