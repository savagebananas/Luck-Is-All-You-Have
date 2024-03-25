using System;
using System.Collections;
using Dialogue;
using Interactables;
using Player_Scripts;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace NPC
{
    [RequireComponent(typeof(Collider2D))]
    public class NpcDialougeTrigger : MonoBehaviour, IInteractable
    {
        public string[] sentences;
        public Text textBox;
        public void OnInteract()
        {
            StartCoroutine(DialogueManager.Instance.AnimateText(sentences));
        }
        

        public void OnInteractSelected()
        {
            //highlight?
        }

        public void InteractSelectedLoop()
        {
            //unhighlight?
        }

        public void OnInteractionDeselected()
        {
            //hide ui display for dialogue
        }
    }
}