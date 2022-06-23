using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BossAI : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    public float Speed;
    [SerializeField]
    private Transform target; 
    //SpriteRenderer renderer;
    public Animator ani;
    public GameObject bullet;
    public GameObject bulletParent;
    public float fireRate = 1f;
    private float nextFireTime;
    public float lineOfSite;
    public float shootingRange; 
  



  

    private SoundManager soundManager;
    public enum EState
    {
        Idle, Wander, Attack
    }

    Dictionary<EState, State> States;

    EState _currentState;

    float _currentTime;

    Vector3 _direction;

    Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        FillDictionary();
        _currentState = EState.Idle;
        _currentTime = 0;
        _player = GameObject.FindGameObjectWithTag("Player").transform; 

     
    }
    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    void FillDictionary()
    {
        States = new Dictionary<EState, State>();
        foreach (EState estat in System.Enum.GetValues(typeof(EState)))
        {
            States.Add(estat, new State());

        }

        States[EState.Idle].OnEnter = () => { _currentTime = 0; /*ani.SetBool("Idle", false);*/ };
        States[EState.Wander].OnEnter = () =>
        {
            _currentState = 0;
            _direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
            //ani.SetBool("Wander", false);
        };
        States[EState.Attack].OnEnter = () => { _currentTime = 0; /*ani.SetBool("Attack", false);*/ };


        States[EState.Idle].OnStay = UpdateIdle;
        States[EState.Wander].OnStay = UpdateWander;
        States[EState.Attack].OnStay = UpdateAttack;

    }


    // Update is called once per frame
    void Update()
    {
        States[_currentState].OnStay?.Invoke();


            
        

    }

    void ChangeState(EState newState)
    {
        States[_currentState].OnExit?.Invoke();
        States[newState].OnEnter?.Invoke();

        _currentState = newState;

    }

    private void UpdateIdle()
    {
        //check if transition
        if (_currentTime > 2)
        {
            //change to wander
            ChangeState(EState.Wander);
        }
        if (IsPlayerNear())
        {
            //change to attack

            ChangeState(EState.Attack);
        }

        _currentTime += Time.deltaTime;
    }

    private void UpdateAttack()
    {
        //do my stuff
        _direction = (_player.position - transform.position).normalized;
        transform.position += _direction * Time.deltaTime * Speed;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        _direction.Normalize();
        movement = _direction;
      
        //if (!(Vector2.Distance(transform.position,_player.transform.position)>1&&_currentState!=EState.Attack))
        //{


        //}
        //check transition


        if (!IsPlayerNear())
        {
            ChangeState(EState.Idle);
        }

    }
    void moveCharacter(Vector2 direction)
    {

        rb.MovePosition((Vector2)transform.position + (direction * Speed * Time.deltaTime));
        rb.SetRotation(0); 
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
        while (IsPlayerNear())
        {
           
            Instantiate(bullet, bulletParent.transform, IsPlayerNear());

        }

    }

    private void UpdateWander()
    {

        //do my stuff

     
        //check transitions
        if (_currentTime > 4)
        {
            //change to Idle
            ChangeState(EState.Idle);
        }
        if (IsPlayerNear())
        {
            //change to attack
        
            
        }
    }
    private bool IsPlayerNear()
    {


        return Vector2.Distance(transform.position, _player.position) < 100;
       
        
    }
    private void OnTriggerEnter2D(Collider2D Player)
    {
        ChangeState(EState.Attack);


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);

    }
    //private  Render()
    //{
    //    if (IsPlayerNear())
    //    {
    //        return renderer = ;
    //    }
    //}
}
