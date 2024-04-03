using System;
using System.Collections.Generic;
using Interactables;
using UnityEngine;

namespace Player_Scripts
{
    public class PlayerInteractionScript : MonoBehaviour
    {
        public List<GameObject> nearbyInteractables = new List<GameObject>();
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
                nearbyInteractables.Add(other.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IInteractable interactable))
            {
                if (interactable.Equals(_currentlySelectedInteractable))
                {
                    _currentlySelectedInteractable.OnInteractionDeselected();
                    _currentGameObjectInteratcable = null;
                    _currentlySelectedInteractable = null;
                }

                nearbyInteractables.Remove(other.gameObject);
            }
        }

        private void SetClosestInteractable()
        {
            // If interactables in range
            if (nearbyInteractables.Count > 0)
            {
                GameObject closestInteractable = nearbyInteractables[0];
                float closestDist = DistanceToPlayer(closestInteractable);

                for (int i = 1; i < nearbyInteractables.Count; i++)
                {
                    if (DistanceToPlayer(nearbyInteractables[i]) < closestDist)
                    {
                        closestInteractable = nearbyInteractables[i];
                        closestDist = DistanceToPlayer(closestInteractable);
                    }
                }

                _currentlySelectedInteractable = closestInteractable.GetComponent<IInteractable>();
                _currentGameObjectInteratcable = closestInteractable;
            }
        }

        private float DistanceToPlayer(GameObject interactable)
        {
            return Math.Abs(transform.position.x - interactable.transform.position.x);
        }

        private void Update()
        {
            SetClosestInteractable();
            _currentlySelectedInteractable?.OnInteractSelected();

            if (Input.GetKeyDown(KeyCode.E))
            {
                InteractWithCurrentInteractable();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            if (_currentGameObjectInteratcable != null) Gizmos.DrawRay(transform.position, _currentGameObjectInteratcable.transform.position - transform.position);
        }
    }
}