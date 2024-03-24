using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAround : State
{

    public Dictionary<float, Transform> locations = new Dictionary<float, Transform>(); // float corresponds with time (0 - 1)
    public bool randomRoam;

    public override void OnStart()
    {
        throw new System.NotImplementedException();
    }

    public override void OnUpdate()
    {
        // transform.position = Vector2.MoveTowards(locations);
    }

    public override void OnLateUpdate()
    {
        throw new System.NotImplementedException();
    }
}
