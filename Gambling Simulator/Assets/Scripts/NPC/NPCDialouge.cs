using System;
using System.Collections;
using Dialogue;
using Interactables;
using NPC.States;
using Player_Scripts;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace NPC
{
    [RequireComponent(typeof(Collider2D))]
    public class NPCDialouge : NPCDialougeBase
    {
        public override void OnFinishNPCInteraction()
        {
            base.OnFinishNPCInteraction();
            Debug.Log("Finished NPC interaction");
        }
    }
}