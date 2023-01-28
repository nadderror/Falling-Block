using System;
using UnityEngine;

public class GameOver: MonoBehaviour
{
   public event Action OnGameOver;
   void Start()
   {
      FindObjectOfType<Player>().GetComponent<Health>().onDeath += PlayerDeath;
   }

   private void PlayerDeath()
   {
      OnGameOver?.Invoke();
      print("player Death");
   }
}