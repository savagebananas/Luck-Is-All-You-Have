using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoScript : MonoBehaviour
{
    public Rigidbody2D r1;
    public Rigidbody2D r2;
    public Rigidbody2D r3;
    private bool ballReleased = false;
    public int toggle ;
    // Start is called before the first frame update
    void Start()
    {
        toggle = Random.Range(1, 4) ;
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle == 1 && !ballReleased)
        {
            changeGravity(r1, 1f);
            ballReleased = true;
        }
        if (toggle == 2 && !ballReleased)
        {
            changeGravity(r2, 1f);
            ballReleased = true;
        }
        if (toggle == 3 && !ballReleased)
        {
            changeGravity(r3, 1f);
            ballReleased = true;
        }


    }
    void changeGravity(Rigidbody2D r,float newVal) {
        r.gravityScale = newVal;
    }

}
