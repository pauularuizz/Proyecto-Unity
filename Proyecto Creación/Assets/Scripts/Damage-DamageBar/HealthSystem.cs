using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthSystem : MonoBehaviour, ITakeDamage
{  
    [SerializeField]
    PlayerInfo PlayerInfo;

    [SerializeField] float _currentHealth;
    [SerializeField]
    float _maxHealth = 100;
    public ParticleSystem ParticleSystemPrefab;
    

    public static Action <PlayerInfo> PlayerDeath;
    public static Action<float > PlayerHealthChange;

   
    private void Start()
    {
        _currentHealth = _maxHealth;
        PlayerHealthChange?.Invoke(_currentHealth / _maxHealth);
    }
    public float CurrentHealth => _currentHealth;

    public void TakeDamage(float damage)
    {
      
        Instantiate(ParticleSystemPrefab, transform.position, transform.rotation);
        
        Debug.Log("En teoria sale sangre");
        _currentHealth -= damage;
        
        PlayerHealthChange?.Invoke(_currentHealth/_maxHealth);
       
    }
    

    private void Die()
    {
        
        PlayerDeath?.Invoke(PlayerInfo);
        if (CompareTag("Player"))
        {
            Debug.Log("playeer muere");

            PauseMenu.LoadMenu();
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
        if (_currentHealth>100)
        {

            _currentHealth = 100;
        }
    }
}
[Serializable]
public struct PlayerInfo
{
   public string Name;
    public int Age;

}