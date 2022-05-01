using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float _horizontal;
    float _vertical;
    public float speed = 0.5f;

    private Rigidbody2D _rigidbody;



    [Range(0, 1)]
    public float Smoothing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        _rigidbody = GetComponent<Rigidbody2D>();
        //MoveWithForce();  
        MoveWithVelocity();

    }

    private void OnMove(InputValue inputValue)
    {
        _horizontal = inputValue.Get<Vector2>().x;
        _vertical = inputValue.Get<Vector2>().y;



        MoveWithVelocity();

        Debug.Log(_horizontal + " / " + _vertical); //si lo pongo en el OnMove no sale constantemente actualizandose en la consola. 

    }
    private void MoveWithVelocity()
    {

        Vector2 dir = new Vector2(_horizontal, _vertical) * speed;
        Vector2 targetVelocity = dir;

        _rigidbody.velocity = Vector2.Lerp(_rigidbody.velocity, targetVelocity, Smoothing);


    }



}
