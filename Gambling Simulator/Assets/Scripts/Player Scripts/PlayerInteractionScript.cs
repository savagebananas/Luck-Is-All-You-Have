using System;
using Interactables;
using UnityEngine;

namespace Player_Scripts
{
    public class PlayerInteractionScript : MonoBehaviour
    {
        private IInteractable _currentlySelectedInteractable;
        public GameObject _currentGameObjectInteratcable;
        public bool canInteract;

        private void Start()
        {
            canInteract = true;
        }

        private void InteractWithCurrentInteractable()
        {
            if (!canInteract)
            {
                Debug.Log("Cant interact!");
                return;
            }
            if (_currentlySelectedInteractable == null)
            {
                Debug.Log("Trying to interactable despite not being in range!");
                return;
            }
            _currentlySelectedInteractable.OnInteract();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IInteractable interactable))
            {
                Debug.Log($"Found current interactable: {interactable}");
                if (_currentlySelectedInteractable == null || _currentlySelectedInteractable != interactable)
                {
                    Debug.Log("Setting interactable!");
                    _currentGameObjectInteratcable = other.gameObject;
                    _currentlySelectedInteractable = interactable;
                    _currentlySelectedInteractable.OnInteractSelected();
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IInteractable interactable))
            {
                if (_currentlySelectedInteractable == interactable)
                {
                    _currentlySelectedInteractable.OnInteractionDeselected();
                    _currentlySelectedInteractable = null;
                    _currentGameObjectInteratcable = null;
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithCurrentInteractable();
            }
        }
    }
}