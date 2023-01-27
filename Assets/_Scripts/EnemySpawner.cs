using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Vector2 screenHalfSizeWorldUnits;
    [SerializeField] GameObject[] Enemys;

    void Start()
    {
        screenHalfSizeWorldUnits =
            new Vector2(Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize);
        StartCoroutine(SpawnEnemy());
    }

    void Update()
    {
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < 60; i++)
        {
            var enemySize = Random.Range(1, 5f);
            Vector2 spawnPos = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x),
                screenHalfSizeWorldUnits.y + (enemySize / 2));


            GameObject newEnemy = (GameObject) Instantiate(Enemys[Random.Range(0, Enemys.Length - 1)], spawnPos,
                Quaternion.identity);
            newEnemy.transform.localScale = Vector2.one * enemySize;
            var enemyDirection = Random.Range(0, 35f);
            newEnemy.transform.Rotate(Vector3.forward * (spawnPos.x < 0 ? enemyDirection : -enemyDirection));
            newEnemy.GetComponent<EnemyFalling>().FallingSpeed = Mathf.Lerp(10, 20, Difficulty.getDifficulltyPercent());

            float secondsBetweenSpawn = Mathf.Lerp(2, 0.5f, Difficulty.getDifficulltyPercent());
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}