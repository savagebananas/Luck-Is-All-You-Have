using NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    [RequireComponent(typeof(Job))]
    public class EmployeeDialogue : NPCDialougeBase
    {
        public bool firstInteraction = true;

        public JobUI jobUI;

        public override void OnInteract()
        {
            if (firstInteraction)
            {
                sentences = new string[3] { "Hey I am looking for employees for the cafe", "It is a 12-hour shift and you get 3000 dollars", "You In?" };
                firstInteraction = false;
            }
            else
            {
                sentences = new string[1] { "Welcome back, are you here to work?" };
            }

            StartCoroutine(_runInteraction());
        }

        public override void OnFinishNPCInteraction()
        {
            base.OnFinishNPCInteraction();

            jobUI.gameObject.SetActive(true);
            jobUI.job = GetComponent<Job>(); 
        }
    }
}

