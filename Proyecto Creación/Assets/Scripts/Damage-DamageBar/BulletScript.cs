using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour
{
    public float Speed = 7f;
    public Rigidbody2D rb;
    Vector2 movedir;
    GameObject target;
    public GameObject bullet; 

    private Transform player;
    //public float shootingRange;
    //private float nextFireTime;
    // public float fireRate = 1f; 
    //public float lineofSite;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        movedir = (player.transform.position - transform.position).normalized * Speed;
        rb.velocity = new Vector2(movedir.x, movedir.y);
        Destroy(gameObject, 2f);
        

    }
    private void Update()
    {
        if (Collider2D.Equals(player, bullet))
        {
            Debug.Log("hithihtit"); 
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Player"))
        {
            Debug.Log("hit");
        }
    }
}