using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage = 42;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageTaker = other.GetComponent<ITakeDamage>();

        if (damageTaker!=null)
        {
            Destroy(gameObject);
            damageTaker.TakeDamage(Damage);
            
        } 
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
