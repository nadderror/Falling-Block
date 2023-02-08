/*
 * EnemyDecay.cs
 * Created by: #AUTHOR#
 * Created on: #CREATIONDATE#
*/

using System;
using System.Collections;
using UnityEngine;

public class EnemyDecay : MonoBehaviour
{
    private EnemyChase enemyChase;
    private float startTime;
    private bool isDecayOn = false;

    void Start()
    {
        enemyChase = GetComponent<EnemyChase>();
    }

    private void OnEnable()
    {
        startTime = Time.timeSinceLevelLoad;
    }

    private void Update()
    {
        if (GetComponent<EnemyChase>().enabled)
            if (enemyChase.IsChasing)
            {
                if (!isDecayOn)
                {
                    StartCoroutine(decay());
                }
            }
    }

    IEnumerator decay()
    {
        isDecayOn = true;
        var scale = transform.localScale.x;
        while (isDecayOn)
        {
            transform.localScale = Vector2.one * (transform.localScale.x - 0.05f);
            yield return new WaitForSeconds(0.01f);
            if (transform.localScale.x <= 1f)
            {
                GetComponent<Enemy>().disableLikeDie(gameObject);
                isDecayOn = false;
            }
        }
    }
}