using System;
using System.Collections;
using System.Collections.Generic;
using Interactables;
using UnityEngine;

/// <summary>
/// This is an interactable that assigns a player a job. The values for the wage and hoursPerDay have to 
/// be assigned in the inspector or through the setter methods. The interactionLight also has to be assigned
/// in the inspector. Add this scrept on to a game object where you want the player to be able to pick
/// up a job.
/// </summary>
public class Job : MonoBehaviour, IInteractable
{
    public String title;
    public GameObject interactionLight;
    public int dailyWage;
    public float hoursPerDay;
    public Boolean isCurrentJob;
    public Boolean random;
    public int minIncome = 100;
    public int maxIncome = 2000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    private void randomizeWage() {
        dailyWage = UnityEngine.Random.Range(minIncome, maxIncome);
    }
    public void setWage(int wage) {
        dailyWage = wage;
    }
    public void setTitle(String title) {
        this.title = title;
    }
    public void setHours(float hours) {
        hoursPerDay = hours;
    }

   

   
}
