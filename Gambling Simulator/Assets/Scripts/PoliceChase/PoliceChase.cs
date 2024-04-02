using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoliceChase : MonoBehaviour
{
    public static GameObject policeCar;
    public static Sprite policeCarLeft;
    public static Sprite policeCarRight;
    public static ObjectFinder finder;
    public static GameObject player;

   
    public static float mapLeftBound = -70;
    public static float mapRightBound = 110;
    public static float minDistance = 10;
    public static float maxDistance = 20;

     public static void StartChase() {
        //ADD ANIMATION OR SIREN HERE
        SpawnPoliceCar(true);
        SpawnPoliceCar(false);
    }
    void Start()
    {
       StartChase();
    }

    void Update()
    {  
    }
    public static GameObject SpawnPoliceCar(bool left) {
        if (finder == null) {
            finder = GameObject.Find("ObjectFinder").GetComponent<ObjectFinder>();
            policeCar = finder.policeCar;
            player = finder.player;
            policeCarLeft = finder.policeCarLeft;
            policeCarRight = finder.policeCarRight;
        }
        GameObject car;
        Vector3 pos = player.transform.position;

         // Instantiate car
        float min;
        float max;         
         if (left) {
            min = pos.x + minDistance;
            if (min >= mapRightBound) return null;
            max = MathF.Min(pos.x+maxDistance, mapRightBound);
            policeCar.GetComponent<SpriteRenderer>().sprite = policeCarLeft;
        } else {
            min = pos.x - minDistance;
            if (min <= mapLeftBound) return null;
            max = MathF.Max(pos.x-maxDistance, mapLeftBound);
            policeCar.GetComponent<SpriteRenderer>().sprite = policeCarRight;
        }
        Vector3 carPos =new Vector3(UnityEngine.Random.Range(min, max), pos.y, pos.z);
        car = Instantiate(policeCar, carPos, Quaternion.identity);
         
        // Set car move script to move left or right
        car.GetComponent<CarMoveScript>().goingLeft = left;
         
        car.GetComponent<CarMoveScript>().leftBound = mapLeftBound;
        car.GetComponent<CarMoveScript>().rightBound = mapRightBound;

        // Setting sorting layer of sprites depending on moving left or right
        if (left) car.GetComponent<SpriteRenderer>().sortingOrder = 1;
        else car.GetComponent<SpriteRenderer>().sortingOrder = 0;
        return car;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(new Vector3(mapLeftBound, transform.position.y, 0), 1);
        Gizmos.DrawSphere(new Vector3(mapRightBound, transform.position.y, 0), 1);
    }
}