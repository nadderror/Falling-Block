using UnityEngine;

public class EnemyFalling : MonoBehaviour
{
    private float fallingSpeed;

    public float FallingSpeed
    {
        set { fallingSpeed = value; }
        get { return fallingSpeed; }
    }


    void Update()
    {
        transform.Translate(Vector2.down * fallingSpeed * Time.deltaTime, Space.Self);
    }
}