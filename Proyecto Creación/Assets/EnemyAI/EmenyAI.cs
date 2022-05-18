using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EmenyAI : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D rb;
    public float Speed;

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

    void FillDictionary()
    {
        States = new Dictionary<EState, State>();
        foreach (EState estat in System.Enum.GetValues(typeof(EState)))
        {
            States.Add(estat, new State());

        }

        States[EState.Idle].OnEnter = () => _currentTime = 0;
        States[EState.Wander].OnEnter = () => 
        {
            _currentState = 0;
            _direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
        };
        States[EState.Attack].OnEnter = () => _currentTime = 0;


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
        if (_currentTime>2)
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
        //check transition

        if (!IsPlayerNear())
        {
            ChangeState(EState.Idle);
        }

    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * Speed * Time.deltaTime));
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    private void UpdateWander()
    {

        //do my stuff
       
        _currentTime += Time.deltaTime;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        _direction.Normalize();
        movement = _direction;
        //check transitions
        if (_currentTime > 4)
        {
            //change to Idle
            ChangeState(EState.Idle);
        }
        if (IsPlayerNear())
        {
            //change to attack
            ChangeState(EState.Attack);
        }
    }
    private bool IsPlayerNear()
    {
        return Vector2.Distance(transform.position, _player.position) < 4;
    }
}
