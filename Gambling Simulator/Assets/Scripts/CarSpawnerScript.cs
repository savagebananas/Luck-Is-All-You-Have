using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{
    public GameObject car;
    public float spawnRate=3;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) {
            timer = timer + Time.deltaTime;
        }

        else {
            Instantiate(car, transform.position, transform.rotation);
            timer = 0;
        }

        
    }
}
