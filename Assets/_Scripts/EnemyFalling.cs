using System;
using UnityEngine;

public class EnemyFalling : MonoBehaviour
{
    private float fallingSpeed;
    private void OnEnable()
    {
        fallingSpeed = Mathf.Lerp(10, 40, Difficulty.getDifficulltyPercent());
    }
    private void Start()
    {
        FindObjectOfType<GameOver>().OnGameOver += StopMoving;
    }

    private void StopMoving()
    {
        fallingSpeed = 0.5f;
    }

    
    

    void Update()
    {
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime, Space.Self);
    }
}