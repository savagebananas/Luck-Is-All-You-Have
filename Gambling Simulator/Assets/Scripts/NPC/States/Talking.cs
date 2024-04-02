using UnityEngine;

namespace NPC.States
{
    public class Talking : State
    {
        public NPCPickPocket pickPocket;

        public override void OnStart()
        {
            if (pickPocket!=null) {
            pickPocket.OnInteractionDeselected();
            pickPocket.interactable = false;
        }
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnLateUpdate()
        {
            
        }
    }
}