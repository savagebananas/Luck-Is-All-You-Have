using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnerScript : MonoBehaviour
{
    public List<GameObject> carPrefabs;
    public float spawnRate;
    public int sortingLayerOrder;
    private float timer = 0;

    public bool leftMovingCars;
    public float leftBound;
    public float rightBound;

    private void Start()
    {
        timer = spawnRate;
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }

        else {
            // Instantiate car
            var car = Instantiate(carPrefabs[(int) Random.RandomRange(0, carPrefabs.Count)], transform.position, transform.rotation);
            
            // Set car move script to move left or right
            car.GetComponent<CarMoveScript>().goingLeft = leftMovingCars;
            car.GetComponent<CarMoveScript>().leftBound = leftBound;
            car.GetComponent<CarMoveScript>().rightBound = rightBound;

            // Setting sorting layer of sprites depending on moving left or right
            if (leftMovingCars) car.GetComponent<SpriteRenderer>().sortingOrder = 1;
            else car.GetComponent<SpriteRenderer>().sortingOrder = 0;

            // reset timer
            timer = 0 + Random.RandomRange(-5, 2);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector3(leftBound, transform.position.y, 0), 1);
        Gizmos.DrawSphere(new Vector3(rightBound, transform.position.y, 0), 1);
    }
}
