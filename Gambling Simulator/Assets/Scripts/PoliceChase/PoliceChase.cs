using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PoliceChase : MonoBehaviour
{
    public static GameObject  policeCarLeft;
    public static GameObject policeCarRight;
    public ObjectFinder finder;
    public GameObject player;
    public Button button;

   
    public float mapLeftBound = -70;
    public float mapRightBound = 110;
    public float minDistance = 10;
    public float maxDistance = 20;
    private float leftY = -1.27f;
    private float rightY = -0.29f;

     public void StartChase() {
        //ADD ANIMATION OR SIREN HERE
        SpawnPoliceCar(true);
        SpawnPoliceCar(false);
    }
    void Start()
    {
        button.onClick.AddListener(() => StartChase());
    }

    void Update()
    {  
    }
    public GameObject SpawnPoliceCar(bool left) {
        if (finder == null) {
            finder = GameObject.Find("ObjectFinder").GetComponent<ObjectFinder>();
            player = finder.player;
            policeCarLeft = finder.policeCarLeft;
            policeCarRight = finder.policeCarRight;
        }
         // Instantiate car
        GameObject car;
        Vector3 pos = player.transform.position;
        Vector3 carPos;
        float min;
        float max;         
         if (left) {
            min = pos.x + minDistance;
            if (min >= mapRightBound) return null;
            max = MathF.Min(pos.x+maxDistance, mapRightBound);
            carPos =new Vector3(UnityEngine.Random.Range(min, max), leftY, pos.z);
            car = Instantiate(policeCarLeft, carPos, Quaternion.identity);



        } else {
            min = pos.x - minDistance;
            if (min <= mapLeftBound) return null;
            max = MathF.Max(pos.x-maxDistance, mapLeftBound);
            carPos =new Vector3(UnityEngine.Random.Range(min, max), rightY, pos.z);
            car = Instantiate(policeCarRight, carPos, Quaternion.identity);            
        }
         
        // Set car move script to move left or right
        car.GetComponent<PoliceCarMove>().goingLeft = left;
         
        car.GetComponent<PoliceCarMove>().leftBound = mapLeftBound;
        car.GetComponent<PoliceCarMove>().rightBound = mapRightBound;

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