using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlinkoScript : MonoBehaviour
{
    /*
    public Rigidbody2D r1;
    public Rigidbody2D r2;
    public Rigidbody2D r3;
    public Rigidbody2D r4;
    public Rigidbody2D r5;
    public Rigidbody2D r6;
    public GameObject over;
    public GameObject start;
    public int toggle;
    */
    public int tries;

    public int costPerBall;
    public GameObject ballPrefab;
    public float spawnDeviation;

    public GameObject welcomeTextUI;

    void Start()
    {
        //toggle = Random.RandomRange(1, 7);
        welcomeTextUI = GameObject.Find("Welcome Text");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            welcomeTextUI.GetComponent<Animator>().SetTrigger("fadeOut");

            if (PlayerCash.getCash() - costPerBall >= 0)
            {
                PlayerCash.addCash(-costPerBall);
                var ball = Instantiate(ballPrefab);
                ball.transform.position = new Vector2(transform.position.x + Random.RandomRange(-spawnDeviation, spawnDeviation), transform.position.y);
                ball.GetComponent<Rigidbody2D>().gravityScale = Random.RandomRange(1, 2);
                ball.GetComponent<Ball>().cost = costPerBall;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(new Vector2(transform.position.x, transform.position.y), spawnDeviation/2);

    }
}
