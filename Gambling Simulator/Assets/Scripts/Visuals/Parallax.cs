using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [SerializeField] private float effectMultipler;
    private GameObject cam;
    float camStartPos;
    float objStartPos;
    
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        objStartPos = transform.position.x;
        camStartPos = cam.transform.position.x;
    }
    void Update()
    {
        float dist = (cam.transform.position.x - camStartPos) * effectMultipler;
        transform.position = new Vector3 (objStartPos + dist, transform.position.y, transform.position.z);
    }
}
