using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlashingLightColor : MonoBehaviour
{
    Light2D light;
    public float seconds;
    float timer = 0f;

    bool isRed = true;


    void Start()
    {
        light = GetComponent<Light2D>();
        light.color = Color.red;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (isRed)
            {
                light.color = Color.blue;
                isRed = false;
            }
            else
            {
                light.color = Color.red;
                isRed = true;
            }
            timer = seconds;
        }
    }
}
