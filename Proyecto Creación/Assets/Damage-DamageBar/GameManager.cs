using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
}
