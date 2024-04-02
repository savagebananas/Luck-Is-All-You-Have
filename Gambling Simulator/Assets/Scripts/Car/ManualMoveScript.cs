using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMoveScript : MonoBehaviour
{
    public float accelerationStrength ;
    public float decelerationStrength;
    public Rigidbody2D rb;
    public int frames;
    private bool start = false;

    bool firstPress = true;
    public Vector2 speedDifference;

    void Start()
    {
        StartCoroutine(resetTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (frames == 0)
            {
                accelerationStrength *= 2;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (firstPress)
                {
                    rb.velocity = Vector2.right * 10;
                    firstPress = false;
                }
                if (rb.velocity.magnitude < 50)
                {
                    accelerate();
                    speedDifference -= Vector2.right * .5f;
                    frames--;
                }
            }
            else
            {
                if (rb.velocity.x > 20)
                {
                    decelerate();
                    frames--;
                }
            }
        }


        Visuals();
    }
    void accelerate()
    {
        rb.velocity += accelerationStrength*Time.deltaTime*Vector2.right*0.5f;
    }
    void decelerate()
    {
        rb.velocity -= decelerationStrength*Time.deltaTime*Vector2.right;
        
    }
    IEnumerator resetTimer()
    {
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
