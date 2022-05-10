using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum State
    {
        Idle, Wander, Attack
    }

    public float Speed;

    State _currentState;

    float _currentTime;
    Vector3 _direction;
    Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _currentState = State.Idle;
        _currentTime = 0;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_currentState)
        {
            case State.Idle:
                UpdateIdle();
                break;
            case State.Wander:
                UpdateWander();
                break;
            case State.Attack:
                UpdateAttack();
                break;
        }
    }


    void ChangeState(State newState) //esto es la segunda forma de hacerlo
    {

    }

    private void UpdateIdle()
    {
        //Check if transition
        if(_currentTime >2)
        {
            //change to wander
            _currentTime = 0;
            _currentState = State.Wander;

            _direction = new Vector3(Random.Range(-1F, -1F), Random.Range(-1f, -1f), 0).normalized;
        }

        if(IsPlayerNear()) 
        {
            //change to Attack
            _currentState = State.Attack;
        }

        //do my stuff

        _currentTime += Time.deltaTime;
    }

    private void UpdateWander()
    {
        //do my stuff
        transform.position += _direction * Time.deltaTime * Speed;
        _currentTime += Time.deltaTime;

        //Check Transition

        if (_currentTime >4)
        {
            _currentState = State.Idle;
            _currentTime = 0;
        }
        if (IsPlayerNear()) 
        {
            //change to Attack
            _currentState = State.Attack;
        }
    }

    private void UpdateAttack()
    {
        //do my stuff
        _direction = (_player.position - transform.position).normalized;
        transform.position += _direction * Time.deltaTime * Speed;

        //Check Transition
        if(!IsPlayerNear())
        {
            //change to Idle
            _currentState = State.Idle;
            _currentTime = 0;
        }
    }

    private bool IsPlayerNear()
    {
        return Vector2.Distance(transform.position, _player.position) < 4;
    }



}
