using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobUI : MonoBehaviour
{
    public Job job;

    public void YesJob()
    {
        job.StartJob();
        gameObject.SetActive(false);
    }

    public void NoJob()
    {
        gameObject.SetActive(false);
    }
}
