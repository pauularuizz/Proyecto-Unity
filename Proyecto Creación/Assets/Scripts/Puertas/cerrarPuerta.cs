using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerrarPuerta : MonoBehaviour
{
    public GameObject puertaPrefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("se crea la puerta detras");
        Instantiate(puertaPrefab);
        gameObject.SetActive(false);
    }
}
