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
    // Start is called before the first frame update
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
                if (rb.velocity.magnitude < 50)
                {
                    accelerate();
                    frames--;
                }
            }
            else
            {
                if (rb.velocity.magnitude > 0)
                {
                    decelerate();
                    frames--;
                }
            }
        }
    }
    void accelerate()
    {
        rb.velocity += accelerationStrength*Time.deltaTime*Vector2.right;
    }
    void decelerate()
    {
        rb.velocity -= decelerationStrength*Time.deltaTime*Vector2.right;
        
    }
    IEnumerator resetTimer()
    {
        yield return new WaitForSeconds(3);
        start = true;
        rb.velocity += 150 * Time.deltaTime * Vector2.right;
    }
}
