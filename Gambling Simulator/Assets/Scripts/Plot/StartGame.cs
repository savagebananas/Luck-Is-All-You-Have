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
    private TextMeshProUGUI stealText;
    private String stealTxt; 
    private String letterTxt = "[Press E to Exit]";
    void Start()
    {
        if (startOfGame) {
            finder = GameObject.Find("ObjectFinder").GetComponent<ObjectFinder>();
            stealText = finder.stealText;
            stealTxt = stealText.text;
            letterAnimator = finder.letterAnimator;
            player = finder.player;
            enterLetter();
            startOfGame = false;

        }
    }
    private void enterLetter() {
        player.GetComponent<PlayerMovement>().canMove = false;
        letterAnimator.SetTrigger("LetterEnter");
        display = true;
        stealText.text = letterTxt;
        stealText.gameObject.SetActive(true);
    }
    private void exitLetter() {
        letterAnimator.SetTrigger("LetterExit");
        Time.timeScale = 1;
        player.GetComponent<PlayerMovement>().canMove = true;
        stealText.text = stealTxt;
        stealText.gameObject.SetActive(false);


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
