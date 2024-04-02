using System;
using System.Collections;
using System.Collections.Generic;
using Interactables;
using Unity.Mathematics;
using UnityEngine;

public class NPCPickPocket : MonoBehaviour, IInteractable
{
    public enum NPCType {
        Normal,
        Poor,
        Rich
    }
    public GameObject interactionLight;
    private int cash;
    public NPCType type;
    
    [Header("Cash Range Values")]
    public static int poorMin = 50;
    public static int poorMax = 300;
    public static int normalMin = 200;
    public static int normalMax = 700;
    public static int richMin = 500;
    public static int richMax = 1500;
    public static float stealCoolDown = 200f;
    public Boolean interactable = true;
    public float failChance = 25;
    private float timeLeft = 0;

     public void OnInteract()
    {
        if (!interactable) return;
        if (UnityEngine.Random.Range(0, 100) > failChance) {
            pickPocket();
        } else {
            //ADD POLICE STUFF HERE
        }
    }
    private void pickPocket() {
        //ADD UI STUFF HERE
        PlayerCash.addCash(cash);
        cash = 0;
        timeLeft = stealCoolDown;
    }
   

    public void OnInteractionDeselected()
    {
    }

    public void OnInteractSelected()
    {
    }
     public void InteractSelectedLoop()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        randomizeCash();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft>0) {
            timeLeft-=Time.deltaTime;
        }
        if (timeLeft <= 0 && cash <=0) {
            timeLeft = 0;
            randomizeCash();
        }
    }
    public void randomizeCash() {
        switch(type) {
            case NPCType.Normal:
                cash = UnityEngine.Random.Range(normalMin, normalMax);
                break;
            case NPCType.Rich:
                cash = UnityEngine.Random.Range(richMin, richMax);
                break;
            case NPCType.Poor:
                cash = UnityEngine.Random.Range(poorMin, poorMax);
                break;
        }
    }
}
