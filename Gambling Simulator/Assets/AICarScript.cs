using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class AICarScript : MonoBehaviour
{
    public float accelerationStrength;
    public Rigidbody2D rb;
    private bool acc = true;
    private int frames = 1000;
    private bool start = false;

    public ManualMoveScript playerCar;
    public Vector2 deviation;

    void Start()
    {

        StartCoroutine(resetTimer());
        ChangeDeviation();
    }

    // Update is called once per frame
    void Update()
    {
        Visuals();
        if (start)
        {
            rb.velocity = playerCar.rb.velocity + playerCar.speedDifference;
            
            if (playerCar.rb.velocity.x <= 0)
            {
                rb.velocity = Vector2.zero;
            }

            if (playerCar.transform.position.x < transform.position.x)
            {
                playerCar.speedDifference += Vector2.right * 0.2f * deviation * Time.deltaTime;

            }
            else
            {
                playerCar.speedDifference += Vector2.right * 5f * deviation * Time.deltaTime;
            }

        }
    }

    void ChangeDeviation()
    {
        deviation = new Vector2(Random.Range(1f, 2f), 0);
        Invoke("ChangeDeviation", 5);
    }

    IEnumerator resetTimer() {
        yield return new WaitForSeconds(4);
        start = true;
        rb.velocity += 150 * Time.deltaTime * Vector2.right;
    }

    void Visuals()
    {
        if (rb.velocity.x > 0)
        {
            GetComponent<Animator>().SetTrigger("Drive");
        }
        else
        {
            GetComponent<Animator>().SetTrigger("Stop");
        }
    }

}
