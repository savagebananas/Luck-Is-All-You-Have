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

    bool lightOn = true;

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
        lightOn = !lightOn;
        if (lightOn)
        {
            interval = UnityEngine.Random.Range(0, maxWait);
            light.color = new Color(1, 1, 1, 1); 
        }
        else
        {
            interval = UnityEngine.Random.Range(0, maxFlicker);
            light.color = new Color(1, 1, 1, 0.5f);
        }

        timer = 0;
    }

}

