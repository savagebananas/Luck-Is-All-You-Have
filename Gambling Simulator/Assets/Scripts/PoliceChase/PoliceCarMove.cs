using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PoliceCarMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float leftBound = -70;
    public float rightBound = 110;
    public bool goingLeft;

    private void Start()
    {
       
    }

    void Update()
    {
        if (!goingLeft) // going right
        {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
            if (transform.position.x > rightBound)
            {
                Destroy(gameObject);
            }
        }
        else // going left
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
            if (transform.position.x < leftBound)
            {
                Destroy(gameObject);
            }
        }

    }
}
