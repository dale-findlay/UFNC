using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HydrationLevel : MonoBehaviour
{

    //time in seconds for when the stomachLevel decreases.
    public float hydrationDropoffTime = 1.0f;

    //the amount deduceted after stomachDropoffTime 
    public int hydrationDropoff = 10;

    public float hydrationLevel = 100;
    public Image waterDrop;

    public bool start = false;
    public bool gameOver = false;

    public void Reset()
    {
        gameOver = false;
        hydrationLevel = 100;
        waterDrop.fillAmount = hydrationLevel / 100;
    }

    TimeAfterTime timeAfterTime = new TimeAfterTime();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timeAfterTime.time += Time.deltaTime;

            if (timeAfterTime.GetTimeElapsed(hydrationDropoffTime))
            {
                hydrationLevel -= hydrationDropoff;
            }

            if (hydrationLevel < 0)
            {
                gameOver = true;
            }

            waterDrop.fillAmount = hydrationLevel / 100;

        }
    }


}
