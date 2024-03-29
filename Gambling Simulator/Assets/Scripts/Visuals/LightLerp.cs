using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightLerp : MonoBehaviour
{
    Light2D light;
    public float speed;

    public float minimum;
    public float maximum;

    static float startingValue = 0.0f;

    void Start()
    {
        light = GetComponent<Light2D>();
    }

    void Update()
    {
        light.falloffIntensity = Mathf.Lerp(minimum, maximum, startingValue);

        startingValue += speed * Time.deltaTime;

        if (startingValue > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            startingValue = 0.0f;
        }
    }
}
