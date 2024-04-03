using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool startOfGame = true;
    public Animator letterAnimator;
    public GameObject player;
    public ObjectFinder finder;
    private bool display = false;
    
    void Start()
    {
        if (startOfGame) {
            finder = GameObject.Find("ObjectFinder").GetComponent<ObjectFinder>();
            letterAnimator = finder.letterAnimator;
            player = finder.player;
            enterLetter();
            startOfGame = false;

        }
    }
    private void enterLetter() {
        letterAnimator.SetTrigger("LetterEnter");
        display = true;
    }
    private void exitLetter() {
        letterAnimator.SetTrigger("LetterExit");
        Time.timeScale = 1;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (display) {
            if (Input.GetKeyDown(KeyCode.E)) {
                exitLetter();
            }
        }
        if (!display && !startOfGame) {
            Destroy(this);
        }
        
    }
}
