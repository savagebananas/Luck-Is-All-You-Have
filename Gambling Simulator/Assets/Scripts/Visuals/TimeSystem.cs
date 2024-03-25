using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class TimeSystem : MonoBehaviour
{
    public float duration = 5f;

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
        var timeElapsed = Time.time - startTime;
        float percentage = (float) (Mathf.Sin(timeElapsed / duration * Mathf.PI * 2) * 0.5 + 0.5f);

        percentage = Mathf.Clamp(percentage, 0, 1);
        light.color = gradient.Evaluate(percentage);
    }
}
