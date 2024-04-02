using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMoveScript : MonoBehaviour
{
    private bool movingRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 18)
        {
            movingRight = false;
        }
        else if (transform.position.x < -18)
        {
            movingRight = true;
        }
        if (movingRight)
        {
            transform.position += (25 * Time.deltaTime * Vector3.right);
        }
        else
        {
            transform.position -= (25 * Time.deltaTime * Vector3.right);
        }
    }
}
