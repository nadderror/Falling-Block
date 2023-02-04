/*
 * DifficultySo.cs
 * Created by: #AUTHOR#
 * Created on: #CREATIONDATE#
*/

using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = ("New DifficultySo"), menuName = ("Scriptable Objects/DifficultySo"), order = 0)]
public class DifficultySo : ScriptableObject
{
    [SerializeField] private float SecondsToMaxDifficullty;

    public float GetSecondsToMaxDifficullty()
    {
        return SecondsToMaxDifficullty;
    }

    [SerializeField] private int SecondsToAddToDifficuly;

    public int GetSecondsToAddToDifficuly()
    {
        return SecondsToAddToDifficuly;
    }

    [SerializeField] private float MaxDifficultyLevel;

    public float GetMaxDifficultyLevel()
    {
        return MaxDifficultyLevel;
    }
}