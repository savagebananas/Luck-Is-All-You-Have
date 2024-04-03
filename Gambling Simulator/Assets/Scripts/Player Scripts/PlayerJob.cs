using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJob : MonoBehaviour
{
    public static string jobTitle;
    private static int moneyGained;
    private static float hours;
    private bool canWork = true;

    private static bool isActive;
    public static Job currentJob;

    public GameObject blackUIScreen;
    public ObjectFinder finder;
    public AnimationClip fadeOut;
    public AnimationClip fadeIn;
    private static GameObject player;
    public TimeSystem timeSys;

    void Start()
    {
        

        if (finder == null) finder = GameObject.Find("ObjectFinder").GetComponent<ObjectFinder>();
        player = finder.player;
        blackUIScreen = finder.blackUIScreen;
        fadeOut = finder.fadeOut;
        fadeIn = finder.fadeIn;
        timeSys = finder.timeSys;
        //timeSys.newDay.AddListener(() => StartCoroutine(WorkShift()));
        
        
        
    }

    public static void setJob(Job job) {
        jobTitle = job.title;
        moneyGained = job.moneyGained;
        hours = job.amountOfHours;
    }
    /*
    public static void firePlayer() {
        isActive = false;
        currentJob.isCurrentJob = false;
        dailyWage = 0;
        hoursPerDay = 0;
        currentJob = null;

    }
    */
    public void work() {
        if (blackUIScreen == null) {

            if (finder==null)finder = GameObject.Find("ObjectFinder").GetComponent<ObjectFinder>();
            blackUIScreen = finder.blackUIScreen;
        }

        StartCoroutine(WorkShift());   
    }
    private IEnumerator WorkShift() {
        PlayerMovement pm = player.GetComponent<PlayerMovement>();
        pm.canMove = false;

        Animator fadeAnim = blackUIScreen.GetComponent<Animator>();
        fadeAnim.SetTrigger("FadeOut");


        yield return new WaitForSeconds(1);

        TimeSystem.AddTime(hours * (360/24));
        PlayerCash.addCash(moneyGained);

        yield return new WaitForSeconds(1);


        blackUIScreen.SetActive(false);
        blackUIScreen.SetActive(true);

        yield return new WaitForSeconds(fadeOut.length);

        pm.canMove = true;
    }

}
