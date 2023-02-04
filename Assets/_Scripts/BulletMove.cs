/*
 * BulletMove.cs
 * Created by: #AUTHOR#
 * Created on: #CREATIONDATE#
*/

using System;
using UnityEngine;

public class BulletMove: MonoBehaviour
{
   void Start()
   {
      
   }

   private void Update()
   {
       transform.Translate(Vector3.up * 10 * Time.deltaTime);
   }
}