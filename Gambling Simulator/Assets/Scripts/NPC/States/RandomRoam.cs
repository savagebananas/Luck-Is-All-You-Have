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
    public NPCPickPocket pickPocket;

    public override void OnStart()
    {

        npc = transform.parent.parent.gameObject;
        speed = npc.GetComponent<NPCMain>().walkSpeed;

        nextPos = new Vector2(transform.position.x + Random.Range(-15, 15), transform.position.y);

        Debug.Log(nextPos.x + ", " + nextPos.y);

        if (pickPocket != null)
        {
            pickPocket.OnInteractionDeselected();
            pickPocket.interactable = false;
        }
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
