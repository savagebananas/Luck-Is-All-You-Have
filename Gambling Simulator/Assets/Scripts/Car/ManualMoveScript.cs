using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMoveScript : MonoBehaviour
{
    public float accelerationStrength ;
    public float decelerationStrength;
    public GameObject go;
    public Rigidbody2D rb;
    public int frames = 20;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

        if (frames == 0)
        {
            accelerationStrength *= 2;
        }
        if (Input.GetKeyDown(KeyCode.Space) == true && go.activeSelf)
        {
            if (rb.velocity.magnitude<50) {
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
    void accelerate()
    {
        rb.velocity += accelerationStrength*Time.deltaTime*Vector2.right;
    }
    void decelerate()
    {
        rb.velocity -= decelerationStrength*Time.deltaTime*Vector2.right;
        
    }
}
