using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCarScript : MonoBehaviour
{
    public float acc = 11;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(Vector2.right);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector2.right);
    }
}
