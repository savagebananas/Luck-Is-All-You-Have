using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class TimeSystem : MonoBehaviour
{
    [Header("Game Over")]
    public float daysLeft;

    [Header("Time values")]
    public float secondsPerGameDay;
    private float timeElapsed;
    public static float time;
    private float timePercentage;
    private static float startTime;

    // Color and Light
    [SerializeField] private Gradient gradient;
    private Light2D light;
    
    // UI
    private TextMeshProUGUI daysLeftText;
    private TextMeshProUGUI timeText;

    void Awake()
    {
        DontDestroyOnLoad(this);
        light = GetComponent<Light2D>();
        startTime = Time.time;

        daysLeftText = GameObject.Find("DaysLeftText").GetComponent<TextMeshProUGUI>();
        timeText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();
        daysLeftText.text = "Days Left: " + daysLeft;
    }

    void Update()
    {

        timeElapsed = Time.time - startTime;
        
        // End of day
        if (timeElapsed >= secondsPerGameDay)
        {
            // Reset Time
            startTime = Time.time;

            // Subtract days left
            daysLeft--;

            // Update UI for Days Left
            daysLeftText.text = "Days Left: " + daysLeft;
        }
        
        
        timePercentage = timeElapsed / secondsPerGameDay;

        // convert time of day to color gradient
        light.color = gradient.Evaluate(Mathf.Clamp(timePercentage, 0, 1));

        // display time to text UI
        time = Mathf.Lerp(0, 24, Mathf.Clamp(timePercentage, 0, 1));
        int minutes = (int) Mathf.Lerp(0, 60, time % 1);
        timeToText((int) time, minutes);

    }

    void timeToText(int time, int d)
    {
        if (time < 10)
        {
            if (d < 10)
            {
                timeText.text = "0" + time + ":" + "0" + d;
            }
            else
            {
                timeText.text = "0" + time + ":" + d;
            }
        }
        else
        {
            if (d < 10)
            {
                timeText.text = time + ":" + "0" + d;
            }
            else
            {
                timeText.text = time + ":" + d;
            }
        }
    }
}
