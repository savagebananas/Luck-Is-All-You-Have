using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableImageAfterSeconds : MonoBehaviour
{
    public Image image;
    public Animator animator;
    public float seconds;


    private void Start()
    {
        if (TimeSystem.time >= timeElapsed)
        {
            gameObject.SetActive(false);
        }
    }

    public void Disable()
    {
        Debug.Log("delete");
        animator.enabled = false;
        image.enabled = false;
    }
}
