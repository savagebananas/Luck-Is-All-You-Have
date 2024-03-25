using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private Vector2 inputMovement;
    private Rigidbody2D rb;
    public bool canMove;

    // Visuals
    private Animator animator;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
        canMove = true;
    }

    void Update()
    {
        Movement();
        Visuals();
    }

    void Movement()
    {
        if (canMove)
        {
            inputMovement.x = Input.GetAxisRaw("Horizontal");
            inputMovement.Normalize();
            rb.velocity = inputMovement * speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    void Visuals()
    {
        // Player is moving
        if (rb.velocity.x != 0)
        {
            animator.SetBool("isWalking", true);
            if (rb.velocity.x > 0) // walking right
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else // walking left
            {
                GetComponent<SpriteRenderer>().flipX = true;

            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
