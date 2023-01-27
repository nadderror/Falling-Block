using UnityEngine;

public static class Difficulty
{
    static float secondsToMaxDifficullty=10;

    public static float getDifficulltyPercent()
    {
        float targetTime = Time.time;
        return Mathf.Clamp01(targetTime/secondsToMaxDifficullty);
    }
}
