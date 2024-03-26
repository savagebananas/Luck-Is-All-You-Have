using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carmovescript2 : MonoBehaviour
{
    public float moveSpeed2 = 5;
    public float end2 = 170;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed2) * Time.deltaTime;
        if (transform.position.x > end2)
        {
            Destroy(gameObject);
        }
    }
}
