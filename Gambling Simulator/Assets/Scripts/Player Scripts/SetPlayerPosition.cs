using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour
{
    public GameObject player;
    public static float lastPos;

    void Start()
    {
        player = GameObject.Find("Player");
        player.transform.position = new Vector3(lastPos, player.transform.position.y, 0f);
    }

}
