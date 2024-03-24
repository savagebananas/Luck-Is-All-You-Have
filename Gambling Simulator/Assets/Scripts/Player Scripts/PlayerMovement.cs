using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Vector2 inputMovement;
    private Rigidbody2D rb;
    public bool canMove;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        canMove = true;
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (canMove)
        {
            inputMovement.x = Input.GetAxisRaw("Horizontal");
            inputMovement.Normalize();
            rb.velocity = inputMovement * speed * Time.deltaTime;
        }
    }
}
