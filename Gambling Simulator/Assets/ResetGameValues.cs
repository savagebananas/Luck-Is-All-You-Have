using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetGameValues : MonoBehaviour
{

    public TimeSystem timeSystem;

    void Start()
    {

    }

    public void ResetValues()
    {
        timeSystem = GameObject.Find("Time Manager").GetComponent<TimeSystem>();
        timeSystem.Reset();
        timeSystem.gameEnded = false;

        PlayerCash.setCash(10000);

        SetPreviousScenePlayerPosition.lastCityPos = 97.5227f;
    }

}
