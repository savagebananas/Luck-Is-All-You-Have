using System.Collections;
using Dialogue;
using Interactables;
using NPC.States;
using Player_Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace NPC
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class NPCDialougeBase : MonoBehaviour, IInteractable
    {
        public string[] sentences;
        public Text textBox;
        public Talking TalkingState;
        public void OnInteract()
        {
            StartCoroutine(_runInteraction());
        }

        private IEnumerator _runInteraction()
        {
            PlayerMain.Instance.playerMovement.canMove = false;
            PlayerMain.Instance.playerInteractionScript.canInteract = false;
            StateMachine stateMachine = transform.parent.GetComponentInChildren<StateMachine>();
            State oldState = stateMachine.CurrentState;
            stateMachine.SetNewState(TalkingState);
            yield return StartCoroutine(DialogueManager.Instance.AnimateText(sentences));
            PlayerMain.Instance.playerMovement.canMove = true;
            PlayerMain.Instance.playerInteractionScript.canInteract = true;
            stateMachine.SetNewState(oldState);
            OnFinishNPCInteraction();
        }

        /// <summary>
        /// Called after an NPC interaction has finished. Use for adding cash or modifying stats.
        /// </summary>
        public virtual void OnFinishNPCInteraction()
        {
            
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