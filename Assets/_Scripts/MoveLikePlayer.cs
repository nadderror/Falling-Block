/*
 * MoveLikePlayer.cs
 * Created by: #AUTHOR#
 * Created on: #CREATIONDATE#
*/

using System;
using System.Collections;
using UnityEngine;

public class MoveLikePlayer : MonoBehaviour
{
    private GameObject playerGameObject;
    private float speed;
    private Enemy myEnemy;

    private void Awake()
    {
        myEnemy = GetComponent<Enemy>();
    }

    void Start()
    {
        playerGameObject = FindObjectOfType<Player>().gameObject;
    }

    private void Update()
    {
        Move(playerGameObject);
    }

    void Move(GameObject obj)
    {
        var targetPos = obj.transform.position.normalized;
        targetPos = new Vector3(targetPos.x, -Mathf.Abs(targetPos.y), targetPos.z);
        transform.Translate(targetPos * myEnemy.SetAndGetSpeed() * Time.deltaTime);
    }

    IEnumerator StartLifrTime()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
    }
}