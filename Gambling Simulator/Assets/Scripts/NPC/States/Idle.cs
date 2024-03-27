using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Idle : State
{
    public float timeOfNextState;
    public float nextWalkToPointTime;

    public State walkToPointState;
    public State randomRoamState;

    public override void OnStart()
    {
        Debug.Log("Idle State");
        timeOfNextState = TimeSystem.time + Random.Range(0.08f, 0.2f); // 1f = 1 hour in-game time
    }

    public override void OnUpdate()
    {
        if (TimeSystem.time >= timeOfNextState)
        {
            if (TimeSystem.time >= nextWalkToPointTime)
            {
                
                stateMachine.SetNewState(walkToPointState);
            }
            else
            {
                ((RandomRoam)randomRoamState).nextWalkToPointTime = nextWalkToPointTime;
                stateMachine.SetNewState(randomRoamState);
            }
        }
    }

    public override void OnLateUpdate() { }
}
