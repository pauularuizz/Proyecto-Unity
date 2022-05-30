using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerEnterTrigger;
   
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Player")
        {
            Debug.Log("Se activo");
            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
        }

    }

}