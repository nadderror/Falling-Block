/*
 * EnemyMoveToPlayer.cs
 * Created by: #AUTHOR#
 * Created on: #CREATIONDATE#
*/

using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyChase : MonoBehaviour, IFollower
{
    private GameObject playerGameObject;
    private Vector3 targetDirection;
    private float moveSpeed;
    private Enemy myEnemy;
    private bool isChasing = true;

    public bool IsChasing
    {
        get { return isChasing; }
    }

    private void Awake()
    {
        myEnemy = GetComponent<Enemy>();
    }

    void Start()
    {
        FindObjectOfType<GameOver>().OnGameOver += TargetDied;
        playerGameObject = FindObjectOfType<Player>().gameObject;
    }

    private void OnEnable()
    {
        moveSpeed = myEnemy.SetAndGetSpeed();
    }

    private void Update()
    {
        FollowTarget(playerGameObject);
    }

    public void FollowTarget(GameObject target)
    {
        if (!GameOver.IsGameOver)
        {
            targetDirection = (target.transform.position - transform.position);
            targetDirection.Normalize();
        }
        

        float angel = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position,
            playerGameObject.transform.position,
            moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angel);
    }

    void TargetDied()
    {
        targetDirection = Random.insideUnitCircle.normalized;
        isChasing = false;
        moveSpeed /= 7;
    }
}