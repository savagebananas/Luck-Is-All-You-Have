using System.Collections;
using System.Collections.Generic;
using Minigames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pot : MinigameBase
{
    public TextMeshProUGUI pot;
    public TextMeshProUGUI ticket;
    public TextMeshProUGUI attemptsLeft;
    public int userNum;
    public int potNum;
    public int attempts = 10;
    public bool end = false;
    private bool canPress = true;
    private int cash = PlayerCash.getCash()*2;
    public Animator ani;
    public TextMeshProUGUI over;
    public TextMeshProUGUI start;
    public AnimationClip anim;
    // Start is called before the first frame update
    void Start()
    {
        //Generate user number
        userNum = Random.Range(1, 21);
        ticket.text = "Your number is " + userNum.ToString();   
        ani = this.GetComponent<Animator>();
        attemptsLeft.text = "Allowed attempts:" + attempts.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !end && attempts>0 && canPress)
        {
            PlayerCash.addCash(-10);
            start.text = "";
            potNum = Random.Range(1, 21);
            ani.SetBool("isOpen", true);
            canPress = false;
            if (attempts != 0)
            {
                StartCoroutine(resetTimer());
            }
            if (potNum == userNum) {
                StartCoroutine(resetTimer3());    
            }
            attempts--;
            if(attempts==0 && !end)
            {
                StartCoroutine(resetTimer2());            
            }
        }
    }

    IEnumerator resetTimer()
    {
        yield return new WaitForSeconds(1f);
        pot.text = potNum.ToString();
        yield return new WaitForSeconds(2);
        ani.SetBool("isOpen", false);
        attemptsLeft.text = "Allowed attempts:" + attempts.ToString();
        pot.text = "";
        canPress = true;
    }
    IEnumerator resetTimer2() {
        yield return new WaitForSeconds(6);
        ticket.text = "";
        attemptsLeft.text = "";
        over.text = "Game Over- you lose";
        Debug.Log("Game over you bozo");
        end = true;

    }
    IEnumerator resetTimer3()
    {
        yield return new WaitForSeconds(6);
        PlayerCash.addCash(2 * cash);
        Debug.Log("You win!");
        ticket.text = "";
        attemptsLeft.text = "";
        over.text = "Game Over- you win";
        end = true;
    }

}
