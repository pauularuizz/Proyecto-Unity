using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float Damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageTaker = other.GetComponent<ITakeDamage>();

        if (damageTaker != null)
        {
            Destroy(gameObject);
            damageTaker.TakeDamage(Damage);

        }
        if(other.isTrigger==false)
             Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    
}
