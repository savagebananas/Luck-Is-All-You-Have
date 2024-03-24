﻿using System;
using Interactables;
using UnityEngine;

namespace Player_Scripts
{
    public class PlayerInteractionScript : MonoBehaviour
    {
        private IInteractable _currentlySelectedInteractable;

        private void InteractWithCurrentInteractable()
        {
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
                if (_currentlySelectedInteractable != null && _currentlySelectedInteractable != interactable)
                {
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