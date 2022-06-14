﻿using System;
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
    }
    public float CurrentHealth => _currentHealth;

    public void TakeDamage(float damage)
    {
        if (damage>0)
        {
            Debug.Log("En teoria sale sangre");
            Instantiate(ParticleSystemPrefab, transform.position, transform.rotation);
        }
        if (damage<0)
        {
            Instantiate(HealthParticles, transform.position, transform.rotation);
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