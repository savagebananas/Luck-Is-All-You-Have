using NPC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;


namespace NPC
{
    public class BeggerDialogue : NPCDialougeBase
    {
        public bool firstInteraction = true;
        public bool canPlayGame = false;


        public override void OnInteract()
        {
            if (firstInteraction)
            {
                if (PlayerCash.getCash() >= 999)
                {
                    sentences = new string[2] { "ARGHH LETS PLAY A GAMEE", "give me 999 dollars and I will triple your money" };
                    canPlayGame = true;
                }
                else
                {
                    sentences = new string[3] { "ARGHH LETS PLAY A GAMEE", "give me 999 dollars and I will triple your money", "ARGGGGGHHHH YOURE BROKE *spits*" };
                    canPlayGame = false;
                }
                firstInteraction = false;
            }
            else
            {
                if (PlayerCash.getCash() < 999)
                {
                    sentences = new string[2] { "ARGGGGGHHHH YOURE BROKE", "GET OUTTTTTTTTTTTTTTTTTT" };
                    canPlayGame = false;
                }
                else
                {
                    sentences = new string[1] { "ARE YOU READY TO PLAAAAAY" };
                    canPlayGame = true;
                }
            }

            StartCoroutine(_runInteraction());
        }

        public override void OnFinishNPCInteraction()
        {
            base.OnFinishNPCInteraction();

            PlayerCash.addCash(-999);
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlaySFX("CashWin");
            if (canPlayGame) GetComponent<MoveToScene>().GoToScene();

            Debug.Log("Finished NPC interaction");
        }
    }
}
