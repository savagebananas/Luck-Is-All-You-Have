using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeManager : MonoBehaviour
{
    public ParticleSystem stars;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if ((0 <= TimeSystem.time && TimeSystem.time < 6) || (18 <= TimeSystem.time && TimeSystem.time < 23.5))
        {
            stars.emissionRate = 125;
        }
        else if (6 <= TimeSystem.time && TimeSystem.time < 6.5f)
        {
            stars.emissionRate = 75;
        }
        else if (6.5f <= TimeSystem.time && TimeSystem.time < 7)
        {
            stars.emissionRate = 50;
        }
        else if (7 <= TimeSystem.time && TimeSystem.time < 7.5f)
        {
            stars.emissionRate = 25;
        }
        else if (7.5f <= TimeSystem.time && TimeSystem.time < 17)
        {
            stars.emissionRate = 0;
        }
        else if (17f <= TimeSystem.time && TimeSystem.time < 18)
        {
            stars.emissionRate = 50;
        }
    }
}
