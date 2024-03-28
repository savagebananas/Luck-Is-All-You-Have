using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMain : MonoBehaviour
{

    public float walkSpeed;

    [Header("Destinations at specific times (0 - 24)")]
    public List<Transform> locations = new List<Transform>();
    public List<float> times = new List<float>();
}
