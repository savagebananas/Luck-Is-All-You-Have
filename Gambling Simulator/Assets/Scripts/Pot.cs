using System.Collections;
using System.Collections.Generic;
using Minigames;
using UnityEngine;
using UnityEngine.UI;

public class Pot : MinigameBase
{
    public Text ticket;
    public Text pot;
    public int userNum;
    public int potNum;
    public int attempts = 10;
    public bool end = false;
    private bool canPress = true;
    public Animator ani;
  
    // Start is called before the first frame update
    void Start()
    {
        //Generate user number
        userNum = Random.Range(1, 21);
        ticket.text = "Your number is " + userNum.ToString();
        ani = this.GetComponent<Animator>();
  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !end && attempts>0 && canPress)
        {
            potNum = Random.Range(1, 21);
            pot.text = potNum.ToString();
            ani.SetBool("isOpen", true);
            canPress = false;

            StartCoroutine(resetTimer());

            if (potNum == userNum) {
                Debug.Log("You win!");
                ticket.text += " - You win!";
                end = true;
                OnStopMinigame();
            }
            attempts--;

            if(attempts==0 && !end)
            {
                Debug.Log("Game over you bozo");
                ticket.text += "Game over you bozo";
                end = true;
                OnStopMinigame();
            }
        }
    }

    IEnumerator resetTimer()
    {
        yield return new WaitForSeconds(3);
        ani.SetBool("isOpen", false);
        canPress = true;
    }

    public override void OnStopMinigame()
    {
        base.OnStopMinigame();
        //TODO: add logic for if we won or lost
    }
}