using System.Collections;
using Interactables;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Minigames
{
    public class MinigameInteractable : MonoBehaviour, IInteractable
    {
        public string SceneToLoad;
        public bool running;
        public GameObject interactLight;
        public void OnInteract()
        {
            if (running) return;
            running = true;
            StartCoroutine(TestReload());
        }

        public IEnumerator TestReload()
        {
            SceneManager.LoadScene(SceneToLoad);
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("SampleScene");
        }
        
        public void OnInteractSelected()
        {
            interactLight.SetActive(true);
        }

        public void InteractSelectedLoop()
        {
            
        }

        public void OnInteractionDeselected()
        {
            interactLight.SetActive(false);
        }
    }
}