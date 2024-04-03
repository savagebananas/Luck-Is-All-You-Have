using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busted : MonoBehaviour
{
    public GameObject bustedScreen;

    public void End()
    {
        bustedScreen = GameObject.Find("OutofTimeImage");
        StartCoroutine(GameEnd());
    }

    public IEnumerator GameEnd()
    {
        bustedScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        GetComponent<MoveToScene>().GoToScene();
    }
}
