/*
 * EnemyMoveToPlayer.cs
 * Created by: #AUTHOR#
 * Created on: #CREATIONDATE#
*/

using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMoveToPlayer : MonoBehaviour, IFollower
{
    private GameObject playerGameObject;
    private Vector2 targetDirection;
    private float moveSpeed;

    void Start()
    {
        FindObjectOfType<GameOver>().OnGameOver += TargetDied;
        playerGameObject = FindObjectOfType<Player>().gameObject;
    }

    private void OnEnable()
    {
        moveSpeed = Mathf.Lerp(10, Random.Range(30, 50), Difficulty.getDifficulltyPercent());
    }

    private void Update()
    {
        FollowTarget(playerGameObject);
    }

    public void FollowTarget(GameObject target)
    {
        if (!GameOver.IsGameOver)
            targetDirection = (target.transform.position - transform.position).normalized;
        var velocity = targetDirection * moveSpeed;
        transform.Translate(velocity * Time.deltaTime);
    }

    void TargetDied()
    {
        targetDirection = Random.insideUnitCircle.normalized;
        moveSpeed = moveSpeed / 9;
    }
}