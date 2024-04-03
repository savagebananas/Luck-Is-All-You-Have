using System;
using System.Collections;
using System.Collections.Generic;
using Interactables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is an interactable that assigns a player a job. The values for the wage and hoursPerDay have to 
/// be assigned in the inspector or through the setter methods. The interactionLight also has to be assigned
/// in the inspector. Add this scrept on to a game object where you want the player to be able to pick
/// up a job.
/// </summary>
public class Job : MonoBehaviour//, IInteractable
{
    public String title;
    public int moneyGained;
    public float amountOfHours;

    private static GameObject player;
    public GameObject interactionLight;
    public ObjectFinder finder;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null) {
            if (finder == null) finder = GameObject.Find("ObjectFinder").GetComponent<ObjectFinder>();
            player = finder.player;
        }
    }

    public void StartJob()
    {
        PlayerJob.setJob(this);
        player.GetComponent<PlayerJob>().work();
    }

    /*
     void IInteractable.OnInteractSelected()
    {
        if (interactionLight != null) interactionLight.SetActive(true);
    }

     void IInteractable.OnInteract()
    {
        if (!isCurrentJob) {
            //if (isActive) {}
            if (random) {
                randomizeWage();
            }
            PlayerJob.setJob(this);
        } else {
            player.GetComponent<PlayerJob>().work();
        }
    }
   
   


    void IInteractable.OnInteractionDeselected()
    {
        if (interactionLight != null) interactionLight.SetActive(false);
    }
      // Update is called once per frame
    void Update()
    {
        
    }
     void IInteractable.InteractSelectedLoop()
    {

    }
    */

    public void setWage(int wage) {
        moneyGained = wage;
    }
    public void setTitle(String title) {
        this.title = title;
    }
    public void setHours(float hours) {
        amountOfHours = hours;
    }

   

   
}
