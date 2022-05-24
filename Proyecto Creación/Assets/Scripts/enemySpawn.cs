using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemyToSpawn; 
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyToSpawn, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Instantiate(enemyToSpawn, transform.position, transform.rotation);
    }

}
