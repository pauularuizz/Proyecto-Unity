using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float Speed = 10;
    public Rigidbody2D rb;
    public GameObject bullet;
    public GameObject bulletParent;

    public float speed;
    private Transform player;
    public float shootingRange;
    private float nextFireTime;
    // public float fireRate = 1f; 
    public float lineofSite;
 
 
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        rb = GetComponent<Rigidbody2D>();
        SetVelocity();
    }
    private void Update()
    {
      
    }

    void SetVelocity()
    {
        _rigidbody.velocity = transform.right * Speed;
     
        Instantiate(bullet, bulletParent.transform.position, Quaternion.identity); 
    }



    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
