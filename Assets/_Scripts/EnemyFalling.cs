using System;
using UnityEngine;

public class EnemyFalling : MonoBehaviour
{
    private float fallingSpeed;

    public float FallingSpeed
    {
        set { fallingSpeed = value; }
        get { return fallingSpeed; }
    }

    private void OnEnable()
    {
        fallingSpeed = Mathf.Lerp(10, 40, Difficulty.getDifficulltyPercent());
    }

    private void Awake()
    {
    }

    void Update()
    {
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime, Space.Self);
    }
}