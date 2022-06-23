using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    
    public float speed;
    private Transform player;
    public float shootingRange;
    private float nextFireTime;
    // public float fireRate = 1f; 
    public float lineofSite;
    public GameObject bullet;
    public GameObject bulletParent;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < lineofSite && distanceFromPlayer > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        if (distanceFromPlayer <= shootingRange)
        {
            Debug.Log("jamaiu");
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);

        }



    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineofSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
