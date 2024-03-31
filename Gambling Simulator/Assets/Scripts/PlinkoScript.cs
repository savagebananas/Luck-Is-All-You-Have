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
    public Rigidbody2D r6;
    public GameObject over;
    public GameObject start;
    public int toggle;
    public int tries;
    // Start is called before the first frame update
    void Start()
    {
        toggle = Random.Range(1, 7);
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && tries!=0)
        {
            if (toggle==1)
            {
                Rigidbody2D newr1 = Instantiate(r1, r1.position, Quaternion.identity);
                changeGravity(r1, 1f);
                r1 = newr1;
            }
            if (toggle==2)
            {
                Rigidbody2D newr2 = Instantiate(r2, r2.position, Quaternion.identity);
                changeGravity(r2, 1f);
                r2 = newr2;
            }
            if (toggle==3)
            {
                Rigidbody2D newr3 = Instantiate(r3, r3.position, Quaternion.identity);
                changeGravity(r3, 1f);
                r3 = newr3;
            }
            if (toggle==4)
            {
                Rigidbody2D newr4 = Instantiate(r4, r4.position, Quaternion.identity);
                changeGravity(r4, 1f);
                r4 = newr4;
            }
            if (toggle==5)
            {

                Rigidbody2D newr5 = Instantiate(r5, r5.position, Quaternion.identity);
                changeGravity(r5, 1f);
                r5 = newr5;
            }
            if (toggle==6)
            {
                Rigidbody2D newr6 = Instantiate(r6, r6.position, Quaternion.identity);
                changeGravity(r6, 1f);
                r6 = newr6;
            }
            tries--;
            Start();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            changeGravity(r1, 1);
            changeGravity(r3, 1);
           // changeGravity(r2, 1);
            changeGravity(r4, 1);
            changeGravity(r5, 1);
            changeGravity(r6, 1);
            tries = 0;
        }
        if (tries == 0)
        {
            StartCoroutine(resetTimer());
            start.SetActive(false);
            over.SetActive(true);
        }


    }
    IEnumerator resetTimer()
    {
        yield return new WaitForSecondsRealtime(5);
    }
    void changeGravity(Rigidbody2D r,float newVal) {
        r.gravityScale = newVal;
    }

}
