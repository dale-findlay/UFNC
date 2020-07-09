using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float time = 2.0f;
    public bool start = false;
    private bool fadeOut = false;
    public bool done = false;
    private float currentTime = 0.0f;

    private void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (!fadeOut)
            {
                Image img = GetComponent<Image>();

                Color c = img.color;
                c.a = 0;

                img.color = c;
                img.enabled = true;

                GetComponent<Image>().enabled = true;
            }

            fadeOut = true;
        }

        if (fadeOut)
        {
            Color c = GetComponent<Image>().color;

            currentTime += Time.deltaTime;

            c.a = Mathf.Lerp(0, 1, currentTime / time);

            GetComponent<Image>().color = c;
        }

        if (GetComponent<Image>().color.a >= 0.99 && fadeOut)
        {
            start = false;
            fadeOut = false;
            done = true;
        }

    }
}
