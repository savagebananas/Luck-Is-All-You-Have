using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTimeManager : MonoBehaviour
{

    public TimeSystem timeSystem;

    void Start()
    {

    }

    public void DELETE()
    {
        timeSystem = GameObject.Find("Time Manager").GetComponent<TimeSystem>();
        timeSystem.Reset();
    }

}
