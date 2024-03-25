using System;
using System.Collections;
using System.Collections.Generic;
using Player_Scripts;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance;
        
        [SerializeField]
        private TMP_Text textBox;
        [SerializeField]
        private GameObject dialogueGameObject;
        private bool progressToNextSentence;
        private void Awake() 
        { 
            // If there is an instance, and it's not me, delete myself.
    
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this; 
            } 
        }

        public void ProgressDialogue() => progressToNextSentence = true;

        public IEnumerator AnimateText(string[] sentences)
        {
            PlayerMain.Instance.playerMovement.canMove = false;
            PlayerMain.Instance.playerInteractionScript.canInteract = false;
            textBox.text = "";
            dialogueGameObject.gameObject.SetActive(true);
            foreach (var sentence in sentences)
            {
                string currentText = "";
                textBox.text = "";
                progressToNextSentence = false;
                for (int i = 0; i < sentence.Length; i++)
                {
                    currentText = sentence.Substring(0, i + 1);
                    textBox.text = currentText;
                    yield return new WaitForSeconds(0.1f);
                }

                yield return new WaitUntil(() => progressToNextSentence);
            }
            
            PlayerMain.Instance.playerMovement.canMove = true;
            PlayerMain.Instance.playerInteractionScript.canInteract = true;
            dialogueGameObject.gameObject.SetActive(false);
            textBox.text = "";
        }
    }
}