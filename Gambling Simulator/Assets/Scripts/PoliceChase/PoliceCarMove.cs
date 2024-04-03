using System.Collections;
using System.Collections.Generic;
using Player_Scripts;
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

    void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject g = otherCollider.gameObject;
        if (g.tag.Equals("Player")) {
          g.GetComponent<PlayerMovement>().canMove = false;
            GetComponent<Busted>().End();
          Time.timeScale = 0.2f;
        }
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
