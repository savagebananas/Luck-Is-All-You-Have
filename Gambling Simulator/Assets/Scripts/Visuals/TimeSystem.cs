using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class TimeSystem : MonoBehaviour
{
    public float secondsPerGameDay;
    private float timeElapsed;
    public float timePercentage;

    [SerializeField] private Gradient gradient;
    private Light2D light;
    private static float startTime;

    void Awake()
    {
        light = GetComponent<Light2D>();
        startTime = Time.time;
    }

    void Update()
    {

        timeElapsed = Time.time - startTime;
        
        // reset time at the end of day
        if (timeElapsed >= secondsPerGameDay)
        {
            startTime = Time.time;
        }
        
        // convert time of day to percentage gradient
        timePercentage = timeElapsed / secondsPerGameDay;
        timePercentage = Mathf.Clamp(timePercentage, 0, 1);
        light.color = gradient.Evaluate(timePercentage);
    }
}
