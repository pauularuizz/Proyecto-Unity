using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer2 : MonoBehaviour
{
    [SerializeField]private float speed=3;

    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Animator playerAnimator;
    private HealthSystem healthSystem;

    //Dash
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 20f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] private TrailRenderer tr;
    private SoundManager soundManager;


    private ParticleSystem _Ps;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        healthSystem = GetComponent<HealthSystem>();
    }
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Ps = GetComponent<ParticleSystem>();
        if (Input.GetMouseButtonDown(0))
        {
           
            _Ps.Play();
        }
        if (isDashing)
        {
            return;
        }
        //inputs
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;

        playerAnimator.SetFloat("Horizontal", moveX);
        playerAnimator.SetFloat("Vertical", moveY);
        playerAnimator.SetFloat("Speed", moveInput.sqrMagnitude);
        if ((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.LeftShift)) &&canDash)
        {
           StartCoroutine( Dash());
        }
      
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        //fisicas
        playerRb.MovePosition(playerRb.position + moveInput * speed * Time.fixedDeltaTime);

    }

  
    
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        playerRb.velocity = moveInput * dashingPower;
        tr.emitting = true;
        healthSystem.enabled = false;
        soundManager.AudioSelector(4, 0.7f);
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        healthSystem.enabled = true;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

   
}
