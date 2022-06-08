using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumible : MonoBehaviour
{
    [SerializeField]
    public float Heal;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var healing = other.GetComponent<IHeal>();

        if (healing != null)
        {
            Destroy(gameObject);
            healing.Heal(Heal);

        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
