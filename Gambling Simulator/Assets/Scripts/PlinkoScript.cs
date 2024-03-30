using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoScript : MonoBehaviour
{
    public Rigidbody2D r1;
    public Rigidbody2D r2;
    public Rigidbody2D r3;
    public Rigidbody2D r4;
    public Rigidbody2D r5;
    private bool ballReleased = false;
    public int toggle ;
    public int specialnum;
    public int tries;
    // Start is called before the first frame update
    void Start()
    {
        toggle = Random.Range(1, 5) ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && tries!=0)
        {
            if (specialnum == 0 && !ballReleased)
            {
                specialnum = 100;
                changeGravity(r4, 1);
                ballReleased = true;
            }

            if (toggle == 1 && !ballReleased)
            {
                changeGravity(r1, 1f);
                ballReleased = true;
                specialnum--;
            }
            if (toggle == 2 && !ballReleased)
            {
                changeGravity(r2, 1f);
                ballReleased = true;
                specialnum--;
            }
            if (toggle == 3 && !ballReleased)
            {
                changeGravity(r3, 1f);
                ballReleased = true;
                specialnum--;
            }
            if (toggle == 4 && !ballReleased)
            {
                changeGravity(r5, 1f);
                ballReleased = true;
                specialnum--;
            }
            tries--;
        }

    }
    void changeGravity(Rigidbody2D r,float newVal) {
        r.gravityScale = newVal;
    }

}
