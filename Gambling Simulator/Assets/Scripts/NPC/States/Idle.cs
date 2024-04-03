using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Idle : State
{
    public float timeOfNextState = 0;
    public float nextWalkToPointTime;

    public State walkToPointState;
    public State randomRoamState;
    public NPCPickPocket pickPocket;

    public override void OnStart()
    {
        timeOfNextState = TimeSystem.time + Random.Range(0.08f, 0.2f); // 1f = 1 hour in-game time
        if (pickPocket!=null) pickPocket.interactable = true;
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
            if (pickPocket != null)
            {
                pickPocket.OnInteractionDeselected();
                pickPocket.interactable = false;
            } 
        }
    }

    public override void OnLateUpdate() { }
}
