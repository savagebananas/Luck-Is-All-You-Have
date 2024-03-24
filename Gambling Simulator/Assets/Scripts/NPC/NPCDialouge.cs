using System;
using Interactables;
using Player_Scripts;
using Unity.Collections;
using UnityEngine;

namespace NPC
{
    [RequireComponent(typeof(Collider2D))]
    public class NpcDialougeTrigger : MonoBehaviour, IInteractable
    {
        public String Text;
        public bool isInteracting;
        public void OnInteract()
        {
            if (isInteracting) return;
            isInteracting = true;
            Debug.Log(Text);
            isInteracting = false;
            //show display for dialogue
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
            //hig ui display for dialogue
        }
    }
}