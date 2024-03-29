using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endScript : MonoBehaviour
{
    public GameObject over1;
    public GameObject over2;
    public GameObject go;
    public Rigidbody2D car1;
    public Rigidbody2D car2;
    private bool raceEnded = false;
    // Start is called before the first frame update
    void Start()
    {
        go.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 3 && !raceEnded) {
            over1.SetActive(true);
            go.SetActive(false);
            car1.velocity = Vector2.right * 0;
            car2.velocity = Vector2.right * 0;
            raceEnded = true;
        }
        else if(col.gameObject.layer == 0 && !raceEnded) {
            over2.SetActive(true);
            go.SetActive(false);
            car1.velocity = Vector2.right * 0;
            car2.velocity = Vector2.right * 0;
            raceEnded = true;
        }


    }
}
