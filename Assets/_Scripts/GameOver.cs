using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver: MonoBehaviour
{
    static bool isGameOver;
    public static bool IsGameOver
    {
       get { return isGameOver; }
    }
   public event Action OnGameOver;
   [SerializeField] private GameObject gameOverScreen;
   [SerializeField] private TextMeshProUGUI score;
   void Start()
   {
      isGameOver = false;
      gameOverScreen.SetActive(false);
      FindObjectOfType<Player>().GetComponent<Health>().onDeath += PlayerDeath;
      OnGameOver += GameIsOver;
   }

   private void Update()
   {
      if (isGameOver)
      {
         if (Input.GetKeyDown(KeyCode.Space))
         {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         }
      }
   }

   private void PlayerDeath()
   {
      OnGameOver?.Invoke();
      gameOverScreen.SetActive(true);
      score.text = Time.timeSinceLevelLoad.ToString();
   }

   void GameIsOver()
   {
      isGameOver = true;
   }
   
}