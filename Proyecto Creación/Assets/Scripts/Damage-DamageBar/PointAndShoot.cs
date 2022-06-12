using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;
    [SerializeField] private FieldOfView fieldOfView;
    
    //recarga
    [SerializeField]private const float cargador = 10f;
    [SerializeField] private float bulletsLeft=10f;
    [SerializeField] public float recargaDelay = 2f;
    [SerializeField] public float bulletSpeed = 60.0f;
    [SerializeField] private bool canShoot=true;
    public Text bulletsLftUI;

    private Vector3 target;

    //sonido
    private SoundManager soundManager;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        
    }
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);


        if (canShoot)
        {
            bulletsLftUI.text = ("Bullets:" + bulletsLeft.ToString());
        }
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
            
            soundManager.AudioSelector(0, 2f);
            GameObject b = Instantiate(bulletPrefab) as GameObject;
            b.transform.position = bulletStart.transform.position;
            b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            bulletsLeft--;
            
           bulletsLftUI.text=("Bullets:"+bulletsLeft.ToString());
        }
      
       
    }

    IEnumerator Recagar()
    {
       
        Debug.Log("recargando");
        bulletsLftUI.text = ("Reloading...");
        canShoot = false;
        soundManager.AudioSelector(1, 0.25f);
        yield return new WaitForSeconds(recargaDelay);
        soundManager.AudioSelector(3, 0.25f);
        bulletsLftUI.text = ("Reload completed");
        yield return new WaitForSeconds(0.3f);
        canShoot = true;
        bulletsLftUI.text = ("Reload completed :D");
        

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
