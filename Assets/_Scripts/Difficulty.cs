using System;
using System.Collections;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField] private DifficultySo gameDifficulty;
    public static Difficulty I;
    int currentDifficultyLevel;
    private Vector2 secondsBetweenSpawn;
    public Vector2 SecondsBetweenSpawn
    {
        get { return secondsBetweenSpawn; }
    }

    public int CurrentDifficultyLevel
    {
        get { return currentDifficultyLevel; }
    }

    private bool isReachedToMaxDifficulty = false;

    private void Awake()
    {
        I = this;
        secondsBetweenSpawn = gameDifficulty.GetSecondsOfSpawnMinMax();
    }

    private IEnumerator Start()
    {
        currentDifficultyLevel = 0;
        while (!isReachedToMaxDifficulty)
        {
            yield return new WaitForSeconds(gameDifficulty.GetSecondsToAddToDifficuly());
            currentDifficultyLevel++;
            if (currentDifficultyLevel >= gameDifficulty.GetMaxDifficultyLevel())
            {
                isReachedToMaxDifficulty = true;
            }
        }
    }

    public float GetDifficulltyPercent()
    {
        float targetTime = Time.timeSinceLevelLoad;
        return Mathf.Clamp01(targetTime / gameDifficulty.GetSecondsToMaxDifficullty());
    }
}