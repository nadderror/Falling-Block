using UnityEngine;

[CreateAssetMenu(fileName = ("New EnemySO"), menuName = ("Scriptable Objects/EnemySO"), order = 0)]
public class EnemySO : ScriptableObject
{
    [SerializeField] private Color enemyColor;

    public Color GetColor()
    {
        return enemyColor;
    }

    //x = beginning min , y = min , z = max
    [SerializeField] private Vector3 enemySpeedMinMax;

    public Vector3 GetEnemySpeedMinMax()
    {
        return enemySpeedMinMax;
    }

//x = beginning min , y = min , z = max
    [SerializeField] private Vector3 enemySizeMinMax;

    public Vector3 GetSizeMinMax()
    {
        return enemySizeMinMax;
    }

    //each enemy, when can enter in game play?
    [SerializeField] private float enemyEnterPermitTime;

    public float GetEnterPermitTime()
    {
        return enemyEnterPermitTime;
    }
}