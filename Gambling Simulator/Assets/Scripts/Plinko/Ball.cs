using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int cost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlinkoBasket>() != null)
        {
            float multipler = collision.GetComponent<PlinkoBasket>().multiplier;
            PlayerCash.addCash((int)(cost * multipler));
            if (multipler >= 10)
            {
                GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlaySFX("CashWinBig");
            }
            else if (multipler > 1)
            {
                GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlaySFX("CashWin");
            }        
        }
    }
}
