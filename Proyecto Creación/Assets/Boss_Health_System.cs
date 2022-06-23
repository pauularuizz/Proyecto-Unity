using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Boss_Heatlh_System : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    PlayerInfo PlayerInfo;

    [SerializeField] float _currentHealth;
    [SerializeField]
    float _maxHealth = 2000;
    public ParticleSystem ParticleSystemPrefab;
    public ParticleSystem HealthParticles;



    public static Action<PlayerInfo> PlayerDeath;
    public static Action<float> PlayerHealthChange;


    private void Start()
    {
        Cursor.visible = false;
        _currentHealth = _maxHealth;
        PlayerHealthChange?.Invoke(_currentHealth / _maxHealth);
    }
    public float CurrentHealth => _currentHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Bullet"))
        {
            //CurrentHealth -= _bossdmg;
            Debug.Log("boss dmg");

        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            Debug.Log("En teoria sale sangre");
            //Debug.Log("Boss dmg");
            Instantiate(ParticleSystemPrefab, transform.position, transform.rotation);
        }
        if (damage < 0)
        {
            Instantiate(HealthParticles, transform.position, transform.rotation);
        }




        _currentHealth -= damage;


        PlayerHealthChange?.Invoke(_currentHealth / _maxHealth);

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
        if (_currentHealth > 100)
        {

            _currentHealth = 100;
        }

    }

}


