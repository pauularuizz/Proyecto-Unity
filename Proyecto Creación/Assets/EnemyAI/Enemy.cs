using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
   
    private Rigidbody2D rb;
    [SerializeField]
    public float Damage;
    public float damageStaying;
    
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        var damageTaker = trigger.GetComponent<ITakeDamage>();

        if (damageTaker != null&&trigger.CompareTag("Player"))
        {
           
            damageTaker.TakeDamage(Damage);


        }
      
    }
    private void OnTriggerStay(Collider trigger)
    {
        var damageTaker = trigger.GetComponent<ITakeDamage>();

        if (damageTaker != null && trigger.CompareTag("Player"))
        {

            damageTaker.TakeDamage(damageStaying);
            Debug.Log("daño staying");

        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
    public void TakeDamage(float amount)
    {
        Destroy(gameObject);
    }
}
