using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnStart : MonoBehaviour
{
    public List<GameObject> gameObjects;

    void Awake()
    {
        foreach (GameObject obj in gameObjects)
        {
            obj.SetActive(true);
        }
    }
}
