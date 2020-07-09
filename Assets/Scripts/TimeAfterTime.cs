using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAfterTime{

    public float time = 0.0f;
    
    /// <summary>
    /// Returns true if the specified time has elapsed.
    /// </summary>
    /// <returns></returns>
    public bool GetTimeElapsed(float timeToCheck)
    {
        if(time >= timeToCheck)
        {
            time = 0.0f;
            return true;
        }
        else
        {
            return false;
        }

    }
}
