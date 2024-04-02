using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public TextMeshProUGUI welcomeText;
    public TextMeshProUGUI gameEndText;
    public TextMeshProUGUI countdownText;

    public GameObject manual;
    public GameObject AI;
    public bool raceEnded = false;
    public int cash = PlayerCash.getCash() * 2;

    public AudioManager audioManager;

    void Start()
    {
        StartCoroutine(WelcomeText());
        StartCoroutine(Countdown());
    }

    private void Update()
    {
        if (raceEnded)
        {
            if (manual.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                // Slow down
                manual.GetComponent<Rigidbody2D>().velocity -= Vector2.right * 100 * Time.deltaTime;
            }
            else
            {
                manual.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            if (AI.GetComponent<Rigidbody2D>().velocity.x > 0)
            {
                // Slow down
                AI.GetComponent<Rigidbody2D>().velocity -= Vector2.right * 100 * Time.deltaTime;
            }
            else
            {
                AI.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                AI.GetComponent<Animator>().SetTrigger("Stop");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 3 && !raceEnded)
        {
            gameEndText.text = "WIN";
            countdownText.text = "";
            raceEnded = true;
            StartCoroutine(GameWin());

            
        }
        else if (col.gameObject.layer == 0 && !raceEnded)
        {
            gameEndText.text = "LOSE";
            countdownText.text = "";
            raceEnded = true;
            StartCoroutine(GameLose());
        }

    }

    IEnumerator WelcomeText()
    {
        welcomeText.text = "Welcome to Drag Race! Spam Space to Go Faster!";
        yield return new WaitForSeconds(1.5f);
        welcomeText.GetComponent<Animator>().SetTrigger("FadeOut");

    }

    IEnumerator Countdown()
    {

        audioManager.PlaySFX("Cars Revving");
        yield return new WaitForSeconds(1);
        audioManager.PlaySFX("Race Countdown");
        countdownText.text = "3";
        yield return new WaitForSeconds(1);
        countdownText.text = "2";
        yield return new WaitForSeconds(1);
        countdownText.text = "1";
        yield return new WaitForSeconds(1);
        countdownText.text = "GO";
        yield return new WaitForSeconds(.5f);
        audioManager.PlayMusic("Cars Driving");
        countdownText.text = "";
    }

    public IEnumerator GameWin()
    {
        audioManager.StopMusic();
        yield return new WaitForSeconds(3);
        audioManager.PlaySFX("CashWin");
        PlayerCash.addCash(cash);
        yield return new WaitForSeconds(1);
        GetComponent<MoveToScene>().GoToScene();
    }

    public IEnumerator GameLose()
    {
        audioManager.StopMusic();
        yield return new WaitForSeconds(3);
        yield return new WaitForSeconds(1);
        GetComponent<MoveToScene>().GoToScene();
    }


}
