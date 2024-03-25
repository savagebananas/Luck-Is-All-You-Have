using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float end = 70;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * moveSpeed)*Time.deltaTime;
        if (transform.position.x > end)
        {
            Destroy(gameObject);
        }
    }
}
