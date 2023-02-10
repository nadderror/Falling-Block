using UnityEngine;

[CreateAssetMenu(fileName = ("New EnemySO"), menuName = ("Scriptable Objects/EnemySO"), order = 0)]
public class EnemySO : ScriptableObject
{
    public enum RotationType
    {
        Random = 0,
        playerX = 1,
        Chase = 2
    }

    [SerializeField] private RotationType rotationType;

    public RotationType GetRotationType()
    {
        return rotationType;
    }
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
}