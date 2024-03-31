using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyOnGround : MonoBehaviour
{
    public int cashValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            PlayerCash.addCash(cashValue);
            Destroy(this.gameObject);
        }
    }

}
