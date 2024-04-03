using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfTime : MonoBehaviour
{

    public GameObject outOfTimeScreen;

    public void End()
    {
        StartCoroutine(GameEnd());
    }

    public IEnumerator GameEnd()
    {
        outOfTimeScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        GetComponent<MoveToScene>().GoToScene();
    }
}
