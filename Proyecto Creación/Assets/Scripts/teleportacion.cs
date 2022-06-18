using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportacion : MonoBehaviour
{
    [SerializeField]
    GameObject posicionFinal;
    GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisionando tp con player");
        other.transform.position = posicionFinal.transform.position;

        

    }
   
}
