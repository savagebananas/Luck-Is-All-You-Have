using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMain : MonoBehaviour
{

    public float walkSpeed;

    [Header("locations to move towards at specific time (0 - 1)")]
    public List<Transform> locations = new List<Transform>();
    public List<float> times = new List<float>();
}
