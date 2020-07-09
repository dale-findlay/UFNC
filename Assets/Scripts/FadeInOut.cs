using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public float fadeInTime = 2.0f;
    public float fadeOutTime = 2.0f;
    public bool start = false;
    public bool fadeIn = false;
    public bool fadeOut = false;

    public List<GameObject> gameObjects = new List<GameObject>();

    private IEnumerator FadeTypeChange()
    {
        fadeIn = true;
        fadeOut = false;
        yield return new WaitForSeconds(fadeInTime);
        fadeIn = false;
        fadeOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            start = false;
            fadeIn = true;

            foreach(GameObject g in gameObjects)
            {
                g.SetActive(true);
            }

            GetComponent<Image>().enabled = true;

            StartCoroutine(FadeTypeChange());
        }

        if (fadeIn)
        {
            Color c = GetComponent<Image>().color;
            Debug.Log("FADE IN: " + c);
            c.a = Mathf.Lerp(c.a, 0, Time.deltaTime * fadeInTime);

            GetComponent<Image>().color = c;
        }
        else if(fadeOut)
        {
            Color c = GetComponent<Image>().color;
            Debug.Log("FADE OUT: " + c);
            c.a = Mathf.Lerp(c.a, 1, Time.deltaTime * fadeOutTime);

            GetComponent<Image>().color = c;
        }
    }
}
