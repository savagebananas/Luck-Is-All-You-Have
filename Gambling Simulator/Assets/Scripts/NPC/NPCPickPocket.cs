using System;
using System.Collections;
using System.Collections.Generic;
using Interactables;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class NPCPickPocket : MonoBehaviour, IInteractable
{
    public enum NPCType {
        Normal,
        Poor,
        Rich
    }
    
    [Header("Cash Range Values")]
    public static int poorMin = 50;
    public static int poorMax = 300;
    public static int normalMin = 200;
    public static int normalMax = 700;
    public static int richMin = 500;
    public static int richMax = 1500;

    public NPCType type;
    private int cash;
    public float failChance = 25;
    public static float stealCoolDown = 200f;
    private float timeLeft = 0;

    public bool interactable = true;

    [Header("References")]
    public static GameObject player;
    public ObjectFinder finder;
    private AudioManager audioManager;
    public TextMeshProUGUI stealText;
    public GameObject interactionLight;
   


    public void OnInteract()
    {
        if (!interactable) return;
        if (UnityEngine.Random.Range(0, 100) > failChance) {
            pickPocket();
            interactable = false;
            OnInteractionDeselected();
        } else {
            CallPolice();
            OnInteractionDeselected();
        }
    }
    private void pickPocket() {
        //ADD UI STUFF HERE

        // Add Cash to player
        audioManager.PlaySFX("CashWin");
        PlayerCash.addCash(cash);
        
        // Reset cooldown and randomize cash for next pickpocket
        timeLeft = stealCoolDown;
        randomizeCash();
    }

    private void CallPolice()
    {
        // Reset cooldown, player cant steal
        timeLeft = stealCoolDown;
        interactable = false;

        player.GetComponent<PoliceChase>().StartChase();
    }


    public void OnInteractionDeselected()
    {
        Debug.Log("Deselected");
        stealText.gameObject.SetActive(false);

    }

    public void OnInteractSelected()
    {
        if (!interactable) return;
        
        // Cooldown over, indicate choice for pickpocket
        if (timeLeft <= 0)
        {
            if (interactionLight != null) interactionLight.SetActive(true);
            stealText.gameObject.SetActive(true);
        }
    }
     public void InteractSelectedLoop()
    {
    }

    void Start()
    {
        randomizeCash();

        if (finder == null) {
            finder = GameObject.Find("ObjectFinder").GetComponent<ObjectFinder>();
        }
        player = finder.player;
        audioManager = finder.audioManager;
        stealText = finder.stealText;
        stealText.gameObject.SetActive(false);
        
        
    }

    void Update()
    {
        if (timeLeft>0) {
            timeLeft-=Time.deltaTime;
        }
        if (timeLeft <= 0 && cash <=0) {
            timeLeft = 0;
            randomizeCash();
            interactable = true;
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
