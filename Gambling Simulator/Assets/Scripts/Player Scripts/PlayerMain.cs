using System;
using UnityEngine;

namespace Player_Scripts
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerInteractionScript))]
    public class PlayerMain : MonoBehaviour
    {
        public static PlayerMain Instance;

        [HideInInspector] public PlayerMovement playerMovement;
        [HideInInspector] public PlayerInteractionScript playerInteractionScript;
        
        /*
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
            DontDestroyOnLoad(this.gameObject);
        }
        */

        private void Start()
        {
            Instance = this;

            playerMovement = GetComponent<PlayerMovement>();
            playerInteractionScript = GetComponent<PlayerInteractionScript>();
        }
    }
}