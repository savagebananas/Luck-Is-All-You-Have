using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    float timer = 0;
    public Light2D light;
    public float maxWait;
    public float maxFlicker;
    float interval;

    void Start()
    {
        light = GetComponent<Light2D>(); // get light 2D
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        light.enabled = !light.enabled;
        if (light.enabled)
        {
            interval = UnityEngine.Random.Range(0, maxWait);
        }
        else
        {
            interval = UnityEngine.Random.Range(0, maxFlicker);
        }

        timer = 0;
    }

}

