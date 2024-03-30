using Interactables;
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

    public void InteractSelectedLoop()
    {
        
    }

    public void OnInteract()
    {
        if (buttonPressRequired) StartCoroutine(SwitchScene(sceneName));
    }

    public void OnInteractSelected()
    {
        if (interactionLight != null) interactionLight.SetActive(true);
        if (!buttonPressRequired) StartCoroutine(SwitchScene(sceneName));
    }

    public void OnInteractionDeselected()
    {
        interactionLight.SetActive(false);
    }


    IEnumerator SwitchScene(string name)
    {
        blackUIScreen.SetActive(true);
        blackUIScreen.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(fadeToBlackClip.length);
        SceneManager.LoadScene(name);
    }

}
