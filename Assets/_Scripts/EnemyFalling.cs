using UnityEngine;

public class EnemyFalling : MonoBehaviour
{
    private float fallingSpeed = 10;
    void Update()
    {
        transform.Translate(Vector2.down*fallingSpeed * Time.deltaTime,Space.Self);
    }
}
