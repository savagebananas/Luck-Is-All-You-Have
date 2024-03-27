using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToPoint : State
{
    private GameObject npc;
    public float speed;

    // index n location corresponds to index n time
    public List<Transform> locations = new List<Transform>(); 
    public List<float> times = new List<float>(); // ranges from 0 to 1 (12 am to 11:59 pm)

    private Vector2 nextLocation;

    public State idleState;
    private float nextWalkToPointTime; // time till npc goes to new destination

    public override void OnStart()
    {
        Debug.Log("Walk To Point State");

        npc = transform.parent.parent.gameObject;
        locations = GetComponentInParent<NPCMain>().locations;
        times = GetComponentInParent<NPCMain>().times;
        speed = GetComponentInParent<NPCMain>().walkSpeed;
        SetNextPosition();
    }

    public override void OnUpdate()
    {
        if ((Vector2) transform.position != nextLocation)
        {
            npc.transform.position = Vector2.MoveTowards(npc.transform.position, nextLocation, speed * Time.deltaTime);
        }
        else
        {
            ((Idle)idleState).nextWalkToPointTime = this.nextWalkToPointTime;
            stateMachine.SetNewState(idleState);
        }
    }

    public override void OnLateUpdate() { }

    /// <summary>
    /// Sets next postion for object to go to based on the time of day
    /// </summary>
    void SetNextPosition()
    {
        float time = TimeSystem.time;
        for (int i = 0; i < times.Count; i++)
        {
            if (time >= times[i] && time < times[i + 1] || i == times.Count - 1 && time >= times[i])
            {
                nextLocation = new Vector2(locations[i].position.x, transform.position.y);
                Debug.Log("Setting new location: " + locations[i].name + " Time: " + time);

                if (i + 1 < times.Count) nextWalkToPointTime = times[i + 1];
                else nextWalkToPointTime = times[0];

                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(nextLocation, 0.1f);
    }
}
