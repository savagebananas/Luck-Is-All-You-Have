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
    private static bool isActive;
    public static Job currentJob;
    public GameObject blackUIScreen;
    public ObjectFinder finder;
    public AnimationClip fadeOut;
    public AnimationClip fadeIn;
    private static GameObject player;
    private bool canWork = true;
    public TimeSystem timeSys;
    void Start()
    {
        

        if (finder == null) finder = GameObject.Find("ObjectFinder").GetComponent<ObjectFinder>();
        player = finder.player;
        blackUIScreen = finder.blackUIScreen;
        fadeOut = finder.fadeOut;
        fadeIn = finder.fadeIn;
        timeSys = finder.timeSys;
        timeSys.newDay.AddListener(() => StartCoroutine(WorkShift()));
        
        
        
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
    public void work() {
        if (blackUIScreen == null) {

            if (finder==null)finder = GameObject.Find("ObjectFinder").GetComponent<ObjectFinder>();
            blackUIScreen = finder.blackUIScreen;
        }
        if (isActive && canWork) {
            // Visuals
            
            canWork = false;
            StartCoroutine(WorkShift());

            
        }
    }
    private IEnumerator WorkShift() {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.canMove = false;
        blackUIScreen.SetActive(true);
        Animator fadeAnim = blackUIScreen.GetComponent<Animator>();
        fadeAnim.SetTrigger("FadeOut");
        TimeSystem.AddTime(hoursPerDay*3600);
        PlayerCash.addCash(dailyWage);
        yield return new WaitForSeconds(fadeOut.length);
        pm.canMove = true;
        blackUIScreen.SetActive(false);

 
    }

}
