using UnityEngine;

public static class Difficulty
{
    static float secondsToMaxDifficullty = 20;

    public static float GetDifficulltyPercent()
    {
        float targetTime = Time.timeSinceLevelLoad;
        return Mathf.Clamp01(targetTime / secondsToMaxDifficullty);
    }
}