﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour, ITakeDamage
{   [SerializeField]
    PlayerInfo PlayerInfo;

    [SerializeField]float _currentHealth;
    [SerializeField]
    float _maxHealth = 100;

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
        _currentHealth -= damage;
        PlayerHealthChange?.Invoke(_currentHealth/_maxHealth);
        if (_currentHealth<=0)
        {
            _currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        PlayerDeath?.Invoke(PlayerInfo);
        Destroy(gameObject);
    }
}
[Serializable]
public struct PlayerInfo
{
   public string Name;
    public int Age;

}