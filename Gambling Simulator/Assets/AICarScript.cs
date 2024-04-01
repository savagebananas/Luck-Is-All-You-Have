using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarScript : MonoBehaviour
{
    public float accelerationStrength;
    public Rigidbody2D rb;
    private bool acc = true;
    private int frames = 1000;
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
                accelerationStrength /= 2;
                rb.velocity -= 150 * Time.deltaTime * Vector2.right;
            }
            accelerate();
            frames--;
        }
    }

    void accelerate()
    {
        rb.velocity += accelerationStrength * Time.deltaTime * Vector2.right;
    }
    IEnumerator resetTimer() {
        yield return new WaitForSeconds(3);
        start = true;
        rb.velocity += 150 * Time.deltaTime * Vector2.right;
    }

}
