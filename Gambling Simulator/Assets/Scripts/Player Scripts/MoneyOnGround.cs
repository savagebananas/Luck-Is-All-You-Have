using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoneyOnGround : MonoBehaviour
{
    public int cashValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerCash.addCash(cashValue);
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlaySFX("CashWin");
            Destroy(this.gameObject);
        }
    }

}
