using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batleSystem : MonoBehaviour
{
    private enum State { Idle, Active,}
    [SerializeField] private ColliderTrigger colliderTrigger;
    [SerializeField] private enemySpawn[] enemySpawnArray;
    public enemySpawn spawner, spawner2;
    private State state;

    private void Awake()
    {
        state = State.Idle;
    }
    private void Start()
    {

        colliderTrigger.OnPlayerEnterTrigger += ColliderTrigger_OnPlayerEnterTrigger;
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        if (state==State.Idle)
        {
            StartBattle();
            colliderTrigger.OnPlayerEnterTrigger -= ColliderTrigger_OnPlayerEnterTrigger;
        }
        
    }

    private void StartBattle()
    {
        Debug.Log("StartBattle");
        state = State.Active;

        
        spawner.Spawn();


    }
}