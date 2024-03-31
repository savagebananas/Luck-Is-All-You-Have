using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public GameObject cashPrefab;
    public float seconds;
    private float timer;

    public float leftBound;
    public float rightBound;

    void Update()
    {
        if (timer <= 0)
        {
            var cash = Instantiate(cashPrefab);
            cash.transform.position = new Vector3(Random.RandomRange(leftBound, rightBound), transform.position.x, 0);
            timer = seconds;
        }
        timer -= Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(new Vector3(leftBound, transform.position.x, 0), 1f);
        Gizmos.DrawSphere(new Vector3(rightBound, transform.position.x, 0), 1f);

    }
}
