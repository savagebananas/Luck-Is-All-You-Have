using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCash : MonoBehaviour
{
    private static int cash = 100;
    // Start is called before the first frame update
    public GameObject cashDisplay;
    public static TextMeshProUGUI cashText;
    void Start()
    {
        if (cashDisplay == null) {
            cashDisplay = GameObject.Find("CashValueText");
        }
        cashText = cashDisplay.GetComponent<TextMeshProUGUI>();
        updateCashUI();
    }

    void Awake() {
        updateCashUI();
    }
    public static void updateCashUI() {
        if (cashText != null)
            cashText.text = cash.ToString();
    }

    public static int getCash() {
        return cash;
    }
    public static void setCash(int newCash) {
        cash = newCash;
        updateCashUI();
    }

    public static void addCash(int addCash) {
        setCash(cash+addCash);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
