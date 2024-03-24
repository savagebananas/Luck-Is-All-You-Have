using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 5f;
    public float delay = 2f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    
    void Start()
    {
        MoveToRandomPoint();
    }

    
    void Update()
    {
        if (!isMoving) {
            Invoke(nameof(MoveToRandomPoint), delay);
        }
        else {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == targetPosition) {
                isMoving = false;
            }
        }
    }
    void MoveToRandomPoint()
    {
        float randomFactor = Random.Range(0f, 1f);
        targetPosition = Vector3.Lerp(startPoint.position, endPoint.position, randomFactor);
        isMoving = true;
    }
}
