using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public Text timeLeftText;
    public int secondsCounter = 60;
    private int initialSeconds = 0;
    float timeElapsed = 0.0f;
    private bool start = false;
    public bool gameOver = false;

    public void Reset()
    {
        gameOver = false;
        secondsCounter = initialSeconds;
        timeLeftText.text = secondsCounter.ToString();
    }

    // Use this for initialization
    void Start()
    {
        initialSeconds = secondsCounter;
        timeLeftText.text = secondsCounter.ToString();
    }

    public void StopTimer()
    {
        start = false;
    }
    public void StartTimer()
    {
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed > 1 && secondsCounter > 0)
            {
                timeElapsed = 0.0f;
                secondsCounter--;
                timeLeftText.text = secondsCounter.ToString();
            }

            if (secondsCounter == 0)
            {
                gameOver = true;
            }

            if (secondsCounter <= (initialSeconds * 1 / 6))
            {
                timeLeftText.color = Color.red;
            }

        }
    }
}
