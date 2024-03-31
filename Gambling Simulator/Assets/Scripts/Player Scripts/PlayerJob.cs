using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJob : MonoBehaviour
{
    public static string jobTitle;
    private static int dailyWage;
    private static float hoursPerDay;
    private static Boolean isActive;
    public static Job currentJob;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void setJob(Job job) {
        currentJob = job;
        isActive = true;
        jobTitle = job.title;
        dailyWage = job.dailyWage;
        hoursPerDay = job.hoursPerDay;
    }
    public static void firePlayer() {
        isActive = false;
        currentJob.isCurrentJob = false;
        dailyWage = 0;
        hoursPerDay = 0;
        currentJob = null;

    }
    public static void work() {
        if (isActive) {
            TimeSystem.AddTime(hoursPerDay*3600);
            PlayerCash.addCash(dailyWage);
        }
    }
}
