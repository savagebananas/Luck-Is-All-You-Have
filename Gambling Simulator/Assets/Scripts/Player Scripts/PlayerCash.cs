using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCash : MonoBehaviour
{
    public int startingCash = 100;
    private int cash;
    // Start is called before the first frame update
    public GameObject cashDisplay;
    public TextMeshProUGUI cashText;
    void Start()
    {
        if (cashDisplay == null) {
            cashDisplay = GameObject.Find("CashValueText");
        }
        cashText = cashDisplay.GetComponent<TextMeshProUGUI>();
        setCash(startingCash);
    }

    public int getCash() {
        return cash;
    }
    public void setCash(int newCash) {
        cash = newCash;
        cashText.text = cash.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
