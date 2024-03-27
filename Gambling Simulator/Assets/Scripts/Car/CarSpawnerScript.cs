using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{
    public GameObject carPrefab;
    public float spawnRate;
    public int sortingLayerOrder;
    private float timer = 0;

    public bool leftMovingCars;

    private void Start()
    {
        timer = spawnRate;
    }

    void Update()
    {
        if (timer < spawnRate) {
            timer = timer + Time.deltaTime;
        }

        else {
            // Instantiate car
            var car = Instantiate(carPrefab, transform.position, transform.rotation);
            
            // Set car move script to move left or right
            car.GetComponent<CarMoveScript>().goingLeft = leftMovingCars;
            
            // Setting sorting layer of sprites depending on moving left or right
            if (leftMovingCars) car.GetComponent<SpriteRenderer>().sortingOrder = 1;
            else car.GetComponent<SpriteRenderer>().sortingOrder = 0;

            // reset timer
            timer = 0;
        }

        
    }
}
