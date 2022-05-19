using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
    public Transform player;
    private Rigidbody2D rb;
    [SerializeField]
    public float Damage;
    private void OnTriggerEnter2D(Collider2D bullet)
    {
        var damageTaker = bullet.GetComponent<ITakeDamage>();

        if (damageTaker != null)
        {
           
            damageTaker.TakeDamage(Damage);
               Destroy(gameObject);
        }
      
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position; 

    }
    public void TakeDamage(float amount)
    {
        Destroy(gameObject);
    }
}
