using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HealthSystem : MonoBehaviour, ITakeDamage
{  
    [SerializeField]
    PlayerInfo PlayerInfo;

    [SerializeField] float _currentHealth;
    [SerializeField]
    float _maxHealth = 100;
    public ParticleSystem ParticleSystemPrefab;
    public ParticleSystem HealthParticles;
    


    public static Action <PlayerInfo> PlayerDeath;
    public static Action<float > PlayerHealthChange;

   
    private void Start()
    {
        Cursor.visible = false;
        _currentHealth = _maxHealth;
        PlayerHealthChange?.Invoke(_currentHealth / _maxHealth);
        if (CompareTag("Boss"))
        {
            _currentHealth = 1000;

        }
        if (CompareTag("BadBoss"))
        {
            _currentHealth = 400; 
        }
    }
    public float CurrentHealth => _currentHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag ("Bullet"))
        {
            //CurrentHealth -= _bossdmg;
            Debug.Log("boss dmg");
            
        } 
    }

    public void TakeDamage(float damage)
    {
        if (damage>0)
        {
            Debug.Log("En teoria sale sangre");
            //Debug.Log("Boss dmg");
            Instantiate(ParticleSystemPrefab, transform.position, transform.rotation);
        }
        if (damage<0)
        {
            Instantiate(HealthParticles, transform.position, transform.rotation);
        }
        if (CompareTag("Bullet"))
        {
            Debug.Log("Daño Bala"); 
        }



        _currentHealth -= damage; 



        PlayerHealthChange?.Invoke(_currentHealth/_maxHealth);
       
    }
    

    private void Die()
    {
        
        PlayerDeath?.Invoke(PlayerInfo);
        if (CompareTag("Player"))
        {
            Debug.Log("player muere");
            Cursor.visible = true;
            SceneManager.LoadScene("MAIN MENU");

            Debug.Log("ABRE EL MENU");
        }
        
        Destroy(gameObject);

        
    }
    
    public Slider BarraVidaEnemigo;

    private void Update()
    {
        BarraVidaEnemigo.value = _currentHealth;
        if (_currentHealth <= 0)
        {
            Die();
           
        }
        if (_currentHealth>100 && !CompareTag("Boss"))
        {

            _currentHealth = 100;
         
        }

        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }

}
[Serializable]
public struct PlayerInfo
{
    public string Name;
    public int Age;
}


