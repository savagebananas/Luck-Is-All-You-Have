using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private static float mapLeftBound = -70;
    private static float mapRightBound = 110;
    private float timeLeft;
    private static float minTimeLeft = 7;
    private static float maxTimeLeft = 30;
    private bool idle = true;
    private float nextPos;
    private static float minMoveDist = 10;
    private static float maxMoveDist = 40;
    public float speed;
    public GameObject npc;
    private Vector2 nextLocation;

    void Start()
    {
        npc = gameObject;
        updateValues();


    }
    void updateValues() {
        timeLeft = Random.Range(minTimeLeft, maxTimeLeft);
        bool left = Random.Range(0f, 1f) > 0.5;
        float currentPos = transform.position.x;
        if (currentPos + minMoveDist >= mapRightBound || (left && currentPos - minMoveDist > mapLeftBound)) {
            float max = Mathf.Max(mapLeftBound, currentPos - maxMoveDist);
            float min = currentPos - minMoveDist;
            nextPos = Random.Range(min, max);
        } else {
            float max = Mathf.Min(mapRightBound, currentPos + maxMoveDist);
            float min = currentPos + minMoveDist;
            nextPos = Random.Range(min, max);
        }
        nextLocation = new Vector2(nextPos, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0) {
            timeLeft -=Time.deltaTime;
        }
        if (idle) {
            if (timeLeft <= 0) {
                updateValues();
                idle = false;
            }
        }
        if (!idle) {
            if ((Vector2) transform.position != nextLocation)
            {
                npc.transform.position = Vector2.MoveTowards(npc.transform.position, nextLocation, speed * Time.deltaTime);
            }
            else
            {
                idle = true;
                updateValues();
            }
        }
    }
}
