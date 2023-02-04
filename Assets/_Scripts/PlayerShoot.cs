/*
 * PlayerShoot.cs
 * Created by: #AUTHOR#
 * Created on: #CREATIONDATE#
*/

using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour, IShootable
{
    [SerializeField] GameObject bulletPrefab;

    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Fire(bulletPrefab);
    }

    public void Fire(GameObject obj)
    {
        var firePos = transform.position;
        //var offset = transform.localScale / 2;
        //var finalPos = firePos + offset;
        var angel = transform.eulerAngles;
        GameObject newBullet = (GameObject) Instantiate(obj, firePos, Quaternion.Euler(angel.x, angel.y, angel.z));
        newBullet.transform.parent = transform;
        
    }
}