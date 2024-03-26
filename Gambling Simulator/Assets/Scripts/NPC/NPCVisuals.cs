using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVisuals : MonoBehaviour
{
    private Animator animator;

    private float lastX;
    private float timer = 0.01f;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        timer -= Time.time;
        if (timer <= 0)
        {
            lastX = transform.position.x;
            timer = 0.01f;
        }
    }

    private void LateUpdate()
    {
        Visuals();
    }


    void Visuals()
    {
        float diffX = transform.position.x - lastX;
        Debug.Log(diffX);
        // Player is moving
        if (diffX != 0)
        {
            animator.SetBool("isWalking", true);
            if (diffX > 0) // walking right
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
