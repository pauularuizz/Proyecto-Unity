using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class State 
{
    public Action OnEnter, OnStay, OnExit;


}

public class FSM <T> where T: Enum
{
   T _currentState;
    Dictionary<T, State> States;

    public FSM(T initialState)
    {
        States = new Dictionary<T, State>();
        foreach  (T estat in Enum.GetValues(typeof(T)))
        {
            States[_currentState].OnStay?.Invoke();
        }
    }

    void ChangeState(T newState)
    {
        States[_currentState].OnExit?.Invoke();
        States[newState].OnEnter?.Invoke();
        _currentState = newState;
    }


}
