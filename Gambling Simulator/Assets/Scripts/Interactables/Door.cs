using Interactables;
using Player_Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    public string sceneName;
    public GameObject interactionLight;

    public bool buttonPressRequired;

    // UI Visuals
    public GameObject blackUIScreen;
    public AnimationClip fadeToBlackClip;
    public GameObject player;

    void Start() {
        if (player == null) player = GameObject.FindWithTag("Player");
    }

    public void InteractSelectedLoop()
    {
        
    }

    public void OnInteract()
    {
        if (buttonPressRequired)
        {
                StartCoroutine(SwitchScene(sceneName));
        }

    }

    public void OnInteractSelected()
    {
        if (interactionLight != null) interactionLight.SetActive(true);
        if (!buttonPressRequired) StartCoroutine(SwitchScene(sceneName));
    }

    public void OnInteractionDeselected()
    {
        if (interactionLight != null) interactionLight.SetActive(false);
    }


    IEnumerator SwitchScene(string name)
    {
        if (player !=null)
            player.GetComponent<Collider2D>().enabled = false;
        // Set last position
        if (SceneManager.GetActiveScene().name == "City") SetPreviousScenePlayerPosition.lastCityPos = transform.position.x;
        if (SceneManager.GetActiveScene().name == "Casino Interior")
        {
            if (name == "City") // exiting casino to city
            {
                SetPreviousScenePlayerPosition.lastCasinoPos = -18.25f;
            }
            else // Casino to game
            {
                SetPreviousScenePlayerPosition.lastCasinoPos = transform.position.x;
            }
        }

        // Visuals
        blackUIScreen.SetActive(true);
        blackUIScreen.GetComponent<Animator>().SetTrigger("FadeOut");

        yield return new WaitForSeconds(fadeToBlackClip.length);
        if (player !=null)
            player.GetComponent<Collider2D>().enabled = true;
        SceneManager.LoadScene(name);
    }

}
