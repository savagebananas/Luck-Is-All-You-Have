using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState;

    private void Start()
    {
        if (CurrentState != null)
        {
            CurrentState.OnStart();
        }
    }

    private void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.OnUpdate();
        }
    }

    private void LateUpdate()
    {
        if (CurrentState != null)
        {
            CurrentState.OnLateUpdate();
        }
    }

    public void SetNewState(State state)
    {
        if (state != null)
        {
            CurrentState = state;
            CurrentState.OnStart();
        }
    }
}
