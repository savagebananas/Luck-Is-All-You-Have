using Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : MonoBehaviour, IInteractable
{
    public GameObject winScreen;

    public void InteractSelectedLoop()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract()
    {
       if (PlayerCash.getCash() >= 100000)
        {
            StartCoroutine(WinGame());
        }
    }

    public IEnumerator WinGame()
    {
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlaySFX("CashWinBig");
        winScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        GetComponent<MoveToScene>().GoToScene();
    }

    public void OnInteractionDeselected()
    {
        //throw new System.NotImplementedException();
    }

    public void OnInteractSelected()
    {
        //throw new System.NotImplementedException();
    }

    

}
