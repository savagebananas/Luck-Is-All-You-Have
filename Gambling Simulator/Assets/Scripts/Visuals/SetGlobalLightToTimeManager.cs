using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SetGlobalLightToTimeManager : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Time Manager").GetComponent<TimeSystem>().globalLight = GetComponent<Light2D>();
    }

}
