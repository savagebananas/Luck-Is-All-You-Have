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
        }
        

        public void OnInteractSelected()
        {
            
        }

        public void InteractSelectedLoop()
        {
            
        }

        public void OnInteractionDeselected()
        {
            
        }
    }
}