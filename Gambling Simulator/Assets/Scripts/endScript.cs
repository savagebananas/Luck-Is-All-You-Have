using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class endScript : MonoBehaviour
{
    public TextMeshProUGUI over1;
    public TextMeshProUGUI go;
    public Rigidbody2D car1;
    public Rigidbody2D car2;
    public GameObject manual;
    public GameObject AI;
    private bool raceEnded = false;
    public int cash=PlayerCash.getCash()*2;
    // Start is called before the first frame update
    void Start()
    {
        go.text = "Welcome to Drag Race! Start Spamming space when you see go!";
        StartCoroutine(resetTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 3 && !raceEnded)
        {
            over1.text = "Game over - you win";
            go.text = "";
            car1.velocity = Vector2.right * 0;
            car2.velocity = Vector2.right * 0;
            raceEnded = true;
            PlayerCash.addCash(cash);
            Destroy(AI);
            Destroy(manual);
        }
        else if (col.gameObject.layer == 0 && !raceEnded)
        {
            over1.text = "Game over - you lose!";
            go.text = "";
            car1.velocity = Vector2.right * 0;
            car2.velocity = Vector2.right * 0;
            raceEnded = true;
            Destroy(AI);
            Destroy(manual);
            PlayerCash.addCash(-cash);
        }

    }
    IEnumerator resetTimer() {
        yield return new WaitForSeconds(3);
        go.text = "go!";

    }

}
