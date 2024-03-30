using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetDontDestroyOnLoadUIReferences : MonoBehaviour
{
    public GameObject daysLeftUI;
    public GameObject timeUI;
    public GameObject moneyUI;

    private GameObject timeManager;

    void Start()
    {
        timeManager = GameObject.Find("Time Manager");

        timeManager.GetComponent<TimeSystem>().daysLeftText = daysLeftUI.GetComponent<TextMeshProUGUI>();
        timeManager.GetComponent<TimeSystem>().timeText = timeUI.GetComponent<TextMeshProUGUI>();
    }

}
