using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batleSystem : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private GameObject soldierPrefab;

    private float zombieInterval = 3.5f;
    private float soldierInterval = 7f;
    private void Start()
    {
        StartBattle();
    }
    private void StartBattle()
    {
        Debug.Log("StartBattle");

        enemyTransform.GetComponent<enemySpawn>().Spawn();
    }
}

