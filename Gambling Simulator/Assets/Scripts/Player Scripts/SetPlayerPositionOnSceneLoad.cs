using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPositionOnSceneLoad : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("Player").transform.position = transform.position;
    }

}
