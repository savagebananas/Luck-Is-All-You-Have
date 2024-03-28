using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pot : MonoBehaviour
{
    public Text ticket;
    public Text pot;
    public int userNum;
    public int potNum;
    public int attempts = 10;
    public bool end = false;
  
    // Start is called before the first frame update
    void Start()
    {
        //Generate user number
        userNum = Random.Range(1, 21);
        ticket.text = "Your number is " + userNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !end && attempts>0)
        {
            potNum = Random.Range(1, 21);
            pot.text = "Pot number is " + potNum.ToString();

            if (potNum == userNum) {
                Debug.Log("You win!");
                pot.text += " - You win!";
                end = true;
            }
            attempts--;

            if(attempts==0 && !end)
            {
                Debug.Log("Game over you bozo");
                pot.text += "Game over you bozo";
                end = true;
            }




        }

    }
}
