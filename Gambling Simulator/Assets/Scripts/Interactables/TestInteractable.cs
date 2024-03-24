using UnityEngine;

namespace Interactables
{
    public class TestInteractable : MonoBehaviour, IInteractable
    {
        public void OnInteract()
        {
            Debug.Log("Interaction called.");
        }

        public void OnInteractSelected()
        {
            Debug.Log("Current interactable set to this.");
        }

        public void InteractSelectedLoop()
        {
            Debug.Log("Current interactable continuously being set to this.");
        }

        public void OnInteractionDeselected()
        {
            Debug.Log("Current interactable deselected.");
        }
    }
}