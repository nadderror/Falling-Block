
using UnityEngine;

public class EnemyFalling2 : MonoBehaviour
{
    private float fallingSpeed;
    private Enemy myEnemy;

    private void Awake()
    {
        myEnemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        FindObjectOfType<GameOver>().OnGameOver += StopMoving;
    }
    private void OnEnable()
    {
        fallingSpeed = myEnemy.SetAndGetSpeed();
    }
    private void Update()
    {
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime, Space.Self);
    }
    private void StopMoving()
    {
        fallingSpeed = fallingSpeed / 9;
    }
    
}