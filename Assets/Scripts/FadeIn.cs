using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float time = 2.0f;
    public bool start = false;
    private bool fadeIn = false;
    public bool done = false;
    private float currentTime = 0.0f;

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }


    void OnLevelFinishedLoading(Scene scene, LoadSceneMode sceneMode)
    {
        Image img = GetComponent<Image>();

        Color c = img.color;
        c.a = 1;

        img.color = c;
        img.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            fadeIn = true;
        }
        
        if (fadeIn)
        {
            Color c = GetComponent<Image>().color;
            currentTime += Time.deltaTime;

            c.a = Mathf.Lerp(1, 0, currentTime / time);


            GetComponent<Image>().color = c;
        }

        if(GetComponent<Image>().color.a <= 0.01)
        {
            if(!done)
            {
                GetComponent<Image>().enabled = false;
            }

            start = false;
            fadeIn = false;
            done = true;
        }

    }
}
