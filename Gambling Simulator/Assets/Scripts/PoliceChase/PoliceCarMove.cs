using System.Collections;
using System.Collections.Generic;
using Player_Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class PoliceCarMove : MonoBehaviour
{
    public float moveSpeed = 5;
    public float leftBound = -70;
    public float rightBound = 110;
    public bool goingLeft;

    private bool canMove = true;

    private void Start()
    {
       
    }

    void OnTriggerEnter2D(Collider2D otherCollider) {
        GameObject g = otherCollider.gameObject;
        if (g.tag.Equals("Player")) {
            g.GetComponent<PlayerMovement>().canMove = false;
            canMove = false;
            StartCoroutine(GameEnd());
        }
    }

    IEnumerator GameEnd()
    {
        var bustedScreen = GameObject.Find("GameEndCanvas").transform.GetChild(1).gameObject;
        bustedScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        GameObject.Find("Canvas").GetComponent<MoveToScene>().GoToScene();
    }

    void Update()
    {
        if (!goingLeft && canMove) // going right
        {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;
            if (transform.position.x > rightBound)
            {
                Destroy(gameObject);
            }
        }
        else if (goingLeft && canMove) // going left
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
            if (transform.position.x < leftBound)
            {
                Destroy(gameObject);
            }
        }

    }
}
