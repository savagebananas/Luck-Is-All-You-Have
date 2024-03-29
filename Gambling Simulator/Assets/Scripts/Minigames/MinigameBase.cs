using System;
using Player_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Minigames
{
    public class MinigameBase : MonoBehaviour
    {
        [Header("Minigame Base info")]
        public int Cost;
        public int TimeToAdd;
        private void Start()
        {
            OnStart();
        }
        
        public virtual void OnStart()
        {
            PlayerCash.setCash(PlayerCash.getCash() - Cost);
        }
        
        public virtual void OnStopMinigame()
        {
            SceneManager.LoadScene("Scenes/SampleScene");
            TimeSystem.time += TimeToAdd;
        }
    }
}