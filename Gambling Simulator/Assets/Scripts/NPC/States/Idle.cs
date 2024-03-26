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
        timeOfNextState = TimeSystem.timePercentage + Random.RandomRange(0.01f, 0.02f);
    }

    public override void OnUpdate()
    {
        if (TimeSystem.timePercentage >= timeOfNextState)
        {
            if (TimeSystem.timePercentage >= nextWalkToPointTime)
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
