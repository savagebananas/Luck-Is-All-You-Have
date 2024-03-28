using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class RandomRoam : State
{
    public float nextWalkToPointTime;
    private float speed;
    private Vector2 nextPos;

    private GameObject npc;

    public State idleState;

    public override void OnStart()
    {
        Debug.Log("Random Roam State");

        npc = transform.parent.parent.gameObject;
        speed = npc.GetComponent<NPCMain>().walkSpeed;

        nextPos = new Vector2(transform.position.x + Random.RandomRange(-15, 15), transform.position.y);
    }

    public override void OnUpdate()
    {
        if ((Vector2) npc.transform.position != nextPos)
        {
            npc.transform.position = Vector2.MoveTowards(npc.transform.position, nextPos, speed * Time.deltaTime);
        }
        else
        {
            ((Idle) idleState).nextWalkToPointTime = nextWalkToPointTime;
            stateMachine.SetNewState(idleState);
        }
    }

    public override void OnLateUpdate() { }
}
