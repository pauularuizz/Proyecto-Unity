using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    [SerializeField] private FieldOfView fieldOfView;
    
    //recarga
    [SerializeField]private const float cargador = 10;
    [SerializeField] private float bulletsLeft=10;
    [SerializeField] public float recargaDelay = 3f;
    [SerializeField] public float bulletSpeed = 60.0f;
    [SerializeField] private bool canShoot=true;

    private Vector3 target;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        
        

        if (Input.GetMouseButtonDown(0))
        {
            if (canShoot)
            {
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
            
                fireBullet(direction, rotationZ);
            }

           
            

        }
       
        fieldOfView.SetOrigin(player.transform.position);
        fieldOfView.SetAimDirection(difference);
        if (bulletsLeft<=0||Input.GetKeyDown(KeyCode.R))
        {
            
            canShoot = false;
            StartCoroutine (Recagar());
            bulletsLeft = cargador;
        }
    }
    void fireBullet(Vector2 direction, float rotationZ)
    {
        if (canShoot)
        {
            GameObject b = Instantiate(bulletPrefab) as GameObject;
            b.transform.position = bulletStart.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bulletsLeft--;
        }
      
       
    }

    IEnumerator Recagar()
    {
        Debug.Log("recaargando");
        canShoot = false;

        yield return new WaitForSeconds(recargaDelay);
        canShoot = true;    
    }
    //private IEnumerator Dash()
    //{
    //    canDash = false;
    //    isDashing = true;
    //    playerRb.velocity = moveInput * dashingPower;
    //    tr.emitting = true;
    //    healthSystem.enabled = false;
    //    yield return new WaitForSeconds(dashingTime);
    //    tr.emitting = false;
    //    isDashing = false;
    //    healthSystem.enabled = true;
    //    yield return new WaitForSeconds(dashingCooldown);
    //    canDash = true;
    //}
}
