using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMoveScript : MonoBehaviour
{
    public float accelerationStrength = 3;
    public float decelerationStrength = 2;
    public Rigidbody2D rb;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space)==true)
        {
            if (rb.velocity.magnitude<50) {
                accelerate();
            }
        }
        else
        {
            if (rb.velocity.magnitude > 0)
            {
                decelerate();
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
}
