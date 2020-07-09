using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Eyes : MonoBehaviour {

    public float minTime = 5.0f;
    public float maxTime = 2.0f;

    public float blinkTime = 0.2f;

    public Sprite eyesOpen;
    public Sprite eyesClose;

    private TimeAfterTime timeAfterTime = new TimeAfterTime();
    float timeBeforeBlink = 0.0f;

    // Use this for initialization
    void Start ()
    {
        ResetBlinkTime();
        GetComponent<SpriteRenderer>().sprite = eyesOpen;
    }

    void ResetBlinkTime()
    {
        timeBeforeBlink = Random.Range(minTime, maxTime);
    }

    void SwitchSprite()
    {
        GetComponent<SpriteRenderer>().sprite = eyesClose;
        StartCoroutine(OpenEyes());
    }

    private IEnumerator OpenEyes()
    {
        yield return new WaitForSeconds(blinkTime);
        GetComponent<SpriteRenderer>().sprite = eyesOpen;
    }

    // Update is called once per frame
    void Update ()
    {
        timeAfterTime.time += Time.deltaTime;

        if(timeAfterTime.GetTimeElapsed(timeBeforeBlink))
        {
            SwitchSprite();
            ResetBlinkTime();
        }



    }
}
