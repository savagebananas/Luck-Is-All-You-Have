using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMoveScript : MonoBehaviour
{
    public float accelerationStrength = 100;
    public Rigidbody2D rb;
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
                rb.AddForce(Vector2.right * accelerationStrength);
            }
        }
         
    }
     
}
