using System;
using UnityEngine;

public class GameOver: MonoBehaviour
{
   public event Action OnGameOver;
   [SerializeField] private GameObject gameOverScreen;
   void Start()
   {
      gameOverScreen.SetActive(false);
      FindObjectOfType<Player>().GetComponent<Health>().onDeath += PlayerDeath;
   }

   private void PlayerDeath()
   {
      OnGameOver?.Invoke();
      print("player Death");
      gameOverScreen.SetActive(true);
   }
}