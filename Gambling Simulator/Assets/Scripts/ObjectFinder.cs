using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/// <summary>
/// Script to store object and prefab references
/// </summary>
public class ObjectFinder : MonoBehaviour
{
    // Start is called before the first frame update

    public Image[] slotReels; // Assign via Inspector
    public Sprite[] slotSymbols; // Assign via Inspector
    public GameObject player;
    public GameObject cashDisplay;
    public GameObject policeCar;
    public Sprite policeCarLeft;
    public Sprite policeCarRight;
    public TextMeshProUGUI cashText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
