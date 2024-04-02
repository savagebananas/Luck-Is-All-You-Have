using NPC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{

    public class DragRacerDialogue : NPCDialougeBase
    {
        public bool firstInteraction = true;
        public bool canPlayGame = false;


        public override void OnInteract()
        {
            if (firstInteraction)
            {
                if (PlayerCash.getCash() >= 5000)
                {
                    sentences = new string[2] { "Sup Dude, want to have a race", "its 5k to enter and whoever wins gets 10k" };
                    canPlayGame = true;
                }
                else
                {
                    sentences = new string[3] { "Sup Dude, want to have a race", "its 5k to enter and whoever wins gets 10k", "sorry but you dont have enough money..." };
                    canPlayGame = false;
                }
                firstInteraction = false;
            }
            else
            {
                if (PlayerCash.getCash() < 5000)
                {
                    sentences = new string[1] { "if you want to race me, come back when you are rich"};
                    canPlayGame = false;
                }
                else
                {
                    sentences = new string[1] { "LETS RACE" };
                    canPlayGame = true;
                }
            }

            StartCoroutine(_runInteraction());
        }

        public override void OnFinishNPCInteraction()
        {
            base.OnFinishNPCInteraction();

            if (canPlayGame)
            {
                SetPreviousScenePlayerPosition.lastCityPos = transform.position.x;
                GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlaySFX("CashWin");
                PlayerCash.addCash(-5000);
                GetComponent<MoveToScene>().GoToScene();
            }

            Debug.Log("Finished NPC interaction");
        }
    }
}
