using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPreviousScenePlayerPosition : MonoBehaviour
{
    public GameObject player;
    public static float lastCityPos;
    public static float lastCasinoPos = -18.25f;

    void Start()
    {
        player = GameObject.Find("Player");
        if (SceneManager.GetActiveScene().name == "City") player.transform.position = new Vector3(lastCityPos, player.transform.position.y, 0f);
        if (SceneManager.GetActiveScene().name == "Casino Interior") player.transform.position = new Vector3(lastCasinoPos, player.transform.position.y, 0f);
    }

}
