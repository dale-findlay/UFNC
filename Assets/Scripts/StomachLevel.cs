using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StomachLevel : MonoBehaviour
{

    //time in seconds for when the stomachLevel decreases.
    public float stomachDropoffTime = 1.0f;

    //the amount deduceted after stomachDropoffTime 
    public int stomachDropoff = 10;

    public float stomachLevel = 25;
    public Image waterDrop;

    TimeAfterTime timeAfterTime = new TimeAfterTime();

    public bool start = false;
    public bool gameOver = false;

    public void Reset()
    {
        gameOver = false;
        stomachLevel = 25;
        waterDrop.fillAmount = stomachLevel / 100;
    }

    // Use this for initialization
    void Start()
    {
        waterDrop.fillAmount = stomachLevel / 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timeAfterTime.time += Time.deltaTime;


            if (timeAfterTime.GetTimeElapsed(stomachDropoffTime))
            {
                if (stomachLevel > 0)
                {
                    stomachLevel -= stomachDropoff;
                }

                if (stomachLevel < 0)
                {
                    stomachLevel = 0;
                }


                if (stomachLevel > 100)
                {
                    gameOver = true;
                }


            }

            waterDrop.fillAmount = stomachLevel / 100;
        }
    }

}
