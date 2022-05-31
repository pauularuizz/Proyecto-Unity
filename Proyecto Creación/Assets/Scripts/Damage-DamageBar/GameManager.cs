using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager myslf;
    int currentScore = 0;
    public Text scoreText, scoreTextBG;
    private void OnPlayerDeath(PlayerInfo playerInfo)
    {
        Debug.Log(playerInfo.Name + " died at age" + playerInfo.Age);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    private void OnEnable()
    {
        HealthSystem.PlayerDeath += OnPlayerDeath;
    }
    private void OnDisable()
    {
        HealthSystem.PlayerDeath -= OnPlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void AddScore(int pointsAdded)
    {
        myslf.currentScore += pointsAdded;
        myslf.scoreText.text = myslf.currentScore.ToString();
        myslf.scoreTextBG.text = myslf.currentScore.ToString();
        myslf.scoreText.transform.localScale = Vector3.one * 2.5f;
      
    }
    
}
