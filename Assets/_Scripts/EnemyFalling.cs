using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyFalling : MonoBehaviour
{
    private float fallingSpeed;
    private void Start()
    {
        FindObjectOfType<GameOver>().OnGameOver += StopMoving;
    }

    private void OnEnable()
    {
        fallingSpeed = Mathf.Lerp(10, Random.Range(30,50), Difficulty.getDifficulltyPercent());
    }

    private void StopMoving()
    {
        fallingSpeed = fallingSpeed / 9;
    }
    
    void Update()
    {
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime, Space.Self);
    }
}