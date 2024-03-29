using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarScript : MonoBehaviour
{
    public float accelerationStrength;
    public Rigidbody2D rb;
    private bool acc = true;
    private int frames = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity += 150 * Time.deltaTime * Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (frames == 0)
        {
            accelerationStrength /= 2;
        }
            accelerate();
        frames--;
       
    }

    void accelerate()
    {
        rb.velocity += accelerationStrength * Time.deltaTime * Vector2.right;
    }
}
